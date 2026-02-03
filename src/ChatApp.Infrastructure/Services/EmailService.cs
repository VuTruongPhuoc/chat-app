using MailKit.Net.Smtp;
using ChatApp.Application.Dtos.Emails;
using ChatApp.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ChatApp.Infrastructure.Services;

public class EmailService(IOptions<EmailOptions> emailOptions) : IEmailService
{
    #region Methods public

    public async Task<EmailResponse> SendEmailAsync(EmailRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            using var smtpClient = await CreateSmtpClientAsync(cancellationToken);
            using var message = CreateMailMessage(request);

            await smtpClient.SendAsync(message, cancellationToken);

            await smtpClient.DisconnectAsync(true, cancellationToken);

            return EmailResponse.Success();
        }
        catch (Exception ex)
        {
            return EmailResponse.Error(ex.Message);
        }
    }

    #endregion

    #region Methods private

    private async Task<SmtpClient> CreateSmtpClientAsync(CancellationToken cancellationToken = default)
    {
        var smtpClient = new SmtpClient();
        smtpClient.Timeout = emailOptions.Value.TimeoutMs;

        try
        {
            var socketOption = emailOptions.Value.EnableSsl 
                ? MailKit.Security.SecureSocketOptions.StartTls 
                : MailKit.Security.SecureSocketOptions.None;

            await smtpClient.ConnectAsync(
                emailOptions.Value.StmpHost, 
                emailOptions.Value.StmpPort, 
                socketOption, 
                cancellationToken);

            await smtpClient.AuthenticateAsync(
                emailOptions.Value.FromAddress, 
                emailOptions.Value.PassWord, 
                cancellationToken);
                
            return smtpClient;
        }
        catch (Exception ex)
        {
            smtpClient.Dispose(); 
            throw new Exception($"Email Connection Error: {ex.Message}");
        }
    }

    private MimeMessage CreateMailMessage(EmailRequest request)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(emailOptions.Value.FromName, emailOptions.Value.FromAddress));
        
        message.To.AddRange(request.To.Select(MailboxAddress.Parse));
        
        if (request.Cc != null && request.Cc.Any())
        {
            message.Cc.AddRange(request.Cc.Select(MailboxAddress.Parse));
        }

        message.Subject = request.Subject;
        
        var bodyBuilder = new BodyBuilder();

        if (request.IsBodyHtml) 
        {
            bodyBuilder.HtmlBody = request.Body;
        }
        else 
        {
            bodyBuilder.TextBody = request.Body;
        }
        
        message.Body = bodyBuilder.ToMessageBody();

        return message;
    }

    #endregion
}