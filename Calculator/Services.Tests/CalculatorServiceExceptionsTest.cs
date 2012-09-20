using System;
using System.Linq;
using NUnit.Framework;

namespace Services.Tests
{
    [TestFixture]
    public class CalculatorServiceExceptionsTest
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void Calculate_NoApplyLine_Exception()
        {
            var operations = new[] { "add 44" };
            new CalculatorService().Calculate(operations);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void Calculate_IncorrectEmptyLine_Exception()
        {
            var operations = new[] { "" };
            new CalculatorService().Calculate(operations);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void Calculate_IncorrectLine_Exception()
        {
            var operations = new[] { "ad 5", "apply 5" };
            new CalculatorService().Calculate(operations);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(InvalidOperationException))]
        public void Calculate_EmptyInput_Exception()
        {
            new CalculatorService().Calculate(Enumerable.Empty<string>());
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ApplicationException))]
        public void Calculate_DecimalInput_Success()
        {
            var operations = new[] { "add 2.5", "apply 4" };
            new CalculatorService().Calculate(operations);
        }
    }
}
