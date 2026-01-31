using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities;

[Table("Notifications")]
public class Notifications : Entity<Guid>
{
    #region Fields, Properties

    public Guid ReceiverId { get; set; }

    public Guid? SenderId { get; set; }  
    
    public string Title { get; set; } = default!;

    public string Content { get; set; } = default!;
    
    public NotificationType Type { get; set; }

    public bool IsRead { get; set; } = false;

    /// <summary>
    /// Link tới thực thể liên quan (ví dụ ID của Room hoặc ID của User) 
    /// </summary>
    
    public Guid? EntityId { get; set; } 

    public virtual Users Receiver { get; set; } = default!;

    #endregion
}
