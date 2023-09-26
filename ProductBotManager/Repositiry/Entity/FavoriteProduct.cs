using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Repositiry.Entity
{
    internal class FavoriteProduct : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public Users? User { get; set; }
        public int? ProductId { get; set; }
        public Product? Products { get; set; }
    }
}
