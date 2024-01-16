using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Telegram.Bot.Types;
using Newtonsoft.Json.Linq;

namespace ProductBotManager.Helpers
{
    public class ApiResponseModel
    {
        public string code { get; set; }
        public int total { get; set; }
        public int offset { get; set; }
        public List<Item> items { get; set; }
    }
    public class Item
    {
        public string ean { get; set; }
        public string title { get; set; }
        public string upc { get; set; }
        public string gtin { get; set; }
        public string elid { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string dimension { get; set; }
        public string weight { get; set; }
        public string category { get; set; }
        public string currency { get; set; }
        public decimal lowest_recorded_price { get; set; }
        public decimal highest_recorded_price { get; set; }
        public byte[] images { get; set; }
       // offers array   offer objects.
        public string user_data { get; set; }
    }

}
