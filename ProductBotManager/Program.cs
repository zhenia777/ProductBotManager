using Microsoft.Extensions.DependencyInjection;
using ProductBotManager.Repositiry;
using ProductBotManager.Services.CategoryService;
using ProductBotManager.Services.LocationService;
using ProductBotManager.Services.LogService;
using ProductBotManager.Services.ProductService;
using ProductBotManager.Services.RegistrationService;
using ProductBotManager.Services.ShopService;
using ProductBotManager.Services.TokenService;
using ProductBotManager.TgBot;

var services = new ServiceCollection()
    .AddTransient<AppDbContext>()
    .AddTransient<ICategoryService, CategoryService>()
    .AddTransient<ILocationService, LocationService>()
    .AddTransient<IProductService, ProductService>()
    .AddTransient<IShopService, ShopService>()
    .AddTransient<ILogService, LogService>()
    .AddTransient<ITokenService, TokenService>()
    .AddTransient<TgBot>()
    .AddTransient<IRegistrationService, RegistrationService>();

using var provider = services.BuildServiceProvider();



TgBot tgBot = provider.GetService<TgBot>();

tgBot.Start();
tgBot.GetInfo();
Console.ReadLine();