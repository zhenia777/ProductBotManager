﻿using Microsoft.EntityFrameworkCore;
using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Repositiry
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<FavoriteProduct> favoriteProducts { get; set; }
        public AppDbContext()
        {
            Task.Run(async () => await Database.EnsureCreatedAsync());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DbProdBotManager.db ");
        }

    }
}
