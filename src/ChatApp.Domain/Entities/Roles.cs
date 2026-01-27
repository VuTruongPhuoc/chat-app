using ChatApp.Domain.Constants;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Domain.Entities;

public class Roles : IdentityRole<Guid>
{
    #region Fields, Properties

    /// <summary>
    /// Quyền đối với roles
    /// </summary>
    public List<PermissionConstants> RolePermissions { get; set; } = default!;

    #endregion
}
