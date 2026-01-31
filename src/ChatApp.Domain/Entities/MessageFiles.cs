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
    /// Tên file
    /// </summary>
    public string FileName { get; set; } = default!;

    /// <summary>
    /// Link file
    /// </summary>
    public string Url { get; set; } = default!;

    /// <summary>
    /// Đuôi file
    /// </summary>
    public string Ext { get; set; } = default!;

    /// <summary>
    /// Kích cỡ file
    /// </summary>
    public long Size { get; set; }

    public virtual Messages Message { get; set; } = default!;

    public virtual Users User { get; set; } = default!;

    #endregion
}
