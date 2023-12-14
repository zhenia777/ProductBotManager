using Newtonsoft.Json;
using ProductBotManager.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Helpers
{
    internal class Constants
    {
        static Constants()
        {
            string json = File.ReadAllText(APP_CONFIG_FILE);
            Config conf = JsonConvert.DeserializeObject<Config>(json);
            CONNECTION_STRING = conf.ConnectionString;
        }
        public static string APP_CONFIG_FILE { get;} = "app_config.json";
        public static string SEND_USER_BUTTON { get;} = "Get bot users!";
        public static string CHECK_PRODUCT_BUTTON { get; } = "Check my product!";
        public static string CONNECTION_STRING { get; }
        //Buttons
    }
}
