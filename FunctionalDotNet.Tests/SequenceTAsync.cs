using System.Threading.Tasks;
using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class SequenceTAsync
    {
        [Test]
        public async Task ErrorsAreCombined()
        {
            var subject = await Result.SequenceAsync(
                Task.FromResult(Result.Failure<int>("one")),
                Task.FromResult(Result.Failure<int>("two")));

            Assert.AreEqual(new[] { "one", "two" }, subject.Errors);
        }

        [Test]
        public async Task CanSequenceAsync()
        {
            var result = await Result
                .SequenceAsync(
                    Task.FromResult(Result.Success(1)),
                    Task.FromResult(Result.Success(2)))
                .MapAsync(Calculator.Sum);

            Assert.AreEqual(3, result.ItemOrDefault);
        }
    }
}