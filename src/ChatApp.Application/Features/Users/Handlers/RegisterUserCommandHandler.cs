using ChatApp.Application.Features.Users.Commands;
using ChatApp.Domain.Entities;
using MediatR;

namespace ChatApp.Application.Features.Users.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Guid> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.Users
        {
            UserName = command.request.UserName,
            Email = command.request.Email,
            PasswordHash = command.request.Password,
            AvatarUrl = command.request.AvatarUrl
        };
        return await _userRepository.RegisterUserAsync(user, cancellationToken);
    }
}