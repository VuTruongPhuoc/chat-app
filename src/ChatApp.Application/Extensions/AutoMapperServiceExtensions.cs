using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Application.Extensions;

public static class AutoMapperServiceExtensions
{
    #region Methods

    public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationMarker).Assembly);

        return services;
    }

    #endregion
}