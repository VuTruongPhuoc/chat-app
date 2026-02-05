using ChatApp.Application.Common.Interfaces;
using ChatApp.Application.Dtos.Auths.Responses;
using Common.ValueObjects;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ChatApp.Application.Features.Auths.Commands;

public record GoogleLoginCommand(GoogleLoginRequest request, Actor actor) : IRequest<GoogleLoginResponse>;


public class GoogleLoginCommandHandler(
    UserManager<Domain.Entities.Users> userManager,
    ITokenService tokenService,
    IConfiguration configuration) 
    : IRequestHandler<GoogleLoginCommand, GoogleLoginResponse>
{
    public async Task<GoogleLoginResponse> Handle(GoogleLoginCommand command, CancellationToken ct)
    {
        // 1. Xác thực Token gửi từ trình duyệt
        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new[] { configuration[$"{GoogleAuthenticationConfig.Section}:{GoogleAuthenticationConfig.ClientId}"] }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(command.request.tokenId, settings);

        var user = await userManager.FindByEmailAsync(payload.Email);
        if (user == null)
        {
            user = new Domain.Entities.Users 
            { 
                UserName = payload.Email, 
                Email = payload.Email, 
                AvatarUrl = payload.Picture,
                EmailConfirmed = true 
            };
            await userManager.CreateAsync(user);

            var google = $"{GoogleAuthenticationConfig.Google}";
            await userManager.AddLoginAsync(user, new UserLoginInfo(google, payload.Subject, google));
        }

        var roles = await userManager.GetRolesAsync(user);

        var (token, _) = tokenService.GenerateAccessToken(user, roles);

        return new GoogleLoginResponse(token, user.Email!);   
    }
}