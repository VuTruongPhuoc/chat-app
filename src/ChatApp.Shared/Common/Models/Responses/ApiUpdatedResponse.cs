namespace Common.Models.Responses;

public sealed class ApiUpdatedResponse<T>
{
    #region Fields, Properties

    public T Data { get; set; } = default!;

    #endregion

    #region Ctors

    public ApiUpdatedResponse() { }
    
    public ApiUpdatedResponse(T data)
    {
        Data = data;
    }

    #endregion
}