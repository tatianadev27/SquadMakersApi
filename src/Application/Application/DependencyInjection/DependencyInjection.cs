using Application.Services;
using Application.Services.Factory;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IJokeServiceFactory, JokeServiceFactory>();
            services.AddScoped<IJokeService, ChuckNorrisJokeService>();
            services.AddScoped<IJokeService, DadJokeService>();
            services.AddScoped<IJokeService, RandomJokeService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
