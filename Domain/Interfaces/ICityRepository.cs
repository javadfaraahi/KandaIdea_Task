using KandaIdea_Task.Domain.Entities;

namespace KandaIdea_Task.Domain.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        Task<City> GetCityByName(string cityName);
    }
}
