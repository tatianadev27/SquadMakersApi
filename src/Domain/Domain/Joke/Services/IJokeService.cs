using Domain.Aggregate;

namespace Domain.Services
{
    public interface IJokeService
    {
        Task<Joke> GetRandomJoke();
    }
}
