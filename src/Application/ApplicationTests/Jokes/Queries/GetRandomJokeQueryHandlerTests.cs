using Domain.Aggregate;
using Domain.Entities;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Queries.Tests
{
    [TestClass]
    public class GetRandomJokeQueryHandlerTests
    {
        [TestMethod]
        public async Task Handle_ReturnsJokeText_WhenQueryIsValid()
        {
            var jokeType = "SomeType";
            var query = new GetRandomJokeQuery(jokeType);
            var randomJokeText = "Why don't scientists trust atoms? Because they make up everything.";
            var joke = Joke.Create(new JokeText(randomJokeText));
            var mockService = new Mock<IJokeService>();
            mockService.Setup(service => service.GetRandomJoke()).ReturnsAsync(joke);

            var mockFactory = new Mock<IJokeServiceFactory>();
            mockFactory.Setup(factory => factory.Create(jokeType)).Returns(mockService.Object);

            var handler = new GetRandomJokeQueryHandler(mockFactory.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(randomJokeText, result);
            mockFactory.Verify(factory => factory.Create(jokeType), Times.Once);
            mockService.Verify(service => service.GetRandomJoke(), Times.Once);
        }
    }
}