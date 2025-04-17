using DNTPersianUtils.Core.IranCities;
using KandaIdea_Task.Application.DTOs;
using KandaIdea_Task.Domain.Interfaces;

namespace KandaIdea_Task.Application.Services
{
    public class ProvinceService : IProvinceService
    {
        public Task<List<ProvinceDTO>> ShowProvinceWithCities()
        {
            var AllProvince = Iran.Provinces.ToList();
            var result = new List<ProvinceDTO>();
            foreach (var province in AllProvince)
            {
                var newProvinceDto = new ProvinceDTO() 
                { 
                    ProvinceName = province.ProvinceName ,
                    Cities = province.Counties.Select(x=>x.CountyName).ToList()
                };
                result.Add(newProvinceDto);
            }
            return Task.FromResult(result);
        }
    }
}
