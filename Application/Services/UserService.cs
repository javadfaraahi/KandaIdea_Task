using AutoMapper;
using FluentValidation;
using KandaIdea_Task.Application.DTOs;
using KandaIdea_Task.Application.Shared;
using KandaIdea_Task.Domain.Entities;
using KandaIdea_Task.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KandaIdea_Task.Application.Services
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UserCreateDto> _userCreateDtoValidator;
        #endregion
        #region Ctor
        public UserService(IUserRepository userRepository,
            IMapper mapper,
            ICityRepository cityRepository,
            IValidator<UserCreateDto> userCreateDtoValidator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _cityRepository = cityRepository;
            _userCreateDtoValidator = userCreateDtoValidator;
        }
        #endregion
        #region Methods
        public async Task<PagedResult<UserDto>> GetAllAsync(PaginationParams pagination)
        {
            var query = _userRepository.QueryWithIncludes(null, x => x.City);
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

        public  async Task<List<UserDto>> SearchByCity(string searchParameter)
        {
            if (searchParameter == null)
            {
                throw new ArgumentNullException(nameof(searchParameter));
            }
            var users = _userRepository.QueryWithIncludes(
            x => x.City.Name.Contains(searchParameter),
            x => x.City
        );
            var result = _mapper.Map<List<UserDto>>(users);
            return result;
        }

        public async Task<List<UserDto>> SearchByFullName(string searchParameter)
        {
            if (searchParameter == null)
            {
                throw new ArgumentNullException(nameof(searchParameter));
            }
            var users = _userRepository.QueryWithIncludes(
            x => x.FirstName.ToLower().Contains(searchParameter.ToLower()) ||
                 x.LastName.ToLower().Contains(searchParameter.ToLower()),
            x => x.City
        );
            var result = _mapper.Map<List<UserDto>>(users);
            return result;
        }

        public async Task<List<UserDto>> SearchByPhoneNumber(string searchParameter)
        {
            if (searchParameter == null)
            {
                throw new ArgumentNullException(nameof(searchParameter));
            }
            var users = _userRepository.QueryWithIncludes(
                x=>x.PhoneNumber.Contains(searchParameter),
                x => x.City);
            var result = _mapper.Map<List<UserDto>>(users);
            return result;
        }

        public async Task<List<UserDto>> SearchByProvince(string searchParameter)
        {
            if (searchParameter == null)
            {
                throw new ArgumentNullException(nameof(searchParameter));
            }
            var users = await _userRepository.AsQueryable()
                .Include(x=>x.City)
                .ThenInclude(x=>x.Province)
                .Where(x=>x.City.Province.Name.Contains(searchParameter)).ToListAsync();
            var result = _mapper.Map<List<UserDto>>(users);

            return result;
        }
        public async Task DeleteRange(List<int> Ids)
        {
            if (Ids == null)
            {
                throw new ArgumentNullException(nameof(Ids));
            }
            await _userRepository.DeleteRangeAsync(Ids);
        }
        public async Task Delete(int Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            await _userRepository.DeleteAsync(Id);
        }
        public async Task<User> UpdateUser (UserUpdateDto user)
        {
            var existingUser = await _userRepository.GetAsync(user.Id);
            if (existingUser == null)
            {
                throw new ArgumentException(nameof(User));
            }
            var newCity = await _cityRepository.GetCityByName(user.CityName);
            existingUser.CityId = newCity.Id;
            existingUser.City = newCity;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            _userRepository.UpdateAsync(existingUser);
            return existingUser;

        }
        public async Task<User> CreateUser(UserCreateDto user)
        {
            var validationResult = await _userCreateDtoValidator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var city = await _cityRepository.GetCityByName(user.CityName);
            if(city == null)
            {
                throw new Exception("City not found!");
            }
            var newUser = _mapper.Map<User>(user);
            newUser.CityId = city.Id;
            newUser.City = city;
            return await _userRepository.AddAsync(newUser);
        }

        public async Task<int> CountUsersByProvinceAsync(string provinceName)
        {
            var users = await SearchByProvince(provinceName);
            return users.Count();
            
        }

        public async Task<int> CountUsersByCityAsync(string cityName)
        {
            var users = await SearchByCity(cityName);
            return users.Count();
        }
        #endregion
    }
}
