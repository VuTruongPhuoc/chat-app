using System.Security.Claims;
using Common.Constants;
using Common.Models.Context;
using Microsoft.AspNetCore.Http;

namespace ChatApp.Infrastructure.Extensions.Identity;

public static class UserContextExtensions
{
    public static UserContext GetCurrentUser(this IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        return new UserContext()
        {
            Id = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty,
            UserName = user?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty,
            FirstName = user?.FindFirst(ClaimTypes.GivenName)?.Value ?? string.Empty,
            LastName = user?.FindFirst(ClaimTypes.Surname)?.Value ?? string.Empty,
            Email = user?.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty,
            Roles = user?.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList() ?? [],
            EmailVerified = bool.TryParse(user?.FindFirst(ClaimTypesContants.EmailConfirmed)?.Value, out bool result),
        };
    }
}