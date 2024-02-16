using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.Factory
{
    public class JokeServiceFactory : IJokeServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public JokeServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJokeService Create(string type)
        {
            switch (type.ToLower())
            {
                case "chuck":
                    return _serviceProvider.GetService<ChuckNorrisJokeService>();
                case "dad":
                    return _serviceProvider.GetService<DadJokeService>();
                case "":
                case null:
                    return _serviceProvider.GetService<RandomJokeService>();
                default:
                    throw new InvalidOperationException("Invalid joke type. Valid types are 'Chuck' and 'Dad'.");
            }
        }
    }
}
