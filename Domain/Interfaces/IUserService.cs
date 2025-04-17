using KandaIdea_Task.Application.DTOs;
using KandaIdea_Task.Application.Shared;
using KandaIdea_Task.Domain.Entities;

namespace KandaIdea_Task.Domain.Interfaces
{
    public interface IUserService
    {
        Task<PagedResult<UserDto>> GetAllAsync(PaginationParams pagination);
        Task<List<UserDto>> SearchByFullName(string searchParameter);
        Task<List<UserDto>> SearchByPhoneNumber(string searchParameter);
        Task<List<UserDto>> SearchByCity(string searchParameter);
        Task<List<UserDto>> SearchByProvince(string searchParameter);
        Task DeleteRange(List<int> Ids);
        Task Delete(int Id);
        Task<User> UpdateUser(UserUpdateDto user);
        Task<User> CreateUser(UserCreateDto user);
        Task<int> CountUsersByProvinceAsync(string provinceName);
        Task<int> CountUsersByCityAsync(string cityName);
    }
}
