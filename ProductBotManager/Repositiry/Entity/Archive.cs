using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Repositiry.Entity
{
    internal class Archive : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public Users? User { get; set; }
        public int? ProductId { get; set; }
        public Product? Products { get; set; }
        public string? ProductName { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? ProductCount { get; set; }
        public int? CategoryId { get; set; }
        public int? ShopId { get; set; }
        public Decimal? Price { get; set; }

    }
}
