using ChatApp.Api.Routes;
using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Application.Features.Auths.Commands;
using Common.Constants;
using Common.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Endpoints.Auths;

public sealed class ResetPassword : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(AuthRoutes.ResetPassword, HandleResetPasswordAsync)
            .WithTags(AuthRoutes.Tags)
            .WithName(nameof(ResetPassword))
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .AllowAnonymous();
    }

    private async Task<ApiResponse> HandleResetPasswordAsync(
        ISender sender,
        [FromBody] ResetPasswordRequest request,
        CancellationToken cancellationToken)
    {
        var command = new ResetPasswordCommand(request, Actor.User(Modules.User));
        var response = await sender.Send(command, cancellationToken);
                    
        return response;
    }
}