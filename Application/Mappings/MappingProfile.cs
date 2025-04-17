using AutoMapper;
using KandaIdea_Task.Application.DTOs;
using KandaIdea_Task.Domain.Entities;
namespace KandaIdea_Task.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserCreateDto, User>();
    }
}
