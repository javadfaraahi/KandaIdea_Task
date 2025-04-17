using KandaIdea_Task.Domain.Entities;
using KandaIdea_Task.Domain.Interfaces;
using KandaIdea_Task.Infrastructure.Data;

namespace KandaIdea_Task.Infrastructure.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }
    }
}
