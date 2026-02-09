using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Rooms.Queries;
using ChatApp.Application.Dtos.Rooms.Responses;

namespace ChatApp.Api.Endpoints.Rooms;

public sealed class GetRoom : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(RoomRoutes.GetById, GetRoomAsync)
            .WithTags(RoomRoutes.Tags)
            .WithName(nameof(GetRoom))
            .Produces<ApiResponse<RoomResponse>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<RoomResponse>> GetRoomAsync(
        ISender sender,
        [FromQuery] Guid id,
        CancellationToken cancellationToken)
    {
        var query = new GetRoomQuery(id);
        var response = await sender.Send(query, cancellationToken);
        
        return ApiResponse<RoomResponse>.Success(response);
    }
}
