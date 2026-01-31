using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Enums;

namespace ChatApp.Domain.Entities;

[Table("Messages")]
public class Messages : Entity<Guid>
{
    #region Fields, Properties
    
    /// <summary>
    /// The user who sent the message.        
    /// </summary>           
    public Guid SenderId { get; set; }

    /// <summary>
    /// The room where the message was sent.
    /// </summary>
    public Guid RoomId { get; set; }

    /// <summary>
    /// Content of the message.
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Type of the message
    /// </summary>
    public MessageType MessageType { get; set; } = MessageType.Text;

    /// <summary>
    /// The message is replied
    /// </summary>
    public Guid? ReplyToId { get; set; }

    /// <summary>
    /// The message edited
    /// </summary>
    public bool IsEdited { get; set; }

    /// <summary>
    /// The message is deleted
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// The message is pinned
    /// </summary>
    public bool IsPinned { get; set; } = false;

    public virtual Users Sender { get; set; } = default!;
    
    public virtual Rooms Room { get; set; } = default!;

    #endregion
}