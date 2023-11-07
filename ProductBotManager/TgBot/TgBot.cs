using ProductBotManager.Services.CategoryService;
using ProductBotManager.Services.LocationService;
using ProductBotManager.Services.ProductService;
using ProductBotManager.Services.ShopService;
using ProductBotManager.Services.TokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ProductBotManager.TgBot
{
    internal class TgBot
    {
        TelegramBotClient client;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;
        private readonly IProductService _productService;
        private readonly IShopService _shopService;
        public TgBot(ITokenService tokenService,
                     ICategoryService categoryService,
                     ILocationService locationService,
                     IProductService productService,
                     IShopService shopService) {
            client = new TelegramBotClient(tokenService.Token);
            _categoryService = categoryService;
            _locationService = locationService;
            _productService = productService;
            _shopService = shopService;
        }
    }
}
