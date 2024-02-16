using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Math.Entities.Tests
{
    [TestClass]
    public class PlusNumberResultTests
    {
        [TestMethod]
        public void Calculate_WhenNumberIsPositive_ResultIsCorrect()
        {
            int number = 5;
            int expected = 6;

            int result = PlusNumberResult.Calculate(number);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Calculate_WhenNumberIsZero_ResultIsCorrect()
        {
            int number = 0;
            int expected = 1;

            int result = PlusNumberResult.Calculate(number);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Calculate_WhenNumberIsNegative_ResultIsCorrect()
        {
            int number = -5;
            int expected = -4;

            int result = PlusNumberResult.Calculate(number);

            Assert.AreEqual(expected, result);
        }
    }
}