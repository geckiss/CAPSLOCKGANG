using NUnit.Framework;

namespace CAPSLOCKGANG.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetSeedAndPhrase_ThrowsException_When_EntropyIsNull()
        {
            Assert.Fail();
        }

        [Test]
        public void GetSeedAndPhrase_ReturnsData_When_EntropyIsValid()
        {
            Assert.Fail();
        }

        // etc ...
    }
}