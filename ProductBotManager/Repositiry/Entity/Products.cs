using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Repositiry.Entity
{
    internal class Product : AddedDateEntity, IEntity
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Count { get; set; } = 0;
        [Required]
        public DateTime? ExpirationDate { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? ShopId { get; set; }
        public Shop? Shop { get; set; }
        public decimal? Price { get; set; }

        public int UserId { get; set; }
    }
}
