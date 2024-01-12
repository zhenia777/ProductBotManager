using Microsoft.EntityFrameworkCore;
using ProductBotManager.Repositiry;
using ProductBotManager.Repositiry.Entity;
using ProductBotManager.Services.LogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly AppDbContext _appDbContext;
        public UserService(AppDbContext appDbContext,
                           ILogService logService)
        {
            _appDbContext = appDbContext;
        }

        public async void Add(Users user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            _appDbContext.Entry(new Users() { Id = id }).State = EntityState.Deleted;
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<Users> GetAll() => _appDbContext.Users;

        public async Task<Users?> GetById(int id)
            => await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<int> GetMyId(long telegramId)
        {
            var userExist = await _appDbContext.Users.AnyAsync(x => x.TgId == telegramId);
            if (!userExist)
            {
                Add(new Users() { TgId = telegramId, Name = ""});
            }
            return (await _appDbContext.Users.FirstAsync(x => x.TgId == telegramId)).Id;
        }
    }
}
