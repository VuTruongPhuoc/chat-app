namespace ChatApp.Application.Dtos.Auths.Requests;

public sealed class ResetPasswordRequest
{
    #region Fields, Properties

    public string Email { get; init; } = default!;

    public string Token { get; init; } = default!;
    
    public string NewPassword { get; init; } = default!;

    public string ConfirmNewPassword { get; init; } = default!;

    #endregion
}