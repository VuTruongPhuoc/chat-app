using ChatApp.Domain.Repositories;
using Common.Constants;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Rooms.Commands;

public record DeleteRoomCommand(Guid Id, Actor actor) : IRequest<bool>;

public sealed class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
{
    public DeleteRoomCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEqual(Guid.Empty)
            .WithMessage(MessageCode.BadRequest);
    }
}

public class DeleteRoomCommandHandler(IRoomRepository roomRepository) : IRequestHandler<DeleteRoomCommand, bool>
{
    public async Task<bool> Handle(DeleteRoomCommand command, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(command.Id, cancellationToken);
        if (room == null)
        {
            throw new ArgumentException(MessageCode.RoomNotFound);
        }

        roomRepository.Delete(room);

        return true;
    }
}