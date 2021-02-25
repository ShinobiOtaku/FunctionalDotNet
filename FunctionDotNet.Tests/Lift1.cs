using FunctionalDotNet.Tests.Helpers;
using NUnit.Framework;

namespace FunctionalDotNet.Tests
{
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
}