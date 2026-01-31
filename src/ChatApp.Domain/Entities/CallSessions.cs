using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Enums;

namespace ChatApp.Domain.Entities;

[Table("CallSessions")]
public class CallSessions : EntityId<Guid>
{
    #region Fields, Properties

    public Guid RoomId { get; set; }
    
    public CallType Type { get; set; }
    
    public CallStatus Status { get; set; }
    
    public DateTime? EndAt { get; set; }

    public virtual Rooms Room { get; set; } = default!;

    public virtual List<CallParticipants> Participants { get; set; } = new List<CallParticipants>();

    #endregion
}
