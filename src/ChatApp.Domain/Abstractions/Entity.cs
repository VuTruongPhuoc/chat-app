using ChatApp.Domain.Abtractions;

public abstract class Entity<T> : IEntityId<T>, IAuditable
{
    #region Fields, Properties

    public T Id { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public string? UpdatedBy { get; set; }

    #endregion
}