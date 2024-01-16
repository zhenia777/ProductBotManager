using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.ProductService
{
    public interface IProductService
    {

        public Task Add(Product product);
        //public void Update(int id);
        public Task Increase(int id);
        public Task Decrease(int id);

        public Task ChangeCategory(int idProduct, int idCategory);
        public Task ChangePrice(int id, decimal newPrice);
        public Task<IQueryable<Product>> GetAllProducts(long TgUserId);
        public Task Delete(int id);
    }
}
