using Microsoft.VisualBasic;
using Newtonsoft.Json;
using ProductBotManager.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.ConnectionStringService
{
    public class ConnectionStringService : IConnectionStringService
    {
        ConnectionStringService() 
        {
            string json = File.ReadAllText("app_config.json");
            ConnectionString = JsonConvert.DeserializeObject<Config>(json).ConnectionString;
        }
        public string ConnectionString { get; }
    }
}
