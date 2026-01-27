namespace Common.Models.Responses;

public sealed class ApiLoginResponse<T> : ApiResponse
{
    #region Fields, Properties

    public T? Data { get; set; }

    public string AccessToken { get; set; } = default!;

    public DateTime Expiration { get; set; } = default!;

    public string RefreshToken { get; set; } = default!;

    #endregion
}