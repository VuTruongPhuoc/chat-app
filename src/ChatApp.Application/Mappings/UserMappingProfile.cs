using AutoMapper;
using ChatApp.Application.Dtos.Users.Requests;
using ChatApp.Domain.Entities;
using Common.Models.DTOs;
using ChatApp.Application.Dtos.Auths.Requests;

namespace ChatApp.Application.Mappings;

public sealed class UserMappingProfile : Profile
{
    #region Ctor

    public UserMappingProfile()
    {
        CreateMap<RegisterUserRequest, Users>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PassWord));

        CreateMap<Users, UserDto>();

        CreateMap<RegisterRequest, Users>();
    }

    #endregion
}