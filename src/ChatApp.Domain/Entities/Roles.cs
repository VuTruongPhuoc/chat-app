using Microsoft.AspNetCore.Identity;

namespace ChatApp.Domain.Entities;

public class Roles : IdentityRole<Guid>
{
    #region Fields, Properties

    /// <summary>
    /// Liên kết tới role permission
    /// </summary>
    public IEnumerable<RolePermissions> RolePermissions { get; set; } = default!;

    #endregion
}
