using System.ComponentModel;

namespace ChatApp.Domain.Enums;

public enum RoomType
{
    [Description("Public Room")]
    Public = 0,
    [Description("Private Room")]
    Private = 1,
    [Description("Group Room")]
    Group = 2
}
