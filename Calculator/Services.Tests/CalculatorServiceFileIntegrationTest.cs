using NUnit.Framework;

namespace Services.Tests
{
    [TestFixture]
    public class CalculatorServiceFileIntegrationTest
    {
        private const string filesLocation = @"..\..\Files\";

        [Test]
        public void Calculate_AddFile_Success()
        {
            var linesFromFile = new FileService().GetLinesFromFile(filesLocation + "add.txt");
            Assert.AreEqual(6, new CalculatorService().Calculate(linesFromFile));
        }

        [Test]
        public void Calculate_AddThenMultiplyFile_Success()
        {
            var linesFromFile = new FileService().GetLinesFromFile(filesLocation + "addThenMultiply.txt");
            Assert.AreEqual(15, new CalculatorService().Calculate(linesFromFile));
        }
    }
}
