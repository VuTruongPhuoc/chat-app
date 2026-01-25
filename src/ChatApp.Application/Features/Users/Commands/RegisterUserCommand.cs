using ChatApp.Application.Dtos.Users;
using MediatR;

namespace ChatApp.Application.Features.Users.Commands;

public record RegisterUserCommand(RegisterUserRequest request) : IRequest<Guid>;