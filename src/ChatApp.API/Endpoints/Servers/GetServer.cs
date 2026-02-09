using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Servers.Queries;
using ChatApp.Application.Dtos.Servers.Responses;

namespace ChatApp.Api.Endpoints.Servers;

public sealed class GetServer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(ServerRoutes.GetById, GetServerAsync)
            .WithTags(ServerRoutes.Tags)
            .WithName(nameof(GetServer))
            .Produces<ApiResponse<ServerResponse>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<ServerResponse>> GetServerAsync(
        ISender sender,
        [FromQuery] Guid id,
        CancellationToken cancellationToken)
    {
        var query = new GetServerQuery(id);
        var response = await sender.Send(query, cancellationToken);
        
        return ApiResponse<ServerResponse>.Success(response);
    }
}
