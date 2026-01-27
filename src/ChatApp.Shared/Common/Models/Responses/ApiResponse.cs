using System.Net;

namespace Common.Models.Responses;

public class ApiResponse
{
    #region Fields, Properties

    public bool Success { get; set; }
    
    public HttpStatusCode StatusCode { get; set; }
    
    public string? Message { get; set; }

    #endregion
}