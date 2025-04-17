using KandaIdea_Task.Application.DTOs;
using KandaIdea_Task.Application.Shared;

namespace KandaIdea_Task.Domain.Interfaces
{
    public interface IUserService
    {
        Task<PagedResult<UserDto>> GetAllAsync(PaginationParams pagination);
    }
}
