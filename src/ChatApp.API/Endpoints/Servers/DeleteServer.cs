using Common.ValueObjects;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Servers.Commands;
using ChatApp.Infrastructure.Extensions.Identity;

namespace ChatApp.Api.Endpoints.Servers;

public sealed class DeleteServer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(ServerRoutes.Delete, DeleteServerAsync)
            .WithTags(ServerRoutes.Tags)
            .WithName(nameof(DeleteServer))
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<bool>> DeleteServerAsync(
        ISender sender,
        [FromServices] HttpContextAccessor httpContextAccessor,
        [FromQuery] Guid id,
        CancellationToken cancellationToken)
    {
        var currentUser = httpContextAccessor.GetCurrentUser();
        var command = new DeleteServerCommand(id, Actor.User(currentUser.Email));
        var response = await sender.Send(command, cancellationToken);
        
        return ApiResponse<bool>.Success(response);
    }
}
