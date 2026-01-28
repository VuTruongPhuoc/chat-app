using Common.ValueObjects;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Dtos.Auths.Responses;
using ChatApp.Application.Features.Auth.Commands;

namespace ChatApp.Api.Endpoints.Auths;

public sealed class GoogleLogin : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(AuthRoutes.GoogleLogin, HandleGoogleLoginAsync)
            .WithTags(AuthRoutes.Tags)
            .WithName(nameof(GoogleLogin))
            .Produces<GoogleLoginResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .AllowAnonymous();
    }

    private async Task<GoogleLoginResponse> HandleGoogleLoginAsync(
        ISender sender,
        [FromBody] GoogleLoginRequest request,
        CancellationToken cancellationToken)
    {
        var command = new GoogleLoginCommand(request, Actor.System(Modules.User));
        var response = await sender.Send(command, cancellationToken);
        
        return response;
    }
}