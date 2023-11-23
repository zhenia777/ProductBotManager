using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductBotManager.Helpers;
using ProductBotManager.Repositiry;
using ProductBotManager.Services.AdminsIdService;
using ProductBotManager.Services.CategoryService;
using ProductBotManager.Services.LocationService;
using ProductBotManager.Services.LogService;
using ProductBotManager.Services.ProductService;
using ProductBotManager.Services.RegistrationService;
using ProductBotManager.Services.ShopService;
using ProductBotManager.Services.TokenService;
using ProductBotManager.Services.UserService;
using ProductBotManager.TgBot;

var services = new ServiceCollection()
    //ConnectionString
    .AddDbContext<AppDbContext>(opt => opt.UseSqlite(Constants.CONNECTION_STRING))
    .AddTransient<ICategoryService, CategoryService>()
    .AddTransient<ILocationService, LocationService>()
    .AddTransient<IProductService, ProductService>()
    .AddTransient<IShopService, ShopService>()
    .AddTransient<ILogService, LogService>()
    .AddTransient<ITokenService, TokenService>()
    .AddTransient<TgBot>()
    .AddTransient<IRegistrationService, RegistrationService>()
    .AddTransient<IAdminsIdService, AdminsIdService>()
    .AddTransient<IUserService, UserService>();

using var provider = services.BuildServiceProvider();

TgBot tgBot = provider.GetService<TgBot>();

tgBot.Start();
tgBot.GetInfo();
Console.ReadLine();