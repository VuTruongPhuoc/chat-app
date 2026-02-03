using ChatApp.Application.Features.Auths.Commands;
using ChatApp.Domain.Services;
using Common.Models.Responses;
using MediatR;

namespace ChatApp.Application.Features.Auth.Handlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ApiResponse>
{
    #region Fields, Properties

    private readonly IIdentityService _identityService;

    #endregion

    #region Ctors

    public RegisterCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    #endregion

    public async Task<ApiResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        return await _identityService.RegisterAsync(command.request, cancellationToken);
    }
}
