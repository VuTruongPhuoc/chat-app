namespace Common.Models.Responses;

public sealed class ApiCreatedResponse<T>
{
    #region Fields, Properties
    
    public T Data { get; set; } = default!;

    #endregion

    #region Ctors

    public ApiCreatedResponse() { }
    
    public ApiCreatedResponse(T data)
    {
        Data = data;
    }

    #endregion
}