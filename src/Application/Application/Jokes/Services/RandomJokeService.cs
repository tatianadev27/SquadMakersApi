﻿using Domain.Aggregate;
using Domain.Services;

namespace Application.Services
{
    public class RandomJokeService : IJokeService
    {

        public RandomJokeService()
        {
        }

        public async Task<Joke> GetRandomJoke()
        {
            return Joke.GetRamdom();
        }
    }
}
