using AutoMapper;
using ChatApp.Application.Abstractions.Messaging.Commands;
using ChatApp.Application.Dtos.Rooms.Requests;
using ChatApp.Domain.Repositories;
using Common.Constants;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Rooms.Commands;

public record UpdateRoomCommand(Guid Id, UpsertRoomRequest request, Actor actor) : IRequest<Guid>;


public sealed class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    #region Ctors

    public UpdateRoomCommandValidator()
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

public class UpdateRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<UpdateRoomCommand, Guid>
{
    public async Task<Guid> Handle(UpdateRoomCommand command, CancellationToken cancellationToken)
    {
        var existingRoom = await roomRepository.GetByIdAsync(command.Id, cancellationToken);       
    
        if (existingRoom == null)
        {
            throw new ArgumentException(MessageCode.RoomNotFound);
        }

        var updatedRoom = mapper.Map(command.request, existingRoom);
        updatedRoom.UpdatedAt = DateTime.UtcNow;
        updatedRoom.UpdatedBy = command.actor.ToString();
        roomRepository.Update(updatedRoom);
        
        return updatedRoom.Id;
    }
}