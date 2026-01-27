using ChatApp.Application.Features.Auth.Commands;
using ChatApp.Domain.Repositories;
using Common.Models.Responses;
using MediatR;

namespace ChatApp.Application.Features.Auth.Handlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ApiResponse>
{
    #region Fields, Properties

    private readonly IIdentityRepository _identityRepository;

    #endregion

    #region Ctors

    public RegisterCommandHandler(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    #endregion

    public async Task<ApiResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        return await _identityRepository.RegisterAsync(command.request, cancellationToken);
    }
}
