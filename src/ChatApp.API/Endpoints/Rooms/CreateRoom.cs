using Common.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Rooms.Commands;
using ChatApp.Application.Dtos.Rooms.Requests;
using ChatApp.Infrastructure.Extensions.Identity;

namespace ChatApp.Api.Endpoints.Auths;

public sealed class CreateRoom : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(RoomRoutes.Create, CreateRoomAsync)
            .WithTags(RoomRoutes.Tags)
            .WithName(nameof(CreateRoom))
            .Produces<ApiResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<Guid>> CreateRoomAsync(
        ISender sender,
        [FromServices] HttpContextAccessor httpContextAccessor,
        [FromBody] UpsertRoomRequest request,
        CancellationToken cancellationToken)
    {
        var currentUser = httpContextAccessor.GetCurrentUser();
        var command = new CreateRoomCommand(request, Actor.User(currentUser.Email));
        var response = await sender.Send(command, cancellationToken);
        
        return ApiResponse<Guid>.Success(response);
    }
}
