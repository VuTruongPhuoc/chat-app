using ChatApp.Infrastructure.DbContext;
using ChatApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<Users, Roles>()
            .AddEntityFrameworkStores<ChatAppDbContext>()
            .AddDefaultTokenProviders();
        return services;
    }
}