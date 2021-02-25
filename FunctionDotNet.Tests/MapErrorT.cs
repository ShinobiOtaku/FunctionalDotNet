using System.Linq;
using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class MapErrorT
    {
        private readonly IResult<int> _subject;

        public MapErrorT() => _subject = Result.Failure<int>("error");

        [Test]
        public void CanMapError()
        {
            var result = _subject.MapError(Text.ToUpper);
            Assert.AreEqual("ERROR", result.Errors.Single());
        }
    }
}