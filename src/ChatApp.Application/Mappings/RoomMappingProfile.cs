using AutoMapper;

namespace ChatApp.Application.Mappings;

public sealed class RoomMappingProfile : Profile
{
    #region Ctors

    public RoomMappingProfile()
    {
        CreateMap<Dtos.Rooms.Requests.UpsertRoomRequest, Domain.Entities.Rooms>();
        CreateMap<Domain.Entities.Rooms, Dtos.Rooms.Responses.RoomResponse>();
    }

    #endregion
}