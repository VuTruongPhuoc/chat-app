namespace ChatApp.Domain.Entities;

public class UserRoles
{
    #region Fields, Properties

    /// <summary>
    /// Id vai trò
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// Id người dùng
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Liên kết với Roles
    /// </summary>
    public Roles roles { get; set; } = default!;

    /// <summary>
    /// Liên kết với Permissions
    /// </summary>
    public Users users { get; set; } = default!;

    #endregion
}
