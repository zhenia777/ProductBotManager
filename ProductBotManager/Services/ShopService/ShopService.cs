using Microsoft.EntityFrameworkCore;
using ProductBotManager.Repositiry;
using ProductBotManager.Repositiry.Entity;

namespace ProductBotManager.Services.ShopService
{
    internal class ShopService : IShopService
    {
        private readonly AppDbContext _appDbContext;
        public ShopService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async void Add(Shop shop)
        {
            await _appDbContext.Shops.AddAsync(shop);
            await _appDbContext.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            //var shop = await _appDbContext.Shops.FirstOrDefaultAsync(x=> x.Id == id);
            //if(shop is null) 
            //{
            //    return;
            //}
            //_appDbContext.Shops.Remove(shop);
            //await _appDbContext.SaveChangesAsync();

            _appDbContext.Entry(new Shop() { Id = id }).State = EntityState.Deleted;
            await _appDbContext.SaveChangesAsync();

        }

        public IQueryable<Shop> GetAll() => _appDbContext.Shops;

        public async Task<Shop?> GetById(int id)
            => await _appDbContext.Shops.FirstOrDefaultAsync(x => x.Id == id);

        public async void Update(int id, string name, string address)
        {
            //var shop = await _appDbContext.Shops.FirstOrDefaultAsync(x => x.Id == id);
            //if(shop is null)
            //{
            //    return;
            //}
            //shop.Name = name;
            //shop.Address = address;
            //await _appDbContext.SaveChangesAsync();

            _appDbContext.Entry(new Shop() { Id = id, Name = name, Address = address })
                         .State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
