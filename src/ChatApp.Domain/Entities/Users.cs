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

    /// <summary>
    /// Nhận token mới khi hết hạn
    /// </summary>
    public string? RefreshToken { get; set; } = default!;

    /// <summary>
    /// Thời gian token hết hạn
    /// </summary>
    public DateTime RefreshTokenExpiry { get; set; } = default!;

    #endregion
}
