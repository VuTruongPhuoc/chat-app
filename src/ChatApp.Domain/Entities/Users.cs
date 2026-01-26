using Microsoft.AspNetCore.Identity;

namespace ChatApp.Domain.Entities;

public class Users : IdentityUser<Guid>
{
    #region Fields, Properties

    /// <summary>
    /// Link đường dẫn ảnh
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// Có đang trực tuyến không
    /// </summary>
    public bool IsOnline { get; set; }

    /// <summary>
    /// Thời gian online lần cuối
    /// </summary>
    public DateTime LastSeen { get; set; }

    #endregion
}
