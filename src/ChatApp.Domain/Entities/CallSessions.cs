using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Common;

namespace ChatApp.Domain.Entities;

[Table("CallSessions")]
public class CallSessions : BaseEntity
{
    /// <summary>
    /// Id phòng họp
    /// </summary>
    public long RoomId { get; set; }

    /// <summary>
    /// Kết thúc lúc
    /// </summary>
    public DateTime EndedAt { get; set; }

    /// <summary>
    /// Liên kết tới bảng rooms
    /// </summary>
    public Rooms Rooms { get; set; } = default!;
}
