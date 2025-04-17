using KandaIdea_Task.Application.DTOs;

namespace KandaIdea_Task.Domain.Interfaces
{
    public interface IProvinceService
    {
        Task<List<ProvinceDTO>> ShowProvinceWithCities();
    }
}
