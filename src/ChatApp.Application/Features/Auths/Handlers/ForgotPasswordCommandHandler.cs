using ChatApp.Application.Features.Auths.Commands;
using ChatApp.Domain.Services;
using Common.Models.Responses;
using MediatR;

namespace ChatApp.Application.Features.Auth.Handlers;

public sealed class ForgotPasswordCommandHandler(IIdentityService identityService) : IRequestHandler<ForgotPasswordCommand, ApiResponse>
{
    public Task<ApiResponse> Handle(ForgotPasswordCommand command, CancellationToken cancellationToken)
    {
        return identityService.ForgotPasswordAsync(command.Email, cancellationToken);
    }
}