using NUnit.Framework;

namespace Services.Tests
{
    [TestFixture]
    public class CalculatorServiceSuccessTest
    {
        [Test]
        public void Calculate_NegativeValue_Success()
        {
            var operations = new []{"substract 4", "apply 2"};
            Assert.AreEqual(-2, new CalculatorService().Calculate(operations));
        }

        [Test]
        public void Calculate_CaseInsensitiveOperations_Success()
        {
            var operations = new[] { "SuBsTraCT 2", "APPly 4" };
            Assert.AreEqual(2, new CalculatorService().Calculate(operations));
        }

        [Test]
        public void Calculate_DecimalResult_Success()
        {
            var operations = new[] { "divide 2", "apply 3" };
            Assert.AreEqual(1.5, new CalculatorService().Calculate(operations));
        }

        [Test]
        public void Calculate_JustApplyLine_Success()
        {
            var operations = new[] { "apply 2" };
            Assert.AreEqual(2, new CalculatorService().Calculate(operations));
        }

        [Test]
        public void Calculate_ComplexOperation_Success()
        {
            var operations = new[] { "add 44", "multiply 5", "substract 4", "divide 2", "apply 2" };
            Assert.AreEqual(113, new CalculatorService().Calculate(operations));
        }
    }
}
