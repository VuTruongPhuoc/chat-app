namespace Common.Models.DTOs;

public class UserDto
{
    #region Fields, Properties

    public string Id { get; init; } = default!;

    public string UserName { get; init; } = default!;

    public string FirstName { get; init; } = default!;

    public string LastName { get; init; } = default!;

    public string Email { get; init; } = default!;

    public bool EmailVerified { get; init; }

    public List<string>? Roles { get; init; }

    #endregion
}