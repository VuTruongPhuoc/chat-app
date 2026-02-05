using ChatApp.Api.Routes;
using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Application.Features.Auths.Commands;
using Common.Constants;
using Common.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Endpoints.Auths;

public sealed class EmailVerification : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(AuthRoutes.EmailVerification, HandleEmailVerificationAsync)
            .WithTags(AuthRoutes.Tags)
            .WithName(nameof(EmailVerification))
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .RequireAuthorization();
    }

    private async Task<bool> HandleEmailVerificationAsync(
        ISender sender,
        [FromBody] EmailVerificationRequest request,
        CancellationToken cancellationToken)
    {
        var command = new EmailVerificationCommand(request, Actor.User(Modules.User));
        var response = await sender.Send(command, cancellationToken);
                    
        return response;
    }
}