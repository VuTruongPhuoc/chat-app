using ChatApp.Application.Features.Auths.Commands;
using ChatApp.Domain.Services;
using Common.Models.Responses;
using MediatR;

namespace ChatApp.Application.Features.Auth.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse>
{
    #region Fields, Properties

    private readonly IIdentityService _identityService;

    #endregion

    #region Ctors

    public LoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    #endregion

    public async Task<ApiResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        return await _identityService.LoginAsync(command.request, cancellationToken);
    }
}