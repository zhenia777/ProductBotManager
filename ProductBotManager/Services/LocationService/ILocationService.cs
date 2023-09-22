using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.LocationService
{
    internal interface ILocationService
    {
        void Add(Location location);
        IQueryable<Location> GetAll();
        void Update(int id, double latitude, double longitude);
        void Delete(int id);

    }
}
