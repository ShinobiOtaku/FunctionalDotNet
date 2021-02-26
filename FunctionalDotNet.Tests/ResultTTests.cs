using System.Linq;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class ResultTTests
    {
        [Test]
        public void Default()
        {
            Result<int> subject = default;
            Assert.False(subject.IsSuccess);
            Assert.AreEqual(1, subject.Errors.Count());
        }

        [Test]
        public void Success()
        {
            var subject = Result.Success(1);
            Assert.True(subject.IsSuccess);
            Assert.AreEqual(0, subject.Errors.Count());
            Assert.AreEqual(1, subject.ItemOrDefault);
        }

        [Test]
        public void NoError()
        {
            var subject = Result.Failure<object>();
            Assert.False(subject.IsSuccess);
            Assert.AreEqual(0, subject.Errors.Count());
            Assert.IsNull(subject.ItemOrDefault);
        }

        [Test]
        public void OneError()
        {
            var subject = Result.Failure<object>("error");
            Assert.False(subject.IsSuccess);
            Assert.AreEqual(new[] { "error" }, subject.Errors);
            Assert.IsNull(subject.ItemOrDefault);
        }

        [Test]
        public void ManyErrors()
        {
            var subject = Result.Failure<object>("a", "b");
            Assert.False(subject.IsSuccess);
            Assert.AreEqual(new[] { "a", "b" }, subject.Errors);
            Assert.IsNull(subject.ItemOrDefault);
        }
    }
}