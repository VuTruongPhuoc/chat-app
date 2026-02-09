using Common.Constants;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Rooms.Queries;
using ChatApp.Application.Dtos.Rooms.Responses;

namespace ChatApp.Api.Endpoints.Rooms;

public sealed class GetAllRooms : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(RoomRoutes.Get, GetAllRoomsAsync)
            .WithTags(RoomRoutes.Tags)
            .WithName(nameof(GetAllRooms))
            .Produces<ApiResponse<List<GetAllRoomsResponse>>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<List<GetAllRoomsResponse>>> GetAllRoomsAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetAllRoomsQuery();
        var response = await sender.Send(query, cancellationToken);
        
        return ApiResponse<List<GetAllRoomsResponse>>.Success(response);
    }
}
