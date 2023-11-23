using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.BarcodeServices.BarcodeLookupService;

public class BarcodeLookupService : IBarcodeLookupService
{
    public Product Get(string barcode)
    {

        return new Product() {Name = "name" };
    }
}
