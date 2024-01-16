using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.UpcitemdbService
{
    public interface IUpcitemdbService
    {
        Task<Product> Get(string barcode);
    }
}
