using System.Threading.Tasks;

namespace FunctionalDotNet.Tests.Helpers
{
    public static class SafeCalculator
    {
        public static IResult<int> AddOne(int i) => Result.Success(++i);
        public static async Task<IResult<int>> AddOneAsync(int i) => AddOne(i);

        public static IResult<int> Add(int a, int b) => Result.Success(a + b);
        public static async Task<IResult<int>> AddAsync(int a, int b) => Add(a,b);

        public static IResult DoNothing(int i) => Result.Success();
        public static async Task<IResult> DoNothingAsync(int i) => Result.Success();
        public static IResult DoNothing(int a, int b) => Result.Success();
        public static async Task<IResult> DoNothingAsync(int a, int b) => Result.Success();
    }
}