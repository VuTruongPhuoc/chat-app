using ChatApp.Domain.Abtractions;

public abstract class EntityId<T> : IEntityId<T>
{
    #region Fields, Properties

    public T Id { get; set; } = default!;

    #endregion
}