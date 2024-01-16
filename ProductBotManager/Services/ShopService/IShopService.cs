using ProductBotManager.Repositiry.Entity;

namespace ProductBotManager.Services.ShopService
{
    internal interface IShopService
    {
        void Add(Shop shop);
        IQueryable<Shop> GetAll();
        void Update(int id, string name, string address);
        void ChangeLocation(int idShop, int idLocation);
        void Delete(int id);
        Task<Shop?> GetById(int id);
    }
}
