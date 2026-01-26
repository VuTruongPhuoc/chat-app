using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Domain.Entities;

[Table("MessageFiles")]
public class MessageFiles : Entity<Guid>
{
    #region Fields, Properties
    
    /// <summary>
    /// Id tin nhắn
    /// </summary>
    public Guid MessageId { get; set; }

    /// <summary>
    /// Link file
    /// </summary>
    public string Url { get; set; } = default!;

    /// <summary>
    /// Đuôi file
    /// </summary>
    public string ext { get; set; } = default!;

    /// <summary>
    /// Kích cỡ file
    /// </summary>
    public long size { get; set; }

    #endregion
}
