using AutoMapper;
using BuildingBlocks.CQRS;
using ChatApp.Domain.Repositories;

namespace ChatApp.Application.Abstractions.Messaging.Commands;

public abstract class BaseCommandHandler<TCommand, TRequest, TResponse, TIRepository, TEntity> 
    : ICommandHandler<TCommand, TResponse>
    where TCommand : BaseCommand<TRequest, TResponse>
    where TRequest : class
    where TResponse : notnull
    where TIRepository : IRepository<TEntity>
    where TEntity : class, IAuditable
{
    #region Fields, Properties

    protected readonly IMapper _mapper;

    protected readonly TIRepository _repository;

    #endregion

    #region Ctors

    protected BaseCommandHandler(IMapper mapper, TIRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    #endregion

    #region Methods

    public abstract Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);

    protected virtual async Task<TEntity> CreateAsync(TCommand command)
    {
        var entity = _mapper.Map<TEntity>(command.request);

        if (entity is ICreateAuditable auditable)
        {
            auditable.CreatedBy = command.actor.ToString();
            auditable.CreatedAt = DateTime.UtcNow;
        }
        
        await _repository.AddAsync(entity);

        return entity;
    }

    protected virtual void Update(TEntity existingEntity, TCommand command)
    {
        _mapper.Map(command.request, existingEntity);

        if (existingEntity is IUpdateAuditable auditable)
        {
            auditable.UpdatedBy = command.actor.ToString();
            auditable.UpdatedAt = DateTime.UtcNow;
        }

        _repository.Update(existingEntity);
    }

    protected virtual async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (entity != null)
        {
            _repository.Delete(entity);
        }
    }

    #endregion
}