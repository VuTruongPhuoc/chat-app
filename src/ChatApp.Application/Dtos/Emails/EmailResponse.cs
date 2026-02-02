namespace ChatApp.Application.Dtos.Emails;

public sealed class EmailResponse
{
    #region Fields, Properties

    public bool IsSuccess { get; set; }
    
    public string? ErrorMessage { get; set; }

    #endregion

    #region Ctors
    public EmailResponse() { }

    public EmailResponse(bool isSuccess, string? message = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = message;
    }
    #endregion

    #region Methods

    public static EmailResponse Success() => new(true);

    public static EmailResponse Error(string message) => new(false, message);

    #endregion
}