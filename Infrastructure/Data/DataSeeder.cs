using Microsoft.EntityFrameworkCore;
using DNTPersianUtils.Core.IranCities;
using KandaIdea_Task.Domain.Entities;

namespace KandaIdea_Task.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static async Task EnsureSeededAsync(AppDbContext context)
        {
            var provinceList = Iran.Provinces.ToList();

            if (!await context.Provinces.AnyAsync()) 
            {
                var provincesToAdd = new List<Domain.Entities.Province>();
                foreach (var province in provinceList)
                {
                    provincesToAdd.Add(new Domain.Entities.Province() { Name = province.ProvinceName });
                }
                await context.Provinces.AddRangeAsync(provincesToAdd);
                await context.SaveChangesAsync();
            }
            if (!await context.Cities.AnyAsync())
            {
                var citiesToAdd = new List<Domain.Entities.City>();
                foreach (var province in provinceList)
                {
                    var existingProvince = await context.Provinces.FirstOrDefaultAsync(x => x.Name == province.ProvinceName);
                    foreach (var city in province.Counties)
                    {
                        citiesToAdd.Add(new Domain.Entities.City() { Name = city.CountyName, Province = existingProvince, ProvinceId = existingProvince.Id });
                    }
                }
                await context.Cities.AddRangeAsync(citiesToAdd);
                await context.SaveChangesAsync();
            }
        }
    }
}
