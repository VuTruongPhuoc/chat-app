
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ChatApp.Application.Extensions;

namespace ChatApp.Application;    

public static class DependencyInjection
{
    #region Methods

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAutoMapperServices()
            .AddMediatRServices();

        return services;
    }

    #endregion
}