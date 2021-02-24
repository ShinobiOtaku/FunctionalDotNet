using System.Threading.Tasks;

namespace FunctionalDotNet.Tests.Helpers
{
    public static class SafeCalculator
    {
        public static Result<int> AddOne(int i) => Result.Success(++i);
        public static async Task<Result<int>> AddOneAsync(int i) => AddOne(i);

        public static Result<int> Add(int a, int b) => Result.Success(a + b);
        public static async Task<Result<int>> AddAsync(int a, int b) => Add(a,b);

        public static Result DoNothing(int i) => Result.Success();
        public static async Task<Result> DoNothingAsync(int i) => Result.Success();
        public static Result DoNothing(int a, int b) => Result.Success();
        public static async Task<Result> DoNothingAsync(int a, int b) => Result.Success();
    }
}