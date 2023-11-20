using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ProductBotManager.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.AdminsIdService
{
    public class AdminsIdService: IAdminsIdService
    {
        public AdminsIdService() 
        {
            string json = File.ReadAllText("app_config.json");
            AdminsId = JsonConvert.DeserializeObject<Config>(json).Admins;
        }
        public string[] AdminsId { get; }
    }
}
