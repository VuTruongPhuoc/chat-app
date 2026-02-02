namespace ChatApp.Application.Dtos.Emails;

public sealed class EmailOptions
{
    #region Fields, Properties

    public const string Section = "EmailSettings";

    public string StmpHost { get; set; } = default!;
    
    public int StmpPort { get; set; } = default!;
    
    public string FromAddress { get; set; } = default!;
    
    public string FromName { get; set; } = default!;

    public string PassWord { get; set; } = default!;

    public bool EnableSsl { get; set; } = default!;
    
    public int TimeoutMs { get; set; } = default!;

    #endregion   
}