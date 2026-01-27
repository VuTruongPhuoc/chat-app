using ChatApp.Api.Endpoints;

namespace ChatApp.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerServices(configuration);

        return services;
    }
}