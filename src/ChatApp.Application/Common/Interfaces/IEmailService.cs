using ChatApp.Application.Dtos.Emails;

namespace ChatApp.Application.Common.Interfaces;

public interface IEmailService
{
    Task<EmailResponse> SendEmailAsync(EmailRequest request, CancellationToken cancellationToken = default);
}