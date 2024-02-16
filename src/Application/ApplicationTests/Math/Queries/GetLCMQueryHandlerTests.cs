using Application.Services;
using Domain.Aggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Math.Queries.Tests
{
    [TestClass]
    public class GetLCMQueryHandlerTests
    {
        [TestMethod]
        public async Task Handle_ReturnsLeastCommonMultiple_WhenQueryIsValid()
        {
            var query = new GetLCMQuery(new List<int> { 4, 6, 8 });
            var handler = new GetLCMQueryHandler();

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.AreEqual(24, result);
        }
    }
}