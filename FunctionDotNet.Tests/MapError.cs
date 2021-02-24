using System.Linq;
using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class MapError
    {
        private readonly Result _subject;

        public MapError() => _subject = Result.Failure("error");

        [Test]
        public void CanMapError()
        {
            var result = _subject.MapError(Text.ToUpper);
            Assert.AreEqual("ERROR", result.Errors.Single());
        }
    }
}