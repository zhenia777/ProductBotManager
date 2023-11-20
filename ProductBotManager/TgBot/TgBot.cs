using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ProductBotManager.Helpers;
using ProductBotManager.Helpers.Models;
using ProductBotManager.Repositiry;
using ProductBotManager.Repositiry.Entity;
using ProductBotManager.Services.AdminsIdService;
using ProductBotManager.Services.CategoryService;
using ProductBotManager.Services.LocationService;
using ProductBotManager.Services.LogService;
using ProductBotManager.Services.ProductService;
using ProductBotManager.Services.RegistrationService;
using ProductBotManager.Services.ShopService;
using ProductBotManager.Services.TokenService;
using ProductBotManager.Services.UserService;
using System.Xml.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ProductBotManager.TgBot;

public class TgBot
{
    private TelegramBotClient client;
    private readonly ILogService _logService;
    private readonly IRegistrationService _registrationService;
    private readonly IAdminsIdService _adminsIdService;
    private readonly IUserService _userService;
    public TgBot(ITokenService tokenService,
                 IRegistrationService registrationService,
                 ILogService logService,
                 IAdminsIdService adminsIdService,
                 IUserService userService
        )
    {
        client = new TelegramBotClient(tokenService.Token);
        _logService = logService;
        _registrationService = registrationService;
        _adminsIdService= adminsIdService;
        _userService = userService;
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
    private async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken clt)
    {
        if(update.Message.Text == "/start" )
        {
            await _registrationService.SignUp(update.Message.From.ToUsers());
        }

        Users users = new Users();
        if (_adminsIdService.AdminsId.Any(id => users.TgId == long.Parse(id)))
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new KeyboardButton[][]
               {
               new KeyboardButton[]{ "Get bot users!" }
               });

            
            var allTgIds = string.Join(", ", _userService.GetAll().Select(u => u.TgId));
            
            await client.SendTextMessageAsync(update.Message.From.Id, allTgIds);

            await client.SendTextMessageAsync(
                chatId: update.Message.From.Id,
                text: "Get bot users!",
                replyMarkup: replyKeyboardMarkup);
        }
    }

    private Task ErrorHandler(ITelegramBotClient bot, Exception ex, CancellationToken clt)
    {
        _logService.Log($"TG Bot Error -> \n{ex}");
        return Task.CompletedTask;
    }

    #endregion
}
