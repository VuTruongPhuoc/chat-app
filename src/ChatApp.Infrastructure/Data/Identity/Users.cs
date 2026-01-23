using Microsoft.AspNetCore.Identity;

namespace ChatApp.Infrastructure.Identity;

public class Users : IdentityUser<Guid>
{
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
}
