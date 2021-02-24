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
            var subject = Result.Sequence(
                Result.Failure<int>("one"),
                Result.Failure<int>("two"));

            Assert.AreEqual(new[] { "one", "two" }, subject.Errors);
        }

        [Test]
        public void CanSequence()
        {
            var result = Result
                .Sequence(Result.Success(1), Result.Success(2))
                .Map(Calculator.Sum);

            Assert.AreEqual(3, result.ItemOrDefault);
        }
    }
}