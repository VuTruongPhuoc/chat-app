using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Common;

namespace ChatApp.Domain.Entities;

[Table("Reactions")]
public class Reactions : BaseEntity
{
    /// <summary>
    /// Id tin nhắn
    /// </summary>
    public long MessageId { get; set; }

    /// <summary>
    /// Id người dùng
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Cảm xúc
    /// </summary>
    public string Emoji { get; set; } = default!;

    /// <summary>
    /// phản ứng lúc
    /// </summary>
    public DateTime ReactAt { get; set; } = default!;
}
