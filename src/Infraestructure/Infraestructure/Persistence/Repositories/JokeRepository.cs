using Domain.Aggregate;
using Domain.Repositories;
using Infraestructure.Persintence.Database;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class JokeRepository : IJokeRepository
    {
        private readonly JokeDbContext _dbContext;

        public JokeRepository(JokeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Joke>> GetAll()
        {
            return await _dbContext.Jokes.ToListAsync();
        }

        public async Task<Joke> GetById(int id)
        {
            return await _dbContext.Jokes.FindAsync(id);
        }

        public async Task<Joke> Add(Joke entity)
        {
            await _dbContext.Jokes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Update(Joke entity)
        {
            var existingJoke = await _dbContext.Jokes.FindAsync(entity.Id.Value);
            if (existingJoke == null)
                return false;

            existingJoke.SetJokeText(entity.Text);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var existingJoke = await _dbContext.Jokes.FindAsync(id);
            if (existingJoke == null)
                return false;

            _dbContext.Jokes.Remove(existingJoke);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
