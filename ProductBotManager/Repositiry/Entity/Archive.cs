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
        public Products? Products { get; set; }
        public string? ProductName { get; set; }
        public DateTime? ProductExpirationDate { get; set; }
        public int? ProductCount { get; set; }
        public string? CategoryId { get; set; }
        public string? ShopId { get; set; }
        public Decimal? Price { get; set; }

    }
}
