using AutoMapper;
using ChatApp.Application.Features.Users.Commands;
using MediatR;

namespace ChatApp.Application.Features.Users.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    #region Fields, Properties

    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    #endregion

    #region Ctors

    public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    #endregion

    #region Methods

    public async Task<Guid> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Domain.Entities.Users>(command.request);
        return await _userRepository.RegisterUserAsync(user, cancellationToken);
    }

    #endregion
}