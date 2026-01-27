namespace ChatApp.Application.Dtos.Users;

public sealed class RegisterRequest
{
    #region Fields, Properties

    public string Username { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;

    #endregion
}