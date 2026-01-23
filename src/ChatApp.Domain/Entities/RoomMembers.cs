using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Common;
using ChatApp.Domain.Enums;

namespace ChatApp.Domain.Entities;

[Table("RoomMembers")]
public class RoomMembers : BaseEntity
{
    public long RoomId { get; set; }
    public long UserId { get; set; }
    public Role Role { get; set; } = Role.Member; // Default role is Member
    public List<int>? permission { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}
