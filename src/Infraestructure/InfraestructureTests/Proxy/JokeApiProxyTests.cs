using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace Infraestructure.Proxy.Tests
{
    [TestClass]
    public class JokeApiProxyTests
    {
        [TestMethod]
        public async Task GetAsync_ReturnsJoke_WhenRequestIsSuccessful()
        {
            var expectedJoke = "Why did the chicken cross the road? To get to the other side.";
            var handler = new MockHttpMessageHandler(HttpStatusCode.OK, expectedJoke);
            var httpClient = new HttpClient(handler);
            var proxy = new JokeApiProxy(httpClient);

            var result = await proxy.GetAsync("https://api.chucknorris.io/");

            Assert.AreEqual(expectedJoke, result);
        }

        [TestMethod]
        public async Task GetAsync_ThrowsException_WhenRequestFails()
        {
            var handler = new MockHttpMessageHandler(HttpStatusCode.NotFound);
            var httpClient = new HttpClient(handler);
            var proxy = new JokeApiProxy(httpClient);

            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => proxy.GetAsync("https://api.chucknorris.io/"));
        }
    }

    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpStatusCode _statusCode;
        private readonly string _responseContent;

        public MockHttpMessageHandler(HttpStatusCode statusCode, string responseContent = null)
        {
            _statusCode = statusCode;
            _responseContent = responseContent;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(_statusCode);
            if (_responseContent != null)
            {
                response.Content = new StringContent(_responseContent);
            }
            return Task.FromResult(response);
        }
    }
}