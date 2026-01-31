using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities;

[Table("ServerMembers")]
public class ServerMembers
{
    #region Fields, Properties

    public Guid ServerId { get; set; }

    public Guid UserId { get; set; }

    public string NickName { get; set; } = default!;

    public DateTime? JoinAt { get; set; }

    public virtual Servers Server { get; set; } = default!;

    public virtual Users User { get; set; } = default!;

    #endregion
}