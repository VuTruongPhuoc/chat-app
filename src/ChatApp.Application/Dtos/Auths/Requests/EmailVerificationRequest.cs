namespace ChatApp.Application.Dtos.Auths.Requests;

public sealed class EmailVerificationRequest
{
    #region Fields, Properties

    public string Email { get; set; } = default!;

    public string Token { get; set; } = default!;

    #endregion
}