using ChatApp.Application.Features.Auth.Commands;
using ChatApp.Domain.Repositories;
using Common.Models.Responses;
using MediatR;

namespace ChatApp.Application.Features.Auth.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse>
{
    #region Fields, Properties

    private readonly IIdentityRepository _identityRepository;

    #endregion

    #region Ctors

    public LoginCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    #endregion

    public async Task<ApiResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        return await _identityRepository.LoginAsync(command.request, cancellationToken);
    }
}