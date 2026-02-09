using AutoMapper;
using ChatApp.Application.Dtos.Servers.Requests;
using ChatApp.Domain.Repositories;
using Common.Constants;
using Common.ValueObjects;
using FluentValidation;
using MediatR;

namespace ChatApp.Application.Features.Servers.Commands;

public record UpdateServerCommand(Guid Id, UpsertServerRequest request, Actor actor) : IRequest<Guid>;

public sealed class UpdateServerCommandValidator : AbstractValidator<UpdateServerCommand>
{
    #region Ctors

    public UpdateServerCommandValidator()
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

public class UpdateServerCommandHandler(IServerRepository serverRepository, IMapper mapper) : IRequestHandler<UpdateServerCommand, Guid>
{
    public async Task<Guid> Handle(UpdateServerCommand request, CancellationToken cancellationToken)
    {
        var existingServer = await serverRepository.GetByIdAsync(request.Id, cancellationToken);       
    
        if (existingServer == null)
        {
            throw new ArgumentException(MessageCode.BadRequest);
        }

        var updatedServer = mapper.Map(request.request, existingServer);
        updatedServer.UpdatedAt = DateTime.UtcNow;
        updatedServer.UpdatedBy = request.actor.ToString();
        serverRepository.Update(updatedServer);
        
        return updatedServer.Id;
    }
}
