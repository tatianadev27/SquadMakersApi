using Domain.Aggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Services.Tests
{
    [TestClass]
    public class RandomJokeServiceTests
    {
        [TestMethod]
        public async Task GetRandomJoke_ReturnsJoke()
        {
            var service = new RandomJokeService();

            var result = await service.GetRandomJoke();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Joke));
        }
    }
}