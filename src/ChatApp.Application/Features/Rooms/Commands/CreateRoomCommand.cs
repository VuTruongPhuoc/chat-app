using AutoMapper;
using ChatApp.Application.Dtos.Rooms.Requests;
using ChatApp.Domain.Repositories;
using Common.Constants;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Rooms.Commands;

public record CreateRoomCommand(UpsertRoomRequest request, Actor actor) : IRequest<Guid>;

public sealed class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    #region Ctors

    public CreateRoomCommandValidator()
    {
        RuleFor(r => r.request)
            .NotNull()
            .WithMessage(MessageCode.BadRequest)
            .DependentRules(() =>
            {
                RuleFor(r => r.request.Name)
                    .NotEmpty()
                    .WithMessage(MessageCode.RoomNameIsRequired);
            });
    }

    #endregion
}

public class CreateRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<CreateRoomCommand, Guid>
{
    public async Task<Guid> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
    {
        var room = mapper.Map<Domain.Entities.Rooms>(command.request);
        room.Id = Guid.NewGuid();
        room.CreatedAt = DateTime.UtcNow;
        room.CreatedBy = command.actor.ToString();
        await roomRepository.AddAsync(room, cancellationToken);
        return room.Id;
    }
}