using Domain.Aggregate;
using Domain.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Services.Tests
{
    [TestClass]
    public class DadJokeServiceTests
    {
        [TestMethod]
        public async Task GetRandomJoke_ReturnsJoke_WhenApiProxyReturnsText()
        {
            var jokeText = "Why don't skeletons fight each other? They don't have the guts.";
            var mockProxy = new Mock<IJokeApiProxy>();
            mockProxy.Setup(proxy => proxy.GetAsync(It.IsAny<string>())).ReturnsAsync(jokeText);

            var service = new DadJokeService(mockProxy.Object);

            var result = await service.GetRandomJoke();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Joke));
            Assert.AreEqual(jokeText, result.Text.Value);
            mockProxy.Verify(proxy => proxy.GetAsync(It.IsAny<string>()), Times.Once);
        }
    }
}