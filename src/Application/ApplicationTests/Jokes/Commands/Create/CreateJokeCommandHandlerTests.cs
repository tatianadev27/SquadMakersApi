using Domain.Aggregate;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Commands.Create.Tests
{
    [TestClass]
    public class CreateJokeCommandHandlerTests
    {
        [TestMethod]
        public async Task Handle_ReturnsJokeId_WhenCommandIsValid()
        {
            string jokeText = "Why did the scarecrow win an award? Because he was outstanding in his field.";
            var joke = Joke.Create(new JokeText(jokeText), new JokeId(1));

            var mockRepository = new Mock<IJokeRepository>();
            mockRepository.Setup(repo => repo.Add(It.IsAny<Joke>())).ReturnsAsync(joke);

            var command = new CreateJokeCommand(jokeText);
            var handler = new CreateJokeCommandHandler(mockRepository.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            mockRepository.Verify(repo => repo.Add(It.IsAny<Joke>()), Times.Once);
        }
    }
}