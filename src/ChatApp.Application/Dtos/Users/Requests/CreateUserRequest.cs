namespace ChatApp.Application.Dtos.Users.Requests;

public class UpsertUserRequest
{
    #region Fields, Properties

    public string UserName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string PassWord { get; set; } = default!;
    
    public string AvatarUrl { get; set; } = default!;

    #endregion
}
