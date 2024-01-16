using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ProductBotManager.Services.RegistrationService
{
    public interface IRegistrationService
    {
        public Task SignUp(Users user);
    }
}
