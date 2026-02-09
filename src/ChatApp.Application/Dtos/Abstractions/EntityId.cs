namespace ChatApp.Application.Dtos.Abstractions;

public abstract class EntityId<T> : IEntityId<T>
{
    #region Fields, Properties

    public T Id { get; set; } = default!;

    #endregion
}