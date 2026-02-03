using ChatApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Domain.Entities;

public class Roles : IdentityRole<Guid>
{
    #region Fields, Properties

    /// <summary>
    /// Quyền đối với servers
    /// </summary>
    public ServerPermissions Permissions { get; set; } = default!;

    #endregion
}
