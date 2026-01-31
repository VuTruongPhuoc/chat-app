using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities;

[Table("CallParticipants")]
public class CallParticipants : EntityId<Guid>
{
    #region Fields, Properties

    public Guid CallSessionId { get; set; }

    public Guid UserId { get; set; }

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public virtual CallSessions CallSession { get; set; } = default!;
    
    public virtual Users User { get; set; } = default!;

    #endregion
}
