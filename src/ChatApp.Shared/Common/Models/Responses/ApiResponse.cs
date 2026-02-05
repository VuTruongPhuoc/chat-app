using System.Net;

namespace Common.Models.Responses;

public class ApiResponse
{
    #region Fields, Properties

    public bool IsSuccess { get; set; }
    
    public string? Message { get; set; }

    #endregion

    #region Ctors
    
    public ApiResponse() {}

    public ApiResponse(bool isSuccess, string? message = null)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    #endregion

    #region Methods

    public static ApiResponse Success(string? message = null) => new(true, message);

    public static ApiResponse Failure(string? message = null) => new(false, message);

    #endregion
}

public class ApiResponse<T> : ApiResponse
{
    #region Fields, Properties

    public T? Data { get; set; }

    #endregion

    public static ApiResponse<T> Success(T data, string? message = null) 
        => new() { IsSuccess = true, Data = data, Message = message };

    public static ApiResponse<T> Failure(T data, string? message = null) 
        => new() { IsSuccess = false, Data = data, Message = message };
}