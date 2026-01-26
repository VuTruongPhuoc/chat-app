using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

public class UserRepository : IUserRepository
{
    #region Fields, Properties

    private readonly UserManager<Users> _userManager;

    #endregion

    #region Ctors

    public UserRepository(UserManager<Users> userManager)
    {
        _userManager = userManager;
    }

    #endregion

    #region Implementations

    public async Task<Guid> RegisterUserAsync(Users user, CancellationToken cancellationToken)
    {
        var result = await _userManager.CreateAsync(user, user.PasswordHash!);
        if (!result.Succeeded)
        {
            throw new Exception("Failed to register user");
        }
        return user.Id;
    }

    #endregion
}