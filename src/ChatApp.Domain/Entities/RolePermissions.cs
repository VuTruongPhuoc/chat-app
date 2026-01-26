namespace ChatApp.Domain.Entities;

public class RolePermissions : Entity<Guid>
{
    #region Fields, Properties

    /// <summary>
    /// Id vai trò
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// Tên vai trò
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Liên kết với Roles
    /// </summary>
    public Roles roles { get; set; } = default!;

    #endregion
}
