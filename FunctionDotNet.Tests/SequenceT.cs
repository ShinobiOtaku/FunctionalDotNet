using FunctionalDotNet.Result;
using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class SequenceT
    {
        [Test]
        public void ErrorsAreCombined()
        {
            var subject = Result.Result.Sequence(
                Result.Result.Failure<int>("one"),
                Result.Result.Failure<int>("two"));

            Assert.AreEqual(new[] { "one", "two" }, subject.Errors);
        }

        [Test]
        public void CanSequence()
        {
            var result = Result.Result
                .Sequence(Result.Result.Success(1), Result.Result.Success(2))
                .Map(Calculator.Sum);

            Assert.AreEqual(3, result.ItemOrDefault);
        }
    }
}