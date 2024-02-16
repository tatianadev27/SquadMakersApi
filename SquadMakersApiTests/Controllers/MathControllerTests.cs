using Application.Math.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SquadMakersApi.Controllers.Tests
{
    [TestClass]
    public class MathControllerTests
    {
        [TestMethod]
        public async Task GetLeastCommonMultiple_ReturnsOkResult_WhenQueryIsValid()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetLCMQuery>(), default))
                        .ReturnsAsync(10);

            var controller = new MathController(mediatorMock.Object);
            var numbers = new List<int> { 2, 5 };

            var result = await controller.GetLeastCommonMultiple(numbers);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(10, ((OkObjectResult)result).Value);
        }

        [TestMethod]
        public async Task GetLeastCommonMultiple_ReturnsBadRequest_WhenQueryIsInvalid()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetLCMQuery>(), default))
                        .ThrowsAsync(new InvalidOperationException("Invalid query"));

            var controller = new MathController(mediatorMock.Object);
            var numbers = new List<int> { 2, 5 };

            var result = await controller.GetLeastCommonMultiple(numbers);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual("Invalid query", ((BadRequestObjectResult)result).Value);
        }

        [TestMethod]
        public async Task GetPlusNumber_ReturnsOkResult_WhenQueryIsValid()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetPlusNumberQuery>(), default))
                        .ReturnsAsync(6);

            var controller = new MathController(mediatorMock.Object);
            var number = 5;

            var result = await controller.GetPlusNumber(number);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(6, ((OkObjectResult)result).Value);
        }

        [TestMethod]
        public async Task GetPlusNumber_ReturnsBadRequest_WhenQueryIsInvalid()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetPlusNumberQuery>(), default))
                        .ThrowsAsync(new InvalidOperationException("Invalid query"));

            var controller = new MathController(mediatorMock.Object);
            var number = 5;

            var result = await controller.GetPlusNumber(number);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual("Invalid query", ((BadRequestObjectResult)result).Value);
        }
    }
}