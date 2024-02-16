using Application.Commands.Create;
using Application.Commands.Update;
using Application.Jokes.Commands.Delete;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SquadMakersApi.Controllers.Tests
{
    [TestClass]
    public class JokesControllerTests
    {
        [TestMethod]
        public async Task GetJoke_ReturnsOkResult_WhenQueryIsValid()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetRandomJokeQuery>(), default))
                        .ReturnsAsync("Test Joke");

            var controller = new JokesController(mediatorMock.Object);

            var result = await controller.GetJoke("Chuck");

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual("Test Joke", ((OkObjectResult)result).Value);
        }

        [TestMethod]
        public async Task CreateJoke_ReturnsCreatedResult_WhenCommandIsValid()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<CreateJokeCommand>(), default))
                        .ReturnsAsync(true);

            var controller = new JokesController(mediatorMock.Object);
            var command = new CreateJokeCommand("Test Joke");

            var result = await controller.CreateJoke(command);

            Assert.IsInstanceOfType(result, typeof(CreatedResult));
        }

        [TestMethod]
        public async Task UpdateJoke_ReturnsOkResult_WhenCommandIsValid()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<UpdateJokeCommand>(), default))
                        .ReturnsAsync(true);

            var controller = new JokesController(mediatorMock.Object);
            var command = new UpdateJokeCommand();

            var result = await controller.UpdateJoke(command);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteJoke_ReturnsOkResult_WhenCommandIsValid()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<DeleteJokeCommand>(), default))
                        .ReturnsAsync(true);

            var controller = new JokesController(mediatorMock.Object);
            var command = new DeleteJokeCommand();

            var result = await controller.DeleteJoke(command);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}