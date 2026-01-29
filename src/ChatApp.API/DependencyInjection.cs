using ChatApp.Api.Extensions;

namespace ChatApp.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services
        services.AddCarter()
            .AddEndpointsApiExplorer()
            .AddSwaggerServices(configuration)
            .AddCorsServices(configuration);

        return services;
    }
}