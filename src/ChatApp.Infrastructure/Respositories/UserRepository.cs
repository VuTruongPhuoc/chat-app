using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

public class UserRepository : IUserRepository
{
    private readonly UserManager<Users> _userManager;
    public UserRepository(UserManager<Users> userManager)
    {
        _userManager = userManager;
    }
    public async Task<Guid> RegisterUserAsync(Users user, CancellationToken cancellationToken)
    {
        var result = await _userManager.CreateAsync(user, user.PasswordHash!);
        if (!result.Succeeded)
        {
            throw new Exception("Failed to register user");
        }
        return user.Id;
    }

}