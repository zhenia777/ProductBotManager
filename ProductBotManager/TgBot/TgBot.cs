using ProductBotManager.Helpers;
using ProductBotManager.Services.CategoryService;
using ProductBotManager.Services.LocationService;
using ProductBotManager.Services.LogService;
using ProductBotManager.Services.ProductService;
using ProductBotManager.Services.RegistrationService;
using ProductBotManager.Services.ShopService;
using ProductBotManager.Services.TokenService;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ProductBotManager.TgBot;

public class TgBot
{
    private TelegramBotClient client;
    private readonly ILogService _logService;
    private readonly IRegistrationService _registrationService;
    public TgBot(ITokenService tokenService,
                 IRegistrationService registrationService,
                 ILogService logService
        )
    {
        client = new TelegramBotClient(tokenService.Token);
        _logService = logService;
        _registrationService = registrationService;
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
    }

    private Task ErrorHandler(ITelegramBotClient bot, Exception ex, CancellationToken clt)
    {
        _logService.Log($"TG Bot Error -> \n{ex}");
        return Task.CompletedTask;
    }

    #endregion
}
