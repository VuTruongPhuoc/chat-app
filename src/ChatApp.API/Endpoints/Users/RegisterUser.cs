using ChatApp.Application.Dtos.Users.Requests;
using ChatApp.Application.Features.Users.Commands;
using Common.ValueObjects;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;

namespace ChatApp.Api.Endpoints.Users;

public sealed class RegisterUser : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(UserRoutes.Create, HandleCreateUserAsync)
            .WithTags(UserRoutes.Tags)
            .WithName(nameof(RegisterUser))
            .Produces<ApiCreatedResponse<Guid>>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .RequireAuthorization();
    }

    private async Task<ApiCreatedResponse<Guid>> HandleCreateUserAsync(
        ISender sender,
        [FromBody] UpsertUserRequest request,
        CancellationToken cancellationToken)
    {       
        var command = new CreateUserCommand(request, Actor.System(Modules.System));
        var userId = await sender.Send(command, cancellationToken);
 
        return new ApiCreatedResponse<Guid>(userId);
    }
}