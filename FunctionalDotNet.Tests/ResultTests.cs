using System.Linq;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class ResultTests
    {
        [Test]
        public void Default()
        {
            Result subject = default;
            Assert.False(subject.IsSuccess);
            Assert.AreEqual(1, subject.Errors.Count());
        }

        [Test]
        public void Success()
        {
            var subject = Result.Success();
            Assert.True(subject.IsSuccess);
            Assert.AreEqual(0, subject.Errors.Count());
        }

        [Test]
        public void NoError()
        {
            var subject = Result.Failure();
            Assert.False(subject.IsSuccess);
            Assert.AreEqual(0, subject.Errors.Count());
        }

        [Test]
        public void OneError()
        {
            var subject = Result.Failure("error");
            Assert.False(subject.IsSuccess);
            Assert.AreEqual(new [] {"error"}, subject.Errors);
        }

        [Test]
        public void ManyErrors()
        {
            var subject = Result.Failure("a", "b");
            Assert.False(subject.IsSuccess);
            Assert.AreEqual(new[] { "a", "b" }, subject.Errors);
        }
    }
}