using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using ChatApp.Application.Dtos.Auths.Requests;
using ChatApp.Application.Dtos.Emails;
using ChatApp.Application.Common.Interfaces;
using ChatApp.Domain.Constants;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Services;
using Common.Constants;
using Common.Models.DTOs;
using Common.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ChatApp.Infrastructure.Repositories;

public class IdentityService : IIdentityService
{
    #region Fields, Properties

    private readonly UserManager<Users> _userManager;

    private readonly RoleManager<Roles> _roleManager;
    
    private readonly IConfiguration _configuration;

    private readonly IEmailService _emailService;

    private readonly ITokenService _tokenService;

    private readonly IOptions<JwtOptions> _jwtOptions;

    private readonly IOptions<FrontEndOptions> _frontEndOptions;

    private readonly IMapper _mapper;

    #endregion

    #region Ctors

    public IdentityService(UserManager<Users> userManager, RoleManager<Roles> roleManager, IConfiguration configuration, IOptions<JwtOptions> jwtOptions, IMapper mapper, IEmailService emailService, IOptions<FrontEndOptions> frontEndOptions, ITokenService tokenService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _jwtOptions = jwtOptions;
        _mapper = mapper;
        _emailService = emailService;
        _frontEndOptions = frontEndOptions;
        _tokenService = tokenService;
    }

    #endregion

    #region Implementations

    public async Task<ApiResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);

        if(user is null || !await _userManager.CheckPasswordAsync(user, request.PassWord))
        {
            return ApiResponse.Unauthorized();
        }

        var roles = await _userManager.GetRolesAsync(user);

        var (accessToken, expiration) = _tokenService.GenerateAccessToken(user, roles);
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(_jwtOptions.Value.AccessTokenExpirationMinutes);

        await _userManager.UpdateAsync(user);

        return new ApiLoginResponse<UserDto>
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.OK,
            AccessToken = accessToken,
            Expiration = expiration,
            RefreshToken = refreshToken,
            Data = _mapper.Map<UserDto>(user)
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

            return ApiResponse.BadRequest(message);
        }

        var user = _mapper.Map<Users>(request);

        var result = await _userManager.CreateAsync(user, request.PassWord);

        if (!result.Succeeded) 
        { 
            return ApiResponse.BadRequest(string.Join(", ", result.Errors.Select(e => e.Description))); 
        }

        await _userManager.AddToRoleAsync(user, RoleConstants.Member);

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> ForgotPasswordAsync(string email, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            return ApiResponse.Success();
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var resetLink =
            $"{_frontEndOptions.Value.BaseUrl}{_frontEndOptions.Value.ResetPasswordPath}" +
            $"?email={Uri.EscapeDataString(email)}" +
            $"&token={Uri.EscapeDataString(token)}";

        var (subject, body) = EmailMessage.ResetPassword(resetLink);

        var emailRequest = new EmailRequest
        {
            To = new List<string> { email },
            Subject = subject,
            Body = body,
            IsBodyHtml = true,
            UserId = user.Id
        };

        await _emailService.SendEmailAsync(emailRequest, cancellationToken);

        return ApiResponse.Success();
    }

    public async Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            return ApiResponse.BadRequest(MessageCode.InvalidToken);
        }

        var result = await _userManager.ResetPasswordAsync(
            user,
            request.Token,
            request.NewPassword
        );

        if (!result.Succeeded)
        {
            return ApiResponse.BadRequest(
                string.Join(", ", result.Errors.Select(e => e.Description))
            );
        }

        return ApiResponse.Success();
    }

    #endregion
}