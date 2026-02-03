using System.Security.Claims;
using ChatApp.Domain.Entities;

namespace ChatApp.Application.Common.Interfaces;

public interface ITokenService
{
    #region Methods

    (string, DateTime) GenerateAccessToken(Users user, IList<string> roles);
    
    string GenerateRefreshToken();
    
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    #endregion
}