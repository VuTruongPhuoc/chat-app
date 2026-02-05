using ChatApp.Api.Routes;
using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Application.Features.Auths.Commands;
using Common.Constants;
using Common.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Endpoints.Auths;

public sealed class VerifyEmail : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(AuthRoutes.VerifyEmail, HandleEmailVerificationAsync)
            .WithTags(AuthRoutes.Tags)
            .WithName(nameof(VerifyEmail))
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<bool>> HandleEmailVerificationAsync(
        ISender sender,
        [FromBody] VerifyEmailRequest request,
        CancellationToken cancellationToken)
    {
        var command = new VerifyEmailCommand(request, Actor.User(Modules.User));
        var response = await sender.Send(command, cancellationToken);
                    
        return response;
    }
}