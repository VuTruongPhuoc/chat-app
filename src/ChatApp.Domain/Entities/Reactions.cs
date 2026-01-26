using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities;

[Table("Reactions")]
public class Reactions : Entity<Guid>
{
    #region Fields, Properties

    /// <summary>
    /// Id tin nhắn
    /// </summary>
    public Guid MessageId { get; set; }

    /// <summary>
    /// Id người dùng
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Cảm xúc
    /// </summary>
    public string Emoji { get; set; } = default!;

    /// <summary>
    /// phản ứng lúc
    /// </summary>
    public DateTime ReactAt { get; set; } = default!;

    #endregion
}
