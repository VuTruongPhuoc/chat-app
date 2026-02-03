using ChatApp.Application.Features.Auths.Commands;
using ChatApp.Domain.Services;
using Common.Models.Responses;
using MediatR;

namespace ChatApp.Application.Features.Auth.Handlers;


public sealed class ResetPasswordCommandHandler(IIdentityService identityService) : IRequestHandler<ResetPasswordCommand, ApiResponse>
{
    public Task<ApiResponse> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
    {
        return identityService.ResetPasswordAsync(command.request, cancellationToken);
    }
}