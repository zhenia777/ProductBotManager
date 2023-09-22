using ProductBotManager.Repositiry.Entity;
using System.Runtime.CompilerServices;

namespace ProductBotManager.Helpers
{
    internal static class ProductExtensions
    {
        public static Archive CreateArchive(this Product product)
        {
            return new Archive
            {
                UserId = product.UserId,
                CategoryId = product.CategoryId,
                Price = product.Price,
                ProductCount = product.Count,
                ExpirationDate = product.ExpirationDate,
                ProductName = product.Name,
                ShopId = product.ShopId
            };
        }
    }
}
