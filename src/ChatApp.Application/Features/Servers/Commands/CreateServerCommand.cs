using AutoMapper;
using ChatApp.Application.Dtos.Servers.Requests;
using ChatApp.Domain.Repositories;
using Common.Constants;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Servers.Commands;

public record CreateServerCommand(UpsertServerRequest request, Actor actor) : IRequest<Guid>;

public sealed class CreateServerCommandValidator : AbstractValidator<CreateServerCommand>
{
    #region Ctors

    public CreateServerCommandValidator()
    {
        RuleFor(r => r.request)
            .NotNull()
            .WithMessage(MessageCode.BadRequest)
            .DependentRules(() =>
            {
                RuleFor(r => r.request.Name)
                    .NotEmpty()
                    .WithMessage(MessageCode.ServerNameIsRequired);
            });
    }

    #endregion
}

public class CreateServerCommandHandler(IServerRepository serverRepository, IMapper mapper) : IRequestHandler<CreateServerCommand, Guid>
{
    public async Task<Guid> Handle(CreateServerCommand command, CancellationToken cancellationToken)
    {
        var server = mapper.Map<Domain.Entities.Servers>(command.request);
        
        server.Id = Guid.NewGuid();
        server.OwnerId = Guid.Parse(command.actor.Data);
        server.CreatedAt = DateTime.UtcNow;
        server.CreatedBy = command.actor.ToString();
        await serverRepository.AddAsync(server, cancellationToken);

        return server.Id;
    }
}
