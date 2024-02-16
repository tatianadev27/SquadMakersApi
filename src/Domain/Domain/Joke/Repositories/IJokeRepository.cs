using Domain.Aggregate;

namespace Domain.Repositories
{
    public interface IJokeRepository
    {
        Task<Joke> Add(Joke entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<Joke>> GetAll();
        Task<Joke> GetById(int id);
        Task<bool> Update(Joke entity);
    }
}