namespace ChatApp.Application.Dtos.Abstractions;

public interface IEntityId<T> 
{
    #region Fields, Properties
    
    public T Id { get; set; }

    #endregion
}