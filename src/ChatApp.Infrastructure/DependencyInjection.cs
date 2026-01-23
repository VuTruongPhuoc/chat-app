using ChatApp.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<ChatAppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("ChatAppDbContext"),
                b => b.MigrationsAssembly(typeof(InfrastructureMarker).Assembly.FullName)));    

        return services;
    }
}