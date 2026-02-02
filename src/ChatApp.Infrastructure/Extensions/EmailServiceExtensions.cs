using ChatApp.Application.Services;
using ChatApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure.Extensions;

public static class EmailServiceExtensions
{
    public static IServiceCollection AddEmailServices(this IServiceCollection services)
    {
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}