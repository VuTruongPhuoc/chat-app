using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities;

[Table("MemberRoles")]
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
    /// Id server
    /// </summary>
    public Guid ServerId { get; set; }

    public virtual Roles Role { get; set; } = default!;

    public virtual Users User { get; set; } = default!;

    public virtual Servers Server { get; set; } = default!;

    #endregion
}
