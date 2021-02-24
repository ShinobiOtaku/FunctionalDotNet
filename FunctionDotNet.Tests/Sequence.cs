using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class Sequence
    {
        [Test]
        public void ErrorsAreCombined()
        {
            var subject = Result.Sequence(
                Result.Failure("one"),
                Result.Failure("two"));

            Assert.AreEqual(new[] { "one", "two" }, subject.Errors);
        }

        [Test]
        public void CanSequence()
        {
            var result = Result.Sequence(Result.Success(), Result.Success());
            Assert.AreEqual(true, result.IsSuccess);
        }
    }
}