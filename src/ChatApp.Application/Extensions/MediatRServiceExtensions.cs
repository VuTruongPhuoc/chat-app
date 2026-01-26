using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Application.Extensions;

public static class MediatRServiceExtensions
{
    #region Methods

    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationMarker).Assembly));
        return services;
    }

    #endregion
}