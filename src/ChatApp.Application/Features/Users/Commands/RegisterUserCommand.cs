using ChatApp.Application.Dtos.Users;
using Common.ValueObjects;
using MediatR;

namespace ChatApp.Application.Features.Users.Commands;

public record RegisterUserCommand(RegisterUserRequest request, Actor actor) : IRequest<Guid>;