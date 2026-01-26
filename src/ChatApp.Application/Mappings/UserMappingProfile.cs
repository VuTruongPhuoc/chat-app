using AutoMapper;
using ChatApp.Application.Dtos.Users;
using ChatApp.Domain.Entities;

namespace ChatApp.Application.Mappings;

public sealed class UserMappingProfile : Profile
{
    #region Ctor

    public UserMappingProfile()
    {
        CreateMap<RegisterUserRequest, Users>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
    }

    #endregion
}