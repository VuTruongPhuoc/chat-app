using Microsoft.AspNetCore.Identity;

namespace ChatApp.Infrastructure.Identity;

public class Roles : IdentityRole<Guid>
{
    /// <summary>
    /// Liên kết tới role permission
    /// </summary>
    public IEnumerable<RolePermissions> RolePermissions { get; set; } = default!;
}
