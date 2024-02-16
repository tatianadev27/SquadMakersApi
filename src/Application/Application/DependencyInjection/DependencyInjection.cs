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
            services.AddTransient<ChuckNorrisJokeService>();
            services.AddTransient<DadJokeService>();
            services.AddTransient<RandomJokeService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
