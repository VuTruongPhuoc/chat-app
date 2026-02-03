using ChatApp.Application.Common.Interfaces;
using ChatApp.Domain.Repositories;
using ChatApp.Domain.Services;
using ChatApp.Infrastructure.Repositories;
using ChatApp.Infrastructure.Services;
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
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }

    #endregion
}