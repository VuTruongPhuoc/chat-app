using ChatApp.Api.Routes;
using ChatApp.Application.Features.Auths.Commands;
using ChatApp.Infrastructure.Extensions.Identity;
using Common.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Endpoints.Auths;

public sealed class ResentVerificationEmail : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(AuthRoutes.ResentVerificationEmail, HandleResentVerificationEmailAsync)
            .WithTags(AuthRoutes.Tags)
            .WithName(nameof(ResentVerificationEmail))
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .AllowAnonymous();
    }

    private async Task<ApiResponse> HandleResentVerificationEmailAsync(
        ISender sender,
        [FromBody] string email,
        IHttpContextAccessor httpContextAccessor,
        CancellationToken cancellationToken)
    {
        var currentUser = httpContextAccessor.GetCurrentUser();
        var command = new ResentVerificationEmailCommand(email, Actor.User(currentUser.Id));
        var response = await sender.Send(command, cancellationToken);
                    
        return response;
    }
}