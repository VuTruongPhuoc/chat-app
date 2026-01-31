using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Domain.Entities;

[Table("Users")]
public class Users : IdentityUser<Guid>
{
    #region Fields, Properties

    /// <summary>
    /// Tên hiển thị của người dùng
    /// </summary>
    public string DisplayName { get; set; } = default!;

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

    /// <summary>
    /// Trạng thái xác thực email của người dùng
    /// </summary>
    public bool EmailVerified { get; set; } = false;

    /// <summary>
    /// Thời gian người dùng xác thực email
    /// </summary>
    public DateTime? EmailVerifiedAt { get; set; }

    /// <summary>
    /// Trạng thái người dùng đang online, offline, busy
    /// </summary>
    public UserStatus UserStatus { get; set; }

    /// <summary>
    /// Trạng thái tài khoản hoạt động, chờ xác thực, khóa
    /// </summary>
    public AccountStatus AccountStatus { get; set; }

    public virtual ICollection<RoomMembers> RoomMembers { get; set; } = new List<RoomMembers>();

    public virtual ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();

    public virtual ICollection<UserConnection> Connections { get; set; } = new List<UserConnection>();

    #endregion
}
