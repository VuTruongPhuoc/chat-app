using ChatApp.Application.Dtos.Auths.Requests;
using Common.ValueObjects;
using Common.Constants;
using Common.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Auths.Commands;

namespace ChatApp.Api.Endpoints.Auths;

public sealed class Login : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(AuthRoutes.Login, HandleLoginAsync)
        .WithTags(AuthRoutes.Tags)
        .WithName(nameof(Login))
        .Produces<ApiLoginResponse<UserDto>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status401Unauthorized)
        .AllowAnonymous();
    }

    private async Task<ApiResponse> HandleLoginAsync(
        ISender sender,
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken)
    {
        var command = new LoginCommand(request, Actor.System(Modules.User));
        var response = await sender.Send(command, cancellationToken);
        
        return response;
    }
}