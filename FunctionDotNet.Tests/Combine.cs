using System.Threading.Tasks;
using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class Combine
    {
        private readonly ResultComputation<int, int> _subject;

        public Combine()
        {
            _subject = Result.Combine(
                Result.Success(1),
                Result.Success(1));
        }

        [Test]
        public void ErrorsAreCombined()
        {
            var subject = Result.Combine(
                Result.Failure<int>("one"),
                Result.Failure<int>("two"));

            Assert.AreEqual(new [] { "one", "two"}, subject.Errors);
        }

        [Test]
        public void CanMap()
        {
            var result = _subject.Map(Calculator.Add);
            Assert.AreEqual(2, result.ItemOrDefault);
        }

        [Test]
        public void CanMapToNothing()
        {
            var result = _subject.Map(Calculator.DoNothing);
            Assert.AreEqual(true, result.IsSuccess);
        }

        [Test]
        public async Task CanMapUsingAsyncFunction()
        {
            var result = await _subject.MapAsync(Calculator.AddAsync);
            Assert.AreEqual(2, result.ItemOrDefault);
        }

        [Test]
        public async Task CanMapToNothingUsingAsyncFunction()
        {
            var result = await _subject.MapAsync(Calculator.DoNothingAsync);
            Assert.AreEqual(true, result.IsSuccess);
        }
        
        [Test]
        public void CanBind()
        {
            var result = _subject.Bind(SafeCalculator.Add);
            Assert.AreEqual(2, result.ItemOrDefault);
        }

        [Test]
        public void CanBindToNothing()
        {
            var result = _subject.Bind(SafeCalculator.DoNothing);
            Assert.AreEqual(true, result.IsSuccess);
        }

        [Test]
        public async Task CanBindUsingAsyncFunction()
        {
            var result = await _subject.BindAsync(SafeCalculator.AddAsync);
            Assert.AreEqual(2, result.ItemOrDefault);
        }

        [Test]
        public async Task CanBindToNothingUsingAsyncFunction()
        {
            var result = await _subject.BindAsync(SafeCalculator.DoNothingAsync);
            Assert.AreEqual(true, result.IsSuccess);
        }
    }
}