using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Math.Queries.Tests
{
    [TestClass]
    public class GetPlusNumberHandlerTests
    {
        [TestMethod]
        public async Task Handle_ReturnsResult_WhenQueryIsValid()
        {
            var query = new GetPlusNumberQuery(5);
            var handler = new GetPlusNumberHandler();

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(6, result);
        }
    }
}