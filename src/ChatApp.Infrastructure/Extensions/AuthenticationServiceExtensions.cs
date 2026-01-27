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
        var jwtSettings = configuration.GetSection(JwtOptions.Section).Get<JwtOptions>();

        if (jwtSettings == null || string.IsNullOrEmpty(jwtSettings.Secret))
        {
            throw new InvalidOperationException("JWT Secret is not configured in appsettings.json");
        }

        // Retrieve the JWT secret key from configuration and encode it to bytes
        var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

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
                        ValidIssuer = jwtSettings.ValidIssuer,
                        ValidateAudience = true,
                        ValidAudience = jwtSettings.ValidAudience,
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