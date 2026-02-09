using Common.ValueObjects;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Servers.Commands;
using ChatApp.Application.Dtos.Servers.Requests;
using ChatApp.Infrastructure.Extensions.Identity;

namespace ChatApp.Api.Endpoints.Servers;

public sealed class CreateServer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(ServerRoutes.Create, CreateServerAsync)
            .WithTags(ServerRoutes.Tags)
            .WithName(nameof(CreateServer))
            .Produces<ApiResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<Guid>> CreateServerAsync(
        ISender sender,
        [FromServices] HttpContextAccessor httpContextAccessor,
        [FromBody] UpsertServerRequest request,
        CancellationToken cancellationToken)
    {
        var currentUser = httpContextAccessor.GetCurrentUser();
        var command = new CreateServerCommand(request, Actor.User(currentUser.Email));
        var response = await sender.Send(command, cancellationToken);
        
        return ApiResponse<Guid>.Success(response);
    }
}
