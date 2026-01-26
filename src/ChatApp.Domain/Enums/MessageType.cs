using System.ComponentModel;

namespace ChatApp.Domain.Enums;

public enum MessageType
{
    [Description("Text Message")]
    Text = 0,
    [Description("Image Message")]
    Image = 1,
    [Description("File Message")]
    File = 2,
    [Description("Video Message")]
    Video = 3,
    [Description("System Message")]
    System = 4
}
