using ChatApp.Domain.Abtractions;

public abstract class EntityId<T> : IEntityId<T>
{
    public T Id { get; set; } = default!;
}