using NUnit.Framework;

namespace Services.Tests
{
    [TestFixture]
    public class FileServiceTest
    {
        private const string filesLocation = @"..\..\Files\";

        [Test]
        public void Calculate_AddFile_Success()
        {
            Assert.AreEqual(
                new []{"add 2","add 3","apply 1"},
                new FileService().GetLinesFromFile(filesLocation + "add.txt"));
        }

        [Test]
        public void Calculate_AddThenMultiplyFile_Success()
        {
            Assert.AreEqual(
                new[] { "add 2", "multiply 3", "apply 3" },
                new FileService().GetLinesFromFile(filesLocation + "addThenMultiply.txt"));
        }
    }
}
