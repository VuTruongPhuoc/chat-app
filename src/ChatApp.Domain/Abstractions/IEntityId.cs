namespace ChatApp.Domain.Abtractions;

public interface IEntityId<T> 
{
    public T Id { get; set; }
}
