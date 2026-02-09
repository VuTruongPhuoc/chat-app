using AutoMapper;

namespace ChatApp.Application.Mappings;

public sealed class ServerMappingProfile : Profile
{
    #region Ctors

    public ServerMappingProfile()
    {
        CreateMap<Dtos.Servers.Requests.UpsertServerRequest, Domain.Entities.Servers>();
        CreateMap<Domain.Entities.Servers, Dtos.Servers.Responses.ServerResponse>();
    }

    #endregion
}
