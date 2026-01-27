namespace ChatApp.Application.Dtos.Users;

public sealed class LoginRequest
{
    #region Fields, Properties

    public string Username { get; set; } = default!;

    public string Password { get; set; } = default!;

    #endregion;
}