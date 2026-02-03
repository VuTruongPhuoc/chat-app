using ChatApp.Application.Common.Interfaces;
using ChatApp.Application.Dtos.Auths.Responses;
using ChatApp.Application.Features.Auths.Commands;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ChatApp.Application.Features.Auth.Handlers;

public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommand, GoogleLoginResponse>
{
    #region Fields, Properties

    private readonly UserManager<Domain.Entities.Users> _userManager;

    private readonly ITokenService _tokenService;

    private readonly IConfiguration _configuration;

    #endregion

    #region Ctors

    public GoogleLoginCommandHandler(UserManager<Domain.Entities.Users> userManager, IConfiguration configuration, ITokenService tokenService)
    {
        _userManager = userManager;
        _configuration = configuration;
        _tokenService = tokenService;
    }

    #endregion

    public async Task<GoogleLoginResponse> Handle(GoogleLoginCommand command, CancellationToken ct)
    {
        // 1. Xác thực Token gửi từ trình duyệt
        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new[] { _configuration[$"{GoogleAuthenticationConfig.Section}:{GoogleAuthenticationConfig.ClientId}"] }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(command.request.tokenId, settings);

        var user = await _userManager.FindByEmailAsync(payload.Email);
        if (user == null)
        {
            user = new Domain.Entities.Users 
            { 
                UserName = payload.Email, 
                Email = payload.Email, 
                AvatarUrl = payload.Picture,
                EmailConfirmed = true 
            };
            await _userManager.CreateAsync(user);

            var google = $"{GoogleAuthenticationConfig.Google}";
            await _userManager.AddLoginAsync(user, new UserLoginInfo(google, payload.Subject, google));
        }

        var roles = await _userManager.GetRolesAsync(user);

        var (token, _) = _tokenService.GenerateAccessToken(user, roles);

        return new GoogleLoginResponse(token, user.Email!);   
    }
}