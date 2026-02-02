using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Domain.Constants;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Repositories;
using Common.Constants;
using Common.Models.DTOs;
using Common.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ChatApp.Infrastructure.Repositories;

public class IdentityRepository : IIdentityRepository
{
    #region Fields, Properties

    private readonly UserManager<Users> _userManager;

    private readonly RoleManager<Roles> _roleManager;
    
    private readonly IConfiguration _configuration;

    private readonly IOptions<JwtOptions> _options;

    private readonly IMapper _mapper;

    #endregion

    #region Ctors

    public IdentityRepository(UserManager<Users> userManager, RoleManager<Roles> roleManager, IConfiguration configuration, IOptions<JwtOptions> options, IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _options = options;
        _mapper = mapper;
    }

    #endregion

    public async Task<ApiResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);

        if(user is null || !await _userManager.CheckPasswordAsync(user, request.PassWord))
        {
            return new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.Unauthorized
            };
        }

        var securityToken = await GenerateJwtSercurityTokenByUserAsync(user);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);;

        var refreshToken = this.GenerateRefreshToken();
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(1);

        await _userManager.UpdateAsync(user);

        var userDto = _mapper.Map<UserDto>(user);

        return new ApiLoginResponse<UserDto>
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.OK,
            AccessToken = accessToken,
            Expiration = securityToken.ValidTo,
            RefreshToken = refreshToken,
            Data = userDto
        };
    }

    public async Task<ApiResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var existingUserByName = await _userManager.FindByNameAsync(request.UserName);
        var existingUserByEmail = await _userManager.FindByEmailAsync(request.Email);

        if (existingUserByName is not null || existingUserByEmail is not null)
        {
            string message = existingUserByName is not null 
                            ? MessageCode.UserNameAlreadyExists 
                            : MessageCode.EmailAlreadyExists;

            return new ApiResponse
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                Message = message
            };
        }

        var user = _mapper.Map<Users>(request);

        await _userManager.CreateAsync(user, request.PassWord);
        await _userManager.AddToRoleAsync(user, RoleConstants.Member);

        return new ApiResponse()
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.Created,
            Message = MessageCode.RegisterSuccess,
        };
    }

    public JwtSecurityToken GenerateToken(List<Claim> claims)
    {
        var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.Value.Secret));
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = _options.Value.ValidIssuer,
            Audience = _options.Value.ValidAudience,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
        };

        return tokenHandler.CreateJwtSecurityToken(tokenDescriptor);;
    }

    public async Task<JwtSecurityToken> GenerateJwtSercurityTokenByUserAsync(Users user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new Claim(nameof(Users.UserName), user.UserName ?? string.Empty),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
            new Claim(nameof(Users.Id), user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim(nameof(Users.AvatarUrl), user.AvatarUrl ?? string.Empty),
            new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var roleName in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, roleName));
        }

        return GenerateToken(claims);
    }

    public async Task<string> GenerateTokenByUser(Users user)
    {
        var securityToken = await GenerateJwtSercurityTokenByUserAsync(user);
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using (var numberGenerator = RandomNumberGenerator.Create())
        {
            numberGenerator.GetBytes(randomNumber);
        }

        return Convert.ToBase64String(randomNumber);
    }
}