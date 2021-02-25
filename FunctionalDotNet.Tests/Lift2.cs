using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
    [TestFixture]
    public class Lift2
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