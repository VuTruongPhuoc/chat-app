namespace Common.Models.Responses;

public sealed class ApiUpdatedResponse<T>
{
    public T Data { get; set; } = default!;

    public ApiUpdatedResponse() { }
    public ApiUpdatedResponse(T data)
    {
        Data = data;
    }

}