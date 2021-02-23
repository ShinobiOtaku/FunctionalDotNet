using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class Sequence
    {
        [Test]
        public void ErrorsAreCombined()
        {
            var subject = Result.Result.Sequence(
                Result.Result.Failure("one"),
                Result.Result.Failure("two"));

            Assert.AreEqual(new[] { "one", "two" }, subject.Errors);
        }

        [Test]
        public void CanSequence()
        {
            var result = Result.Result.Sequence(Result.Result.Success(), Result.Result.Success());
            Assert.AreEqual(true, result.IsSuccess);
        }
    }
}