using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities;

[Table("CallSessions")]
public class CallSessions : EntityId<Guid>
{
    #region Fields, Properties

    /// <summary>
    /// Id phòng họp
    /// </summary>
    public Guid RoomId { get; set; }

    /// <summary>
    /// Kết thúc lúc
    /// </summary>
    public DateTime EndedAt { get; set; }

    /// <summary>
    /// Liên kết tới bảng rooms
    /// </summary>
    public Rooms Rooms { get; set; } = default!;

    #endregion
}
