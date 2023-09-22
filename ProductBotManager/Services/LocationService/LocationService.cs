using Microsoft.EntityFrameworkCore;
using ProductBotManager.Repositiry;
using ProductBotManager.Repositiry.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.LocationService
{
    internal class LocationService : ILocationService
    {
        private readonly AppDbContext appDbContext;
        public LocationService(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public async void Add(Location location)
        {
            await appDbContext.Locations.AddAsync(location);
            appDbContext.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var delete = await appDbContext.Locations.FirstOrDefaultAsync(x=>x.Id == id);
            if(delete == null) 
            {
                return;
            }
            appDbContext.Locations.Remove(delete);
            await appDbContext.SaveChangesAsync();
        }

        public IQueryable<Location> GetAll()
        {
            return appDbContext.Locations;
        }

        public async void Update(int id, double latitude, double longitude)
        {
            var update = await appDbContext.Locations.FirstOrDefaultAsync(x => x.Id == id);
            if (update == null) 
            {
                return;
            }
            update.Latitude = latitude;
            update.Longitude = longitude;
            await appDbContext.SaveChangesAsync();
        }
    }
}
