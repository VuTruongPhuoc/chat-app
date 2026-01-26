using System.ComponentModel;

namespace ChatApp.Domain.Enums;

public enum Role
{
    [Description("Room Owner")]
    Owner = 0,
    [Description("Admin")]
    Admin = 1,
    [Description("Member")]
    Member = 2,
    [Description("Guest")]
    Guest = 3
}
