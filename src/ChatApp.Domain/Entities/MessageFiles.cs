using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Common;

namespace ChatApp.Domain.Entities;

[Table("MessageFiles")]
public class MessageFiles : BaseEntity
{
    /// <summary>
    /// Id tin nhắn
    /// </summary>
    public long MessageId { get; set; }

    /// <summary>
    /// Link file
    /// </summary>
    public string Url { get; set; } = default!;

    /// <summary>
    /// Đuôi file
    /// </summary>
    public string ext { get; set; } = default!;

    /// <summary>
    /// Kích cỡ file
    /// </summary>
    public long size { get; set; }
}
