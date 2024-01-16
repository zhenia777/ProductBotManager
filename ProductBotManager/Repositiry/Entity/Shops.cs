using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Repositiry.Entity
{
    public class Shop : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string? Name { get; set; }

        public string? Address { get; set; }

        public int? LocationId { get; set; }
        public Location? Location { get; set; }


    }
}
