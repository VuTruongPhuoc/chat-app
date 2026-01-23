using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Common;

namespace ChatApp.Domain.Entities;

[Table("CallParticipants")]
public class CallParticipants : BaseEntity
{
    /// <summary>
    /// Id của người dùng
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Tham gia lúc
    /// </summary>
    public DateTime JoinAt { get; set; }

    /// <summary>
    /// Rời lúc
    /// </summary>
    public DateTime LeftAt { get; set; }

    /// <summary>
    /// Có gửi thông báo không
    /// </summary>
    public bool IsMuted { get; set; }
}
