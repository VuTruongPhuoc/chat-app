using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ChatApp.Infrastructure.Extensions;

public static class AuthenticationServiceExtensions
{
    #region Method

    public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Retrieve the JWT secret key from configuration and encode it to bytes
        var key = Encoding.ASCII.GetBytes(configuration["JWT:Secret"]!);

        // Configure authentication services with JWT Bearer as default schemes
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Add JWT Bearer authentication handler
            .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    // Set token validation parameters
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JWT:ValidIssuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["JWT:ValidAudience"],
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        NameClaimType = ClaimTypes.Name,
                    };
                });

        return services;
    }

    #endregion;
}