using AutoMapper;
using KandaIdea_Task.Application.DTOs;
using KandaIdea_Task.Domain.Entities;
namespace KandaIdea_Task.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.CityName , opt => opt.MapFrom(src=> src.City.Name));
        CreateMap<UserCreateDto, User>();
    }
}
