using Domain.Aggregate;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IJokeRepository
    {
        Task<Joke> Add(Joke entity);
        Task<bool> Delete(JokeId id);
        Task<IEnumerable<Joke>> GetAll();
        Task<Joke> GetById(JokeId id);
        Task<bool> Update(Joke entity);
    }
}