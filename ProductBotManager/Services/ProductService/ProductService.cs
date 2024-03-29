﻿using Microsoft.EntityFrameworkCore;
using ProductBotManager.Helpers;
using ProductBotManager.Repositiry;
using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.ProductService
{
    internal class ProductService : IProductService
    {
        private AppDbContext appDbContext;
        public ProductService(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public async Task Add(Product product)
        {

            product.ExpirationDate = DateTime.UtcNow.AddDays(5);
           await appDbContext.Products.AddAsync(product);
           await appDbContext.SaveChangesAsync();
        }

        public async Task ChangeCategory(int idProduct, int idCategory)
        {
            var change = await appDbContext.Products.FirstOrDefaultAsync(x => x.Id == idProduct);
            if(change == null) 
            {
                return;
            }
            change.CategoryId = idCategory;
            await appDbContext.SaveChangesAsync();

        }

        public async Task ChangePrice(int id, decimal newPrice)
        {
            var change = await appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(change == null) 
            {
                return;
            }
            change.Price = newPrice;
            await appDbContext.SaveChangesAsync();
        }

        public async Task Decrease(int id)
        {
            var change = await appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (change == null)
            {
                return;
            }
            if (change.Count - 1 > 0)
            {
                change.Count--;
                await appDbContext.SaveChangesAsync();
                return;
            }
            await Delete(id);
        }

        public async Task Delete(int id)
        {
            var del = await appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (del == null)
            {
                return;
            }

            await appDbContext.Archives.AddAsync(del.CreateArchive());
            appDbContext.Products.Remove(del);
            await appDbContext.SaveChangesAsync();
            //delete from Products
            //save
        }

        public async Task<IQueryable<Product>> GetAllProducts(long TgUserId)
        {
           var user = await appDbContext.Users.FirstOrDefaultAsync(x => x.TgId == TgUserId);
           var products = appDbContext.Products.Where(x => x.UserId == user.Id);
           return products;
        }

        public async Task Increase(int id)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(product == null)
            {
                return;
            }
            product.Count++;
            await appDbContext.SaveChangesAsync();
        }

        //public void Update(int id)
        //{

        //    throw new NotImplementedException();
        //}

        // TODO: CreateAddFavoriteMethod
    }
}
