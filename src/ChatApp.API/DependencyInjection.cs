using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}