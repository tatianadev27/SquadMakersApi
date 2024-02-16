using Domain.Aggregate;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Jokes.Commands.Delete.Tests
{
    [TestClass]
    public class DeleteJokeCommandHandlerTests
    {
        [TestMethod]
        public async Task Handle_ReturnsTrue_WhenJokeIsDeleted()
        {
            var jokeId = new JokeId(123);
            var command = new DeleteJokeCommand() { Id = jokeId.Value };
            var existingJoke = Joke.Create(new JokeText("Why did the scarecrow win an award? Because he was outstanding in his field."), jokeId);

            var mockRepository = new Mock<IJokeRepository>();
            mockRepository.Setup(repo => repo.GetById(new JokeId(jokeId.Value))).ReturnsAsync(existingJoke);
            mockRepository.Setup(repo => repo.Delete(jokeId)).ReturnsAsync(true);

            var handler = new DeleteJokeCommandHandler(mockRepository.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsTrue(result);
            mockRepository.Verify(repo => repo.GetById(new JokeId(jokeId.Value)), Times.Once);
            mockRepository.Verify(repo => repo.Delete(jokeId), Times.Once);
        }

        [TestMethod]
        public async Task Handle_ReturnsFalse_WhenJokeNotFound()
        {
            var jokeId = new JokeId(123);
            var command = new DeleteJokeCommand { Id = jokeId.Value };

            var mockRepository = new Mock<IJokeRepository>();
            mockRepository.Setup(repo => repo.GetById(jokeId)).ReturnsAsync((Joke)null);

            var handler = new DeleteJokeCommandHandler(mockRepository.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.IsFalse(result);
            mockRepository.Verify(repo => repo.GetById(new JokeId(jokeId.Value)), Times.Once);
            mockRepository.Verify(repo => repo.Delete(jokeId ), Times.Never);
        }
    }
}