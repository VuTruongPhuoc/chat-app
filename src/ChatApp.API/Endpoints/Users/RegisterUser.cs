using Carter;
using ChatApp.Api.Endpoints.Users;
using ChatApp.Application.Dtos;
using ChatApp.Application.Dtos.Users;
using ChatApp.Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Endpoints.Users;

public sealed class RegisterUser : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(UserRoutes.Create, HandleCreateUserAsync)
            .WithTags(UserRoutes.Tags)
            .WithName(nameof(RegisterUser))
            .Produces<ApiCreatedResponse<Guid>>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }

    private async Task<ApiCreatedResponse<Guid>> HandleCreateUserAsync(
        ISender sender,
        [FromBody] RegisterUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RegisterUserCommand(request);
        var userId = await sender.Send(command, cancellationToken);
        return new ApiCreatedResponse<Guid>(userId);
    }
}