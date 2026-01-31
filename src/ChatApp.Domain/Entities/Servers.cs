using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities;

[Table("Servers")]
public class Servers : Entity<Guid>
{
    #region Fields, Properties

    public string Name { get; set; } = default!;

    public Guid OwnerId { get; set; }

    public string? Metadata { get; set; }

    #endregion
}