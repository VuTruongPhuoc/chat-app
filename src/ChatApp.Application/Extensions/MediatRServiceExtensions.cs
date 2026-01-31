using BuildingBlocks.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Application.Extensions;

public static class MediatRServiceExtensions
{
    #region Methods

    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(ApplicationMarker).Assembly);
        services.AddMediatR(cfg => 
        {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationMarker).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        return services;
    }

    #endregion
}