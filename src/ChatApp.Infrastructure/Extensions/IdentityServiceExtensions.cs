using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        // Add Identity
        services.AddIdentity<Users, Roles>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false; 
    
                options.Password.RequireDigit = false; // Không bắt buộc chữ số
                options.Password.RequireUppercase = false; // Không bắt buộc chữ hoa
            })
            .AddEntityFrameworkStores<ChatAppDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}