using Common.ValueObjects;
using Common.Constants;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Routes;
using ChatApp.Application.Features.Auths.Commands;
using ChatApp.Application.Dtos.Auths.Requests;

namespace ChatApp.Api.Endpoints.Auths;

public sealed class Register : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(AuthRoutes.Register, HandleRegisterAsync)
            .WithTags(AuthRoutes.Tags)
            .WithName(nameof(Register))
            .Produces<ApiResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .AllowAnonymous();
    }

    private async Task<ApiResponse> HandleRegisterAsync(
        ISender sender,
        [FromBody] RegisterRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RegisterCommand(request, Actor.System(Modules.User));
        var response = await sender.Send(command, cancellationToken);
        
        return response;
    }
}
