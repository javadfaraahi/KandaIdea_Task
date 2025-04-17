using KandaIdea_Task.Domain.Entities;
using KandaIdea_Task.Domain.Interfaces;
using KandaIdea_Task.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KandaIdea_Task.Infrastructure.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<City> GetCityByName(string cityName)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x=>x.Name == cityName);
            return city;
        }
    }
}
