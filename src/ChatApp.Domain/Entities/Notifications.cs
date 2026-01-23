using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Common;

namespace ChatApp.Domain.Entities;

[Table("Notifications")]
public class Notifications : BaseEntity
{
    /// <summary>
    /// Id người dùng
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Nội dung thông báo
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Đã đọc chưa
    /// </summary>
    public bool IsRead { get; set; }
}
