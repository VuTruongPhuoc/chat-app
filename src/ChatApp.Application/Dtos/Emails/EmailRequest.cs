namespace ChatApp.Application.Dtos.Emails;

public sealed class EmailRequest
{
    #region Fields, Properties

    public Guid? UserId { get; set; } = default!;
    
    public IReadOnlyCollection<string> To { get; set; } = default!;
    
    public IReadOnlyCollection<string>? Cc { get; set; } = default!;
    
    public string Subject { get; set; } = default!;
    
    public string Body { get; set; } = default!;

    public bool IsBodyHtml { get; set; } = false;

    #endregion

    #region Methods

    public static EmailRequest Create(Domain.Entities.Users user, string subject, string body)
        => new EmailRequest
        {
            To = [user.Email!],
            Subject = subject,
            Body = body,
            IsBodyHtml = true,
            UserId = user.Id
        }; 
    

    #endregion
}