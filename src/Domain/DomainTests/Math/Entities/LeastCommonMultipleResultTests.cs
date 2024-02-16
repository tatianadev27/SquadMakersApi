using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Math.Entities.Tests
{
    [TestClass]
    public class LeastCommonMultipleResultTests
    {
        [TestMethod]
        public void Calculate_ThrowsException_WhenNumbersListIsNull()
        {
            List<int> numbers = null;

            Assert.ThrowsException<ArgumentException>(() => LeastCommonMultipleResult.Calculate(numbers));
        }

        [TestMethod]
        public void Calculate_ThrowsException_WhenNumbersListIsEmpty()
        {
            List<int> numbers = new List<int>();

            Assert.ThrowsException<ArgumentException>(() => LeastCommonMultipleResult.Calculate(numbers));
        }

        [TestMethod]
        public void Calculate_ReturnsCorrectResult_WhenNumbersListHasSingleElement()
        {
            List<int> numbers = new List<int> { 5 };
            int expected = 5;

            int result = LeastCommonMultipleResult.Calculate(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Calculate_ReturnsCorrectResult_WhenNumbersListHasMultipleElements()
        {
            List<int> numbers = new List<int> { 2, 3, 4 };
            int expected = 12;

            int result = LeastCommonMultipleResult.Calculate(numbers);

            Assert.AreEqual(expected, result);
        }
    }
}