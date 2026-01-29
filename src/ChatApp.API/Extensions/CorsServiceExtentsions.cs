
using Common.Configurations;
namespace ChatApp.Api.Extensions;

public static class CorsServiceExtensions
{
    #region Methods

    public static IServiceCollection AddCorsServices(this IServiceCollection services, IConfiguration configuration)
    {
        var policyName = configuration.GetSection($"{CorsConfig.Section}:{CorsConfig.PolicyName}").Get<string>()!;
        services.AddCors(options =>
        {
            options.AddPolicy(
                policyName,
                policy => policy
                    .WithOrigins(configuration.GetSection($"{CorsConfig.Section}:{CorsConfig.Domains}").Get<string[]>()!)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());
        });

        return services;
    }

    #endregion
}