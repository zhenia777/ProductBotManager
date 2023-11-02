using ProductBotManager.Services.TokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ProductBotManager.TgBot
{
    internal class TgBot
    {
        TelegramBotClient client;
        public TgBot(ITokenService tokenService) {
            client = new(tokenService.Token);
        }
    }
}
