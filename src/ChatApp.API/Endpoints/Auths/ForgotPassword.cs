using ChatApp.Api.Routes;
using ChatApp.Application.Features.Auths.Commands;
using Common.Constants;
using Common.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Endpoints.Auths;

public sealed class ForgotPassword : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(AuthRoutes.ForgotPassword, HandleForgotPasswordAsync)
            .WithTags(AuthRoutes.Tags)
            .WithName(nameof(ForgotPassword))
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .AllowAnonymous();
    }

    private async Task<ApiResponse> HandleForgotPasswordAsync(
        ISender sender,
        [FromBody] string email,
        CancellationToken cancellationToken)
    {
        var command = new ForgotPasswordCommand(email, Actor.User(Modules.User));
        var response = await sender.Send(command, cancellationToken);
                    
        return response;
    }
}