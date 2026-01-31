using System.ComponentModel.DataAnnotations.Schema;
using ChatApp.Domain.Enums;

namespace ChatApp.Domain.Entities;

[Table("Rooms")]
public class Rooms : Entity<Guid>
{
    #region Fields, Properties

    /// <summary>
    /// Name of the room.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Description of the room.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Type of the room Personal, Group.
    /// </summary>
    public RoomType Type { get; set; } = RoomType.Personal;

    /// <summary>
    /// Indicates if the room is private.
    /// If true, only invited members can join.
    /// If false, the room is public and anyone can join.
    /// </summary>
    public bool IsPrivate { get; set; } = false;

    public virtual List<RoomMembers> Members { get; set; } = new List<RoomMembers>();
    
    public virtual List<Messages> Messages { get; set; } = new List<Messages>();

    #endregion
}