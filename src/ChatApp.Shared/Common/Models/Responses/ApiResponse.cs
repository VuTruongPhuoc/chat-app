using System.Net;

namespace Common.Models.Responses;

public class ApiResponse
{
    #region Fields, Properties

    public bool IsSuccess { get; set; }
    
    public HttpStatusCode StatusCode { get; set; }
    
    public string? Message { get; set; }

    #endregion

    #region Ctors
    
    public ApiResponse() {}

    public ApiResponse(bool isSuccess, HttpStatusCode statusCode, string? message = null)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message;
    }

    #endregion

    #region Methods

    public static ApiResponse Success(string? message = null) => new(true, HttpStatusCode.OK, message);

    public static ApiResponse BadRequest(string? message = null) => new(false, HttpStatusCode.BadRequest, message);

    public static ApiResponse Unauthorized(string? message = null) => new(false, HttpStatusCode.Unauthorized, message);

    public static ApiResponse Forbidden(string? message = null) => new(false, HttpStatusCode.Forbidden, message);
    
    public static ApiResponse NotFound(string? message = null) => new(false, HttpStatusCode.NotFound, message);

    #endregion
}