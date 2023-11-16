using ProductBotManager.Helpers;
using ProductBotManager.Services.CategoryService;
using ProductBotManager.Services.LocationService;
using ProductBotManager.Services.LogService;
using ProductBotManager.Services.ProductService;
using ProductBotManager.Services.ShopService;
using ProductBotManager.Services.TokenService;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ProductBotManager.TgBot;

public class TgBot
{
    private TelegramBotClient client;
    private readonly ICategoryService _categoryService;
    private readonly ILocationService _locationService;
    private readonly IProductService _productService;
    private readonly IShopService _shopService;
    private readonly ILogService _logService;
    public TgBot(ITokenService tokenService,
                 //ICategoryService categoryService,
                 //ILocationService locationService,
                 //IProductService productService,
                 //IShopService shopService,
                 ILogService logService)
    {
        client = new TelegramBotClient(tokenService.Token);
        //_categoryService = categoryService;
        //_locationService = locationService;
        //_productService = productService;
        //_shopService = shopService;
        _logService = logService;
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
    private Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken clt)
    {
        if(update.Message.From.Id == )
        {
            
        }
        return Task.CompletedTask;
    }

    private Task ErrorHandler(ITelegramBotClient bot, Exception ex, CancellationToken clt)
    {
        _logService.Log($"TG Bot Error -> \n{ex}");
        return Task.CompletedTask;
    }

    #endregion
}
