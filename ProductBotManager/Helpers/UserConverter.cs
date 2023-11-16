using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ProductBotManager.Helpers
{
    internal class UserConverter
    {
        public static Users ConvertInUser(Telegram.Bot.Types.User tgUser)
        {
            return new Users
            {
                Id = (int)tgUser.Id,
                Name = tgUser.FirstName,
                LastName = tgUser.LastName,
                Username = tgUser.Username
                //Id = tgUser.Id,
                //Username = tgUser.Username,
                //FirstName = tgUser.FirstName,
                //LastName = tgUser.LastName
            };
        }
    }
}
