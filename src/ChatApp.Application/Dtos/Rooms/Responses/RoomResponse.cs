using ChatApp.Domain.Enums;

namespace ChatApp.Application.Dtos.Rooms.Responses;

public sealed class RoomResponse : EntityId<Guid>
{
    public string? Name { get; set; }
 
    public string? Description { get; set; }

    public RoomType Type { get; set; }

    public bool IsPrivate { get; set; }
}