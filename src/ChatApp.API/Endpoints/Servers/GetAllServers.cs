using Common.Constants;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Servers.Queries;
using ChatApp.Application.Dtos.Servers.Responses;

namespace ChatApp.Api.Endpoints.Servers;

public sealed class GetAllServers : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(ServerRoutes.GetAll, GetAllServersAsync)
            .WithTags(ServerRoutes.Tags)
            .WithName(nameof(GetAllServers))
            .Produces<ApiResponse<List<ServerResponse>>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .RequireAuthorization();
    }

    private async Task<ApiResponse<List<ServerResponse>>> GetAllServersAsync(
        ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetAllServersQuery();
        var response = await sender.Send(query, cancellationToken);
        
        return ApiResponse<List<ServerResponse>>.Success(response);
    }
}
