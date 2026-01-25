namespace Common.Models.Responses;

public sealed class ApiCreatedResponse<T>
{
    public T Data { get; set; } = default!;

    public ApiCreatedResponse() { }
    public ApiCreatedResponse(T data)
    {
        Data = data;
    }

}