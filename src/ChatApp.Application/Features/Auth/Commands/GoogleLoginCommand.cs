using ChatApp.Application.Dtos.Auths.Responses;
using Common.ValueObjects;
using MediatR;

namespace ChatApp.Application.Features.Auth.Commands;

public record GoogleLoginCommand(GoogleLoginRequest request, Actor actor) : IRequest<GoogleLoginResponse>;