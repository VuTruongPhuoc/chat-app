using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Common;
using ChatApp.Domain.Enums;

namespace ChatApp.Domain.Entities;

[Table("Messages")]
public class Messages : BaseEntity
{
    /// <summary>
    /// The user who sent the message.        
    /// </summary>           
    public long UserId { get; set; }

    /// <summary>
    /// The room where the message was sent.
    /// </summary>
    public long RoomId { get; set; }

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
    public long? ReplyToId { get; set; }

    /// <summary>
    /// The message edited
    /// </summary>
    public bool IsEdited { get; set; }


    /// <summary>
    /// The message is deleted
    /// </summary>
    public bool IsDeleted { get; set; }
}