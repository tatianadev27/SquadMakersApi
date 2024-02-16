using Application.Commands.Update;
using Domain.Aggregate;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Jokes.Commands.Update.Tests
{
    [TestClass]
    public class UpdateJokeCommandHandlerTests
    {
        [TestMethod]
        public async Task Handle_ReturnsTrue_WhenJokeIsUpdated()
        {
            var jokeId = new JokeId(123);
            var command = new UpdateJokeCommand { Id = jokeId.Value, Text = "New joke text" };
            var existingJoke = Joke.Create(new JokeText("Old joke text"), jokeId);

            var mockRepository = new Mock<IJokeRepository>();
            mockRepository.Setup(repo => repo.GetById(jokeId.Value)).ReturnsAsync(existingJoke);
            mockRepository.Setup(repo => repo.Update(It.IsAny<Joke>())).ReturnsAsync(true);

            var handler = new UpdateJokeCommandHandler(mockRepository.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsTrue(result);
            mockRepository.Verify(repo => repo.GetById(jokeId.Value), Times.Once);
            mockRepository.Verify(repo => repo.Update(It.IsAny<Joke>()), Times.Once);
        }

        [TestMethod]
        public async Task Handle_ReturnsFalse_WhenJokeNotFound()
        {
            var jokeId = new JokeId(123);
            var command = new UpdateJokeCommand { Id = jokeId.Value, Text = "New joke text" };

            var mockRepository = new Mock<IJokeRepository>();
            mockRepository.Setup(repo => repo.GetById(jokeId.Value)).ReturnsAsync((Joke)null); 

            var handler = new UpdateJokeCommandHandler(mockRepository.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsFalse(result);
            mockRepository.Verify(repo => repo.GetById(jokeId.Value), Times.Once);
            mockRepository.Verify(repo => repo.Update(It.IsAny<Joke>()), Times.Never);
        }
    }
}