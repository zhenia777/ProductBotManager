using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ProductBotManager.Helpers
{
    internal static class UserExtensions
    {
        public static Users ToUsers(this User tgUser)
        {
            return new Users
            {
                TgId = tgUser.Id,
                Name = tgUser.FirstName,
                LastName = tgUser.LastName,
                Username = tgUser.Username
            };
        }
    }
}
