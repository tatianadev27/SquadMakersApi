using Domain.Aggregate;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infraestructure.Persintence.Database.Tests
{

    [TestClass]
    public class JokeDbContextTests
    {
        private DbContextOptions<JokeDbContext> _options;

        public  JokeDbContextTests()
        {
            _options = new DbContextOptionsBuilder<JokeDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .EnableSensitiveDataLogging().ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }

        [TestMethod]
        public void AddJokeToDatabase_ShouldSucceed()
        {
            using (var context = new JokeDbContext(_options))
            {
                var joke = Joke.Create(new JokeText("Why did the chicken cross the road? To get to the other side."), new JokeId(1));

                context.Jokes.Add(joke);
                context.SaveChanges();
            }

            using (var context = new JokeDbContext(_options))
            {
                Assert.AreEqual(1, context.Jokes.CountAsync().Result);
            }
        }

        [TestMethod]
        public async Task RetrieveJokeFromDatabase_ShouldSucceedAsync()
        {
            using (var context = new JokeDbContext(_options))
            {
                var joke = Joke.Create(new JokeText("Why did the chicken cross the road? To get to the other side."));
                context.Jokes.Add(joke);
                await context.SaveChangesAsync();
            }

            using (var context = new JokeDbContext(_options))
            {
                var retrievedJoke = await context.Jokes.FirstAsync();
                Assert.IsNotNull(retrievedJoke);
                Assert.AreEqual("Why did the chicken cross the road? To get to the other side.", retrievedJoke.Text.Value);
            }
        }
    }
}