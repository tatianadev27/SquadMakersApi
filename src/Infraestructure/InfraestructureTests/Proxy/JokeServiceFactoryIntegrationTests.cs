using Application.Services;
using Application.Services.Factory;
using Infraestructure.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureTests.Proxy
{
    [TestClass]
    public class JokeServiceFactoryIntegrationTests
    {
        [TestMethod]
        public async Task Create_ReturnsCorrectService_WhenTypeIsValid()
        {
            var chuckService = new ChuckNorrisJokeService(new JokeApiProxy(new HttpClient()));
            var dadService = new DadJokeService(new JokeApiProxy(new HttpClient()));

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(provider => provider.GetService(typeof(ChuckNorrisJokeService))).Returns(chuckService);
            serviceProviderMock.Setup(provider => provider.GetService(typeof(DadJokeService))).Returns(dadService);

            var factory = new JokeServiceFactory(serviceProviderMock.Object);

            var chuckServiceFromFactory = factory.Create("chuck");
            var dadServiceFromFactory = factory.Create("dad");

            Assert.IsNotNull(chuckServiceFromFactory);
            Assert.IsNotNull(dadServiceFromFactory);
            Assert.IsInstanceOfType(chuckServiceFromFactory, typeof(ChuckNorrisJokeService));
            Assert.IsInstanceOfType(dadServiceFromFactory, typeof(DadJokeService));
        }
    }
}
