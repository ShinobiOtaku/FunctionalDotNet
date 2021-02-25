using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class Map
    {
        private readonly IResult<int> _subject;

        public Map() => _subject = Result.Success(1);

        [Test]
        public void CanMapToAnotherType()
        {
            var result = _subject.Map(Calculator.AddOne);
            Assert.AreEqual(2, result.ItemOrDefault);
        }

        [Test]
        public void CanMapToNothing()
        {
            var result = _subject.Map(Calculator.DoNothing);
            Assert.AreEqual(true, result.IsSuccess);
        }
    }

    [TestFixture]
    public class Lift1
    {
        [Test]
        public void CanMapWithAnotherFunction()
        {
            var addOne = Result.Lift<int, int>(Calculator.AddOne);
            var addTwo = addOne.Map(Calculator.AddOne);
            var result = addTwo(Result.Success(0)).ItemOrDefault;

            Assert.AreEqual(2, result);
        }

        [Test]
        public void CanBindWithAnotherFunction()
        {
            var addOne = Result.Lift<int, int>(SafeCalculator.AddOne);
            var addTwo = addOne.Bind(SafeCalculator.AddOne);
            var result = addTwo(Result.Success(0)).ItemOrDefault;

            Assert.AreEqual(2, result);
        }
    }

    [TestFixture]
    public class Lift2Map
    {
        [Test]
        public void CanMapWithAnotherFunction()
        {
            var addTwo = Result
                .Lift<int, int, int>(Calculator.Add)
                .Map(Calculator.AddOne)
                .Apply(Result.Success(1));

            var result = addTwo(Result.Success(1)).ItemOrDefault;

            Assert.AreEqual(3, result);
        }

        [Test]
        public void CanBindWithAnotherFunction()
        {
            var addTwo = Result
                .Lift<int, int, int>(SafeCalculator.Add)
                .Bind(SafeCalculator.AddOne)
                .Apply(Result.Success(1));

            var result = addTwo(Result.Success(1)).ItemOrDefault;

            Assert.AreEqual(3, result);
        }
    }
}