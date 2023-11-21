using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Helpers.Models
{
    internal class Config
    {
        public string TgToken {  get; set; }
        public long[] Admins { get; set; }
    }
}
