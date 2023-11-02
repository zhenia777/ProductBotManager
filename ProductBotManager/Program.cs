using Microsoft.Extensions.DependencyInjection;
using ProductBotManager.Repositiry;
using ProductBotManager.Services.CategoryService;
using ProductBotManager.Services.LocationService;
using ProductBotManager.Services.ProductService;
using ProductBotManager.Services.ShopService;

var services = new ServiceCollection()
    .AddTransient<AppDbContext>()
    .AddTransient<ICategoryService, CategoryService>()
    .AddTransient<ILocationService, LocationService>()
    .AddTransient<IProductService, ProductService>()
    .AddTransient<IShopService, ShopService>();

