using ChatApp.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure.Extensions;

public static class DatabaseServiceExtensions
{
    #region Methods

    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        var conn = configuration[$"{ConnectionStringsConfig.Section}:{ConnectionStringsConfig.Database}"];

        services.AddDbContext<ChatAppDbContext>(options =>
            {
                options.UseNpgsql(
                    conn,
                    b => b.MigrationsAssembly(typeof(InfrastructureMarker).Assembly.FullName));
            });

        return services;
    }

    #endregion
}