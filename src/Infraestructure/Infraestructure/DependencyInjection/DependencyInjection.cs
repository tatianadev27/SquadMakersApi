using Domain.Proxy;
using Domain.Repositories;
using Infraestructure.Persintence.Database;
using Infraestructure.Persistence.Repositories;
using Infraestructure.Proxy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<JokeDbContext>(options =>
            {
                options.UseInMemoryDatabase("JokeDataBase")
                    .EnableSensitiveDataLogging()
                    .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            services.AddScoped<IJokeApiProxy, JokeApiProxy>();
            services.AddScoped<IJokeRepository, JokeRepository>();
            return services;
        }
    }
}
