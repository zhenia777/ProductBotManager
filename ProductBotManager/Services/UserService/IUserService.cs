using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.UserService
{
    public interface IUserService
    {
        void Add(Users user);
        IQueryable<Users> GetAll();
        void Delete(int id);
        Task<Users?> GetById(int id);
        Task<int> GetMyId(long telegramId);
    }
}
