﻿using Domain.Aggregate;
using Domain.Entities;
using Domain.Proxy;
using Domain.Services;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class DadJokeService : IJokeService
    {
        private readonly IJokeApiProxy _jokeApiProxy;
        private readonly string _apiBaseUrl;

        public DadJokeService(IJokeApiProxy jokeApiProxy, IConfiguration configuration)
        {
            _jokeApiProxy = jokeApiProxy;
            _apiBaseUrl = "https://icanhazdadjoke.com/api";
        }

        public async Task<Joke> GetRandomJoke()
        {
            var jokeText = await _jokeApiProxy.GetAsync(_apiBaseUrl);
            return Joke.Bulid(new JokeText(jokeText));
        }
    }
}
