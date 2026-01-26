using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure.Extensions;

public static class RepositoryServiceExtensions
{
    #region Methods

    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        // Add Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    #endregion
}