using Common.ValueObjects;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Rooms.Commands;
using ChatApp.Application.Dtos.Rooms.Requests;
using ChatApp.Infrastructure.Extensions.Identity;

namespace ChatApp.Api.Endpoints.Rooms;

public sealed class UpdateRoom : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(RoomRoutes.Update, UpdateRoomAsync)
            .WithTags(RoomRoutes.Tags)
            .WithName(nameof(UpdateRoom))
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<Guid>> UpdateRoomAsync(
        ISender sender,
        [FromServices] HttpContextAccessor httpContextAccessor,
        [FromQuery] Guid id,
        [FromBody] UpsertRoomRequest request,
        CancellationToken cancellationToken)
    {
        var currentUser = httpContextAccessor.GetCurrentUser();
        var command = new UpdateRoomCommand(id, request, Actor.User(currentUser.Email));
        var response = await sender.Send(command, cancellationToken);
        
        return ApiResponse<Guid>.Success(response);
    }
}
