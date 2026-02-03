using ChatApp.Application.Dtos.Emails;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure.Extensions;

public static class OptionsServiceExtension
{
    #region Methods

    public static IServiceCollection AddOptionsServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Section));
        services.Configure<EmailOptions>(configuration.GetSection(EmailOptions.Section));
        services.Configure<FrontEndOptions>(configuration.GetSection(FrontEndOptions.Section));
    
        return services;
    }

    #endregion
}