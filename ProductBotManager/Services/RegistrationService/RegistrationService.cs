using Microsoft.EntityFrameworkCore;
using ProductBotManager.Repositiry;
using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.RegistrationService
{
    public class RegistrationService: IRegistrationService
    {
        private readonly AppDbContext _appDBcontext;
        public RegistrationService(AppDbContext appDBcontext)
        {
            appDBcontext = _appDBcontext;
        }
        public async Task SignUp(Users users) 
        {
            if((await _appDBcontext.Users.FirstOrDefaultAsync(x=>x.TgId == users.TgId)) != null )
            {
                return;
            }
            _appDBcontext.Users.Add(users);
        }


    }
}
