using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.ProductService
{
    internal interface IProductService
    {

        public void Add(Product product);
        public void Update(int id);
        public void Increase(int id);
        public void Decrease(int id);

        public void ChangeCategory(int idProduct, int idCategory);
        public void ChangePrice(int id, decimal newPrice);
        public IQueryable<Product> GetAllProducts(int userId);
        public Task Delete(int id);
    }
}
