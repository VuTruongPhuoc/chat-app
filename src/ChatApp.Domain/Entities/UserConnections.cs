using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities;

[Table("UserConnections")]
public class UserConnection : Entity<Guid>
{
    public Guid UserId { get; set; }
    
    public string ConnectionId { get; set; } = default!;
    
    /// <summary>
    /// Ví dụ: Chrome, iOS App...
    /// </summary>
    public string? UserAgent { get; set; }
    
    public DateTime ConnectedAt { get; set; } = DateTime.UtcNow;

    public virtual Users User { get; set; } = default!;
}