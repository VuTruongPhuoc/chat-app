using ChatApp.Infrastructure.DbContext;
using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        var conn = configuration[$"{ConnectionStringsCfg.Section}:{ConnectionStringsCfg.Database}"];

        services.AddDbContext<ChatAppDbContext>(options =>
            {
                options.UseNpgsql(
                    conn,
                    b => b.MigrationsAssembly(typeof(InfrastructureMarker).Assembly.FullName));
            });

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

        // Add Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}