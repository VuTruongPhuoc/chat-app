namespace ChatApp.Application.Dtos.Auths.Requests;

public sealed class RegisterRequest
{
    #region Fields, Properties

    public string UserName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string PassWord { get; set; } = default!;

    #endregion
}