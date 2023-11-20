using Microsoft.EntityFrameworkCore;
using ProductBotManager.Repositiry;
using ProductBotManager.Repositiry.Entity;
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
        public UserService(AppDbContext appDbContext)
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
    }
}
