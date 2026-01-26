using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Enums;

namespace ChatApp.Domain.Entities;

[Table("RoomMembers")]
public class RoomMembers : Entity<Guid>
{
    #region Fields, Properties

    public Guid RoomId { get; set; }

    public Guid UserId { get; set; }

    public Role Role { get; set; } = Role.Member; // Default role is Member

    public List<int>? permission { get; set; }

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    #endregion
}
