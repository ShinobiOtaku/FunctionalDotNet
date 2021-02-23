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
            var subject = await Result.Result.SequenceAsync(
                Task.FromResult(Result.Result.Failure("one")),
                Task.FromResult(Result.Result.Failure("two")));

            Assert.AreEqual(new[] { "one", "two" }, subject.Errors);
        }

        [Test]
        public async Task CanSequenceAsync()
        {
            var result = await Result.Result.SequenceAsync(
                Task.FromResult(Result.Result.Success()),
                Task.FromResult(Result.Result.Success()));

            Assert.AreEqual(true, result.IsSuccess);
        }
    }
}