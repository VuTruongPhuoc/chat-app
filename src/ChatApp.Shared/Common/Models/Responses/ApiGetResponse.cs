namespace Common.Responses;

public sealed class ApiGetResponse<T>
{
    #region Fields, Properties

    public T Data { get; set; } = default!;

    #endregion

    #region Ctors

    public ApiGetResponse() { }
    
    public ApiGetResponse(T data)
    {
        Data = data;
    }

    #endregion
} 