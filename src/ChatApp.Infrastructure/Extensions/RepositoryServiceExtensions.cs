using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure.Extensions;

public static class RepositoryServiceExtensions
{
    #region Methods

    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        // Add Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IIdentityRepository, IdentityRepository>();

        return services;
    }

    #endregion
}