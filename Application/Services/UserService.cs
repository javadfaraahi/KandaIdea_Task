using AutoMapper;
using KandaIdea_Task.Application.DTOs;
using KandaIdea_Task.Application.Shared;
using KandaIdea_Task.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KandaIdea_Task.Application.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Ctor
        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public async Task<PagedResult<UserDto>> GetAllAsync (PaginationParams pagination)
        {
            var query = _userRepository.AsQueryable();
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip(pagination.Skip)
                .Take(pagination.PageSize)
                .ToListAsync();
            var result = _mapper.Map<List<UserDto>>(items);
            return new PagedResult<UserDto>
            {
                TotalCount = totalCount,
                Items = result
            };
        }
        
        #endregion
    }
}
