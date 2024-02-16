using Domain.Aggregate;
using Domain.Entities;
using Domain.Proxy;
using Domain.Services;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class ChuckNorrisJokeService : IJokeService
    {
        private readonly IJokeApiProxy _jokeApiProxy;
        private readonly string _apiBaseUrl;
        public ChuckNorrisJokeService()
        {
        }

        public ChuckNorrisJokeService(IJokeApiProxy jokeApiProxy)
        {
            _jokeApiProxy = jokeApiProxy;
            _apiBaseUrl = "https://api.chucknorris.io/jokes/random";
        }

        public async Task<Joke> GetRandomJoke()
        {

            var jokeText = await _jokeApiProxy.GetAsync(_apiBaseUrl);
            return Joke.Create(new JokeText(jokeText));
        }
    }
}
