using System.Net;

namespace Common.Models.Abstractions;

public interface IResponse
{
    #region Fields, Properties

    public bool Success { get; set; }
    
    public HttpStatusCode StatusCode { get; set; }
    
    public string? Message { get; set; }

    #endregion
}