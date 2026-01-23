using ChatApp.Domain.Common;

namespace ChatApp.Infrastructure.Identity;

public class RolePermissions : BaseEntity
{
    /// <summary>
    /// Id vai trò
    /// </summary>
    public long RoleId { get; set; }

    /// <summary>
    /// Tên vai trò
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Liên kết với Roles
    /// </summary>
    public Roles roles { get; set; } = default!;
}
