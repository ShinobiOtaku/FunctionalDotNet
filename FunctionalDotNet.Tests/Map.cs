using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class Map
    {
        private readonly IResult<int> _subject;

        public Map() => _subject = Result.Success(1);

        [Test]
        public void CanMapToAnotherType()
        {
            var result = _subject.Map(Calculator.AddOne);
            Assert.AreEqual(2, result.ItemOrDefault);
        }

        [Test]
        public void CanMapToNothing()
        {
            var result = _subject.Map(Calculator.DoNothing);
            Assert.AreEqual(true, result.IsSuccess);
        }
    }
}