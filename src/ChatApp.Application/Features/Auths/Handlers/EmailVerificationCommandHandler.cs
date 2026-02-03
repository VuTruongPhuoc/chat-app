using ChatApp.Application.Features.Auths.Commands;
using ChatApp.Domain.Services;
using MediatR;

namespace ChatApp.Application.Features.Auth.Handlers;

public sealed class EmailVerificationCommandHandler(IIdentityService identityService) : IRequestHandler<EmailVerificationCommand, bool>
{
    public Task<bool> Handle(EmailVerificationCommand command, CancellationToken cancellationToken)
    {
        return identityService.EmailVerificationAsync(command.request, cancellationToken);
    }
}