using ChatApp.Domain.Enums;

namespace ChatApp.Application.Dtos.Rooms.Requests;

public class UpsertRoomRequest
{   
    #region Fields, Properties


    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public RoomType Type { get; set; } = RoomType.Personal;

    public bool IsPrivate { get; set; } = false;

    #endregion
}