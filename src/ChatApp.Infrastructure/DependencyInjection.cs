using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ChatApp.Infrastructure.Extensions;

namespace ChatApp.Infrastructure;

public static class DependencyInjection
{
    #region Methods

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseServices(configuration)
                .AddAuthenticationServices(configuration)
                .AddOptionsServices(configuration)
                .AddIdentityServices()
                .AddRepositoryServices()
                .AddEmailServices()
                // Add Http Context Accessor
                .AddHttpContextAccessor();

        return services;
    }

    #endregion
}