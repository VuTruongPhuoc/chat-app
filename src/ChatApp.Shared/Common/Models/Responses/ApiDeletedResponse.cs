namespace Common.Models.Responses;

public sealed class ApiDeletedResponse<T>
{
    public T Data { get; set; } = default!;

    public ApiDeletedResponse() { }
    public ApiDeletedResponse(T data)
    {
        Data = data;
    }

}