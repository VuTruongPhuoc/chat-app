using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities;

[Table("Notifications")]
public class Notifications : Entity<Guid>
{
    #region Fields, Properties

    /// <summary>
    /// Id người dùng
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Nội dung thông báo
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Đã đọc chưa
    /// </summary>
    public bool IsRead { get; set; }

    #endregion
}
