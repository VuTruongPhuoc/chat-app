using ChatApp.Application.Dtos.Emails;

namespace ChatApp.Application.Services;

public interface IEmailService
{
    Task<EmailResponse> SendEmailAsync(EmailRequest request, CancellationToken cancellationToken = default);
}