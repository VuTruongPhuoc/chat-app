using ChatApp.Domain.Repositories;
using Common.Constants;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Servers.Commands;

public record DeleteServerCommand(Guid Id, Actor actor) : IRequest<bool>;

public sealed class DeleteServerCommandValidator : AbstractValidator<DeleteServerCommand>
{
    public DeleteServerCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEqual(Guid.Empty)
            .WithMessage(MessageCode.BadRequest);
    }
}

public class DeleteServerCommandHandler(IServerRepository serverRepository) : IRequestHandler<DeleteServerCommand, bool>
{
    public async Task<bool> Handle(DeleteServerCommand command, CancellationToken cancellationToken)
    {
        var server = await serverRepository.GetByIdAsync(command.Id, cancellationToken);
        if (server == null)
        {
            throw new ArgumentException(MessageCode.BadRequest);
        }

        serverRepository.Delete(server);

        return true;
    }
}
