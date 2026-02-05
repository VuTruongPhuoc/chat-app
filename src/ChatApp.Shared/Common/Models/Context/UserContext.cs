using Common.Models.DTOs;

namespace Common.Models.Context;

public sealed class UserContext : UserDto
{
    #region Methods

    public bool HasRoles(string roleName)
    {
        return Roles != null && Roles.Any(role => role == roleName);
    }

    #endregion
}