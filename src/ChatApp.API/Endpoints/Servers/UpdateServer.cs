using Common.ValueObjects;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Servers.Commands;
using ChatApp.Application.Dtos.Servers.Requests;
using ChatApp.Infrastructure.Extensions.Identity;

namespace ChatApp.Api.Endpoints.Servers;

public sealed class UpdateServer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(ServerRoutes.Update, UpdateServerAsync)
            .WithTags(ServerRoutes.Tags)
            .WithName(nameof(UpdateServer))
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<Guid>> UpdateServerAsync(
        ISender sender,
        [FromServices] HttpContextAccessor httpContextAccessor,
        [FromQuery] Guid id,
        [FromBody] UpsertServerRequest request,
        CancellationToken cancellationToken)
    {
        var currentUser = httpContextAccessor.GetCurrentUser();
        var command = new UpdateServerCommand(id, request, Actor.User(currentUser.Email));
        var response = await sender.Send(command, cancellationToken);
        
        return ApiResponse<Guid>.Success(response);
    }
}
