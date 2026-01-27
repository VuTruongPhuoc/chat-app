using AutoMapper;
using ChatApp.Application.Dtos.Users;
using ChatApp.Domain.Entities;
using Common.Models.DTOs;

namespace ChatApp.Application.Mappings;

public sealed class UserMappingProfile : Profile
{
    #region Ctor

    public UserMappingProfile()
    {
        CreateMap<RegisterUserRequest, Users>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

        CreateMap<Users, UserDto>();

        CreateMap<RegisterRequest, Users>();
    }

    #endregion
}