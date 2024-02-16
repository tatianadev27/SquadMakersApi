using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Services.Factory.Tests
{
    [TestClass]
    public class JokeServiceFactoryTests
    {
        [TestMethod]
        public void Create_ReturnsCorrectService_WhenTypeIsValid()
        {
            var serviceProviderMock = new Mock<IServiceProvider>();

            var chuckServiceMock = new Mock<ChuckNorrisJokeService>();
            var dadServiceMock = new Mock<DadJokeService>();
            var randomServiceMock = new Mock<RandomJokeService>();

            serviceProviderMock.Setup(provider => provider.GetService(typeof(ChuckNorrisJokeService))).Returns(chuckServiceMock.Object);
            serviceProviderMock.Setup(provider => provider.GetService(typeof(DadJokeService))).Returns(dadServiceMock.Object);
            serviceProviderMock.Setup(provider => provider.GetService(typeof(RandomJokeService))).Returns(randomServiceMock.Object);

            var factory = new JokeServiceFactory(serviceProviderMock.Object);

            var chuckService = factory.Create("chuck");
            var dadService = factory.Create("dad");
            var randomService = factory.Create(null);

            Assert.IsNotNull(chuckService);
            Assert.IsNotNull(dadService);
            Assert.IsNotNull(randomService);

            Assert.IsInstanceOfType(chuckService, typeof(ChuckNorrisJokeService));
            Assert.IsInstanceOfType(dadService, typeof(DadJokeService));
            Assert.IsInstanceOfType(randomService, typeof(RandomJokeService));

            serviceProviderMock.Verify(provider => provider.GetService(typeof(ChuckNorrisJokeService)), Times.Once);
            serviceProviderMock.Verify(provider => provider.GetService(typeof(DadJokeService)), Times.Once);
            serviceProviderMock.Verify(provider => provider.GetService(typeof(RandomJokeService)), Times.Once);
        }

        [TestMethod]
        public void Create_ThrowsException_WhenTypeIsInvalid()
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            var factory = new JokeServiceFactory(serviceProviderMock.Object);

            Assert.ThrowsException<InvalidOperationException>(() => factory.Create("invalid"));
        }
    }
}