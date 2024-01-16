using ProductBotManager.Helpers;
using ProductBotManager.Repositiry.Entity;
using ProductBotManager.Services.AdminsIdService;
using ProductBotManager.Services.BarcodeServices.BarcodeLookupService;
using ProductBotManager.Services.LogService;
using ProductBotManager.Services.ProductService;
using ProductBotManager.Services.RegistrationService;
using ProductBotManager.Services.TokenService;
using ProductBotManager.Services.UpcitemdbService;
using ProductBotManager.Services.UserService;
using System.Drawing;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using ZXing;

namespace ProductBotManager.TgBot;

public class TgBot
{
    private Dictionary<string, Product> buffer = new();
    private TelegramBotClient client;
    private readonly ILogService _logService;
    private readonly IRegistrationService _registrationService;
    private readonly IAdminsIdService _adminsIdService;
    private readonly IUserService _userService;
    private readonly IBarcodeLookupService _barcodeLookupService;
    private readonly IProductService _productService;
    private readonly IUpcitemdbService _upcitemdbService;
    public TgBot(ITokenService tokenService,
                 IRegistrationService registrationService,
                 ILogService logService,
                 IAdminsIdService adminsIdService,
                 IUserService userService,
                 IBarcodeLookupService barcodeLookupService,
                 IProductService productService,
                 IUpcitemdbService upcitemdbService
        )
    {
        client = new TelegramBotClient(tokenService.Token);
        _logService = logService;
        _registrationService = registrationService;
        _adminsIdService = adminsIdService;
        _userService = userService;
        _barcodeLookupService = barcodeLookupService;
        _productService = productService;
        _upcitemdbService = upcitemdbService;
    }
    #region -- Public Methods -- 
    public async Task GetInfo()
    {
        var info = await client.GetMeAsync();
        _logService.Log($"User ID:{info.Id} User name: {info.Username}");
    }
    public void Start()
    {
        client.StartReceiving(
            updateHandler: UpdateHandler,
            pollingErrorHandler: ErrorHandler);
    }

    #endregion
    #region -- Private Methods --
    private async Task CallbackQueryHandler(Update update)
    {
        try
        {
            await client.AnswerCallbackQueryAsync(update.CallbackQuery.Id);
        }
        catch{return;}

        var data = update.CallbackQuery.Data;

        int userId = await _userService.GetMyId(update.CallbackQuery.From.Id);

        if (data.Contains(Constants.ADD_PRODUCTS))
        {
            var product = buffer[data.Substring(data.IndexOf(';') + 1)];
            product.UserId = userId;
            await _productService.Add(product);
        }
        else if (data.Contains(Constants.ADD_FAVORITE_PRODUCTS))
        {
            var product = buffer[data.Substring(data.IndexOf(';') + 1)];
            product.UserId = userId;
            await _productService.Add(product);
        }
        else if (data.Contains(Constants.MY_PRODUCTS))
        {
            //"event;do;id"
            int productId = int.Parse(data.Split(";").Last());
            if (data.Contains("+"))
            {
                await _productService.Increase(productId);
            }
            if (data.Contains("-"))
            {
                await _productService.Decrease(productId);
            }
            if (data.Contains("Del"))
            {
                await _productService.Delete(productId);
            }
        }
        await client.SendTextMessageAsync(
                update.CallbackQuery.From.Id,
                text: "Ok!");
    }


    private async Task HandlePhotoUpdate(ITelegramBotClient bot, Update update)
    {
        var fileId = update.Message.Photo.Last().FileId;
        var fileInfo = await client.GetFileAsync(fileId);
        using Stream fileStream = new MemoryStream();
        await client.DownloadFileAsync(
            fileInfo.FilePath,
            fileStream
            );

        BarcodeReader barcodeReader = new BarcodeReader();

        Bitmap bitmap = new Bitmap(fileStream);
        var convertBitmap = new BitmapLuminanceSource(bitmap);
        var resultReading = barcodeReader.Decode(convertBitmap);
        if (resultReading == null)
        {
            await client.SendTextMessageAsync(
                update.Message.From.Id,
                text: "I couldn`t read your photo! ((");
        }
        else
        {
            InlineKeyboardMarkup inlineKeyboard = new(new[]
            {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData(Constants.ADD_FAVORITE_PRODUCTS
                        ,Constants.ADD_FAVORITE_PRODUCTS + ";"+ resultReading.Text)
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData(Constants.ADD_PRODUCTS
                        ,Constants.ADD_PRODUCTS + ";" + resultReading.Text)
                    }
                });
            buffer[resultReading.Text] = await _upcitemdbService.Get(resultReading.Text);
            await client.SendTextMessageAsync(
                update.Message.From.Id,
                text: buffer[resultReading.Text].Name,
                replyMarkup: inlineKeyboard);

        }
    }


        private async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken clt)
        {
        if(update.Type == UpdateType.CallbackQuery)
        {
            CallbackQueryHandler(update);
            return;
        }
        if (update?.Message?.Type == MessageType.Photo)
        {
            HandlePhotoUpdate(bot, update);
            return;
        }
        if (update?.Message?.Text == "/start")
        {
            await _registrationService.SignUp(update.Message.From.ToUsers());

            if (_adminsIdService.AdminsId.Any(id => update.Message.From.Id == id))
            {

                ReplyKeyboardMarkup replyKeyboardMarkup = new(new KeyboardButton[][]
                   {
                        new KeyboardButton[]{ Constants.SEND_USER_BUTTON }
                   });

                await client.SendTextMessageAsync(
                chatId: update.Message.From.Id,
                text: "Get bot users!",
                replyMarkup: replyKeyboardMarkup);
            }
            ReplyKeyboardMarkup checkBarcode = new(new KeyboardButton[][]
            {
                new KeyboardButton[] {Constants.CHECK_PRODUCT_BUTTON},
                new KeyboardButton[] {Constants.MY_PRODUCTS},
            });
            await client.SendTextMessageAsync(
                chatId: update.Message.From.Id,
                text: "Check my product!",
                replyMarkup: checkBarcode);
            return;
        }
        HandleUser(update!);
        
    }

    private async void HandleUser (Update update)
    {
        if (update?.Message?.Text == Constants.CHECK_PRODUCT_BUTTON)
        {
            await client.SendTextMessageAsync(
                chatId: update.Message.From.Id,
                text: "Send me your barcode!");
        }

        if (update?.Message?.Text == Constants.MY_PRODUCTS)
        {
            
            var products = await _productService.GetAllProducts(update.Message.From.Id);
            InlineKeyboardMarkup productInlineKeyboard = new(
                products.Select(x => new InlineKeyboardButton[] 
                { 
                    InlineKeyboardButton.WithCallbackData($"({x.Count}){x.Name}", Constants.MY_PRODUCTS + ";" + x.Id ),
                    InlineKeyboardButton.WithCallbackData("+", Constants.MY_PRODUCTS + ";+;" + x.Id ),
                    InlineKeyboardButton.WithCallbackData("-", Constants.MY_PRODUCTS + ";-;" + x.Id ),
                    InlineKeyboardButton.WithCallbackData("Delete", Constants.MY_PRODUCTS + ";Del;" + x.Id )
                }).ToArray()
                );

            if (products == null)
            {
                await client.SendTextMessageAsync(
                chatId: update.Message.From.Id,
                text: "No products!");
                return;
            }
            string productsList = string.Join('\n', products.Select(x=>x.Name));
            await client.SendTextMessageAsync(
                chatId: update.Message.From.Id,
                text: "Your list:",
                replyMarkup: productInlineKeyboard);

            
        }

        if (update?.Message?.Text == Constants.SEND_USER_BUTTON && _adminsIdService.AdminsId.Any(id => update.Message.From.Id == id))
        {
            var allTgIds = string.Join(", ", _userService.GetAll().Select(u => new { u.TgId, u.Name }));

            await client.SendTextMessageAsync(
                chatId: update.Message.From.Id,
                text: allTgIds == string.Empty ? "No users" : allTgIds);
        }
    }
    private Task ErrorHandler(ITelegramBotClient bot, Exception ex, CancellationToken clt)
    {
        _logService.Log($"TG Bot Error -> \n{ex}");
        return Task.CompletedTask;
    }

    #endregion
}
