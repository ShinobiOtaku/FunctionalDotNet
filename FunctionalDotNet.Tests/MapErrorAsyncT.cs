using System.Linq;
using System.Threading.Tasks;
using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class MapErrorAsyncT
    {
        private readonly IResult<int> _subject;

        public MapErrorAsyncT() => _subject = Result.Failure<int>("error");

        [Test]
        public async Task CanMapErrorUsingAsyncFunction()
        {
            var result = await _subject.MapErrorAsync(Text.ToUpperAsync);
            Assert.AreEqual("ERROR", result.Errors.Single());
        }

        [Test]
        public async Task CanMapErrorAnAsyncResult()
        {
            var result = await Task.FromResult(_subject).MapErrorAsync(Text.ToUpper);
            Assert.AreEqual("ERROR", result.Errors.Single());
        }

        [Test]
        public async Task CanErrorAnAsyncResultUsingAsyncFunction()
        {
            var result = await Task.FromResult(_subject).MapErrorAsync(Text.ToUpperAsync);
            Assert.AreEqual("ERROR", result.Errors.Single());
        }
    }
}