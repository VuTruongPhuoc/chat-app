using ChatApp.Application;
using ChatApp.Infrastructure;
using ChatApp.Api;
using Common.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseHttpsRedirection();

app.UseCors(builder.Configuration[$"{CorsConfig.Section}:{CorsConfig.PolicyName}"]!);

app.MapCarter();

app.Run();

