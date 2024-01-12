using Microsoft.EntityFrameworkCore;
using ProductBotManager.Repositiry.Entity;

namespace ProductBotManager.Repositiry
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Users> Users { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
