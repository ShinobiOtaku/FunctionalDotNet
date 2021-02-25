using System.Threading.Tasks;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class SequenceAsync
    {
        [Test]
        public async Task ErrorsAreCombined()
        {
            var subject = await Result.SequenceAsync(
                Task.FromResult(Result.Failure("one")),
                Task.FromResult(Result.Failure("two")));

            Assert.AreEqual(new[] { "one", "two" }, subject.Errors);
        }

        [Test]
        public async Task CanSequenceAsync()
        {
            var result = await Result.SequenceAsync(
                Task.FromResult(Result.Success()),
                Task.FromResult(Result.Success()));

            Assert.AreEqual(true, result.IsSuccess);
        }
    }
}