using ChatApp.Domain.Enums;

namespace ChatApp.Application.Dtos.Rooms.Responses;

public sealed class GetAllRoomsResponse
{
    #region Fields, Properties

    public List<RoomResponse>? Rooms { get; init; } = new();

    #endregion

    #region Ctors

    public GetAllRoomsResponse(List<RoomResponse> rooms)
    {
        Rooms = rooms;
    }

    #endregion
}