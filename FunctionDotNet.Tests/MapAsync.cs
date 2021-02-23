using System.Threading.Tasks;
using FunctionalDotNet.Result;
using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class MapAsync
    {
        private readonly Result<int> _subject;

        public MapAsync() => _subject = Result.Result.Success(1);
        
        [Test]
        public async Task CanMapUsingAsyncFunction()
        {
            var result = await _subject.MapAsync(Calculator.AddOneAsync);
            Assert.AreEqual(2, result.ItemOrDefault);
        }

        [Test]
        public async Task CanMapAnAsyncResult()
        {
            var result = await Task.FromResult(_subject).MapAsync(Calculator.AddOne);
            Assert.AreEqual(2, result.ItemOrDefault);
        }

        [Test]
        public async Task CanMapAnAsyncResultUsingAsyncFunction()
        {
            var result = await Task.FromResult(_subject).MapAsync(Calculator.AddOneAsync);
            Assert.AreEqual(2, result.ItemOrDefault);
        }

        [Test]
        public async Task CanMapToNothingUsingAsyncFunction()
        {
            var result = await _subject.MapAsync(Calculator.DoNothingAsync);
            Assert.AreEqual(true, result.IsSuccess);
        }

        [Test]
        public async Task CanMapAnAsyncResultToNothing()
        {
            var result = await Task.FromResult(_subject).MapAsync(Calculator.DoNothing);
            Assert.AreEqual(true, result.IsSuccess);
        }

        [Test]
        public async Task CanMapAnAsyncResultToNothingUsingAsyncFunction()
        {
            var result = await Task.FromResult(_subject).MapAsync(Calculator.DoNothingAsync);
            Assert.AreEqual(true, result.IsSuccess);
        }
    }
}