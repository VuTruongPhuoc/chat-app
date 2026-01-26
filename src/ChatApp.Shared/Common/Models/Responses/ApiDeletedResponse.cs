namespace Common.Models.Responses;

public sealed class ApiDeletedResponse<T>
{
    #region Fields, Properties

    public T Data { get; set; } = default!;

    #endregion

    #region Ctors
    public ApiDeletedResponse() { }
    
    public ApiDeletedResponse(T data)
    {
        Data = data;
    }

    #endregion
}