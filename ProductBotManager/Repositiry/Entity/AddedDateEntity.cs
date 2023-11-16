using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Repositiry.Entity
{
    public abstract class AddedDateEntity
    {
        public AddedDateEntity() => AddedDate = DateTime.UtcNow;
        public DateTime AddedDate { get; set; }
    }
}
