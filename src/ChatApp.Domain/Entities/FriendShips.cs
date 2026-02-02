using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Enums;

namespace ChatApp.Domain.Entities;

[Table("FriendShips")]
public class Friendship : Entity<Guid>
{
    #region Fields, Properties

    public Guid UserId { get; set; }

    public Guid FriendId { get; set; }

    public FriendshipStatus Status { get; set; } = FriendshipStatus.Pending;

    public virtual Users User { get; set; } = default!;

    public virtual Users Friend { get; set; } = default!;

    #endregion
}