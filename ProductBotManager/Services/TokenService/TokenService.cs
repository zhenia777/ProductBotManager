using Newtonsoft.Json;
using ProductBotManager.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.TokenService
{
    public class TokenService:ITokenService
    {
        public TokenService()
        {
            string json = File.ReadAllText("app_config.json");
            Token = JsonConvert.DeserializeObject<Config>(json).TgToken;
        }
        public string Token { get; }
    }
}
