using Common.ValueObjects;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Rooms.Commands;
using ChatApp.Infrastructure.Extensions.Identity;

namespace ChatApp.Api.Endpoints.Rooms;

public sealed class DeleteRoom : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(RoomRoutes.Delete, DeleteRoomAsync)
            .WithTags(RoomRoutes.Tags)
            .WithName(nameof(DeleteRoom))
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<bool>> DeleteRoomAsync(
        ISender sender,
        [FromServices] HttpContextAccessor httpContextAccessor,
        [FromQuery] Guid id,
        CancellationToken cancellationToken)
    {
        var currentUser = httpContextAccessor.GetCurrentUser();
        var command = new DeleteRoomCommand(id, Actor.User(currentUser.Email));
        var response = await sender.Send(command, cancellationToken);
        
        return ApiResponse<bool>.Success(response);
    }
}
