using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Enums;

namespace ChatApp.Domain.Entities;

[Table("RoomMembers")]
public class RoomMembers
{
    #region Fields, Properties

    public Guid UserId { get; set; }

    public Guid RoomId { get; set; }

    public string? Nickname { get; set; }

    /// <summary>
    /// Lưu ID tin nhắn cuối cùng mà User này đã đọc
    /// </summary>
    public Guid? LastReadMessageId { get; set; }

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public virtual Users User { get; set; } = default!;

    public virtual Rooms Room { get; set; } = default!;

    #endregion
}
