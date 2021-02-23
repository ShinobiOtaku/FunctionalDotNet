using System.Threading.Tasks;
using FunctionalDotNet.Result;

namespace FunctionalDotNet.Tests.Helpers
{
    public static class SafeCalculator
    {
        public static Result<int> AddOne(int i) => Result.Result.Success(++i);
        public static async Task<Result<int>> AddOneAsync(int i) => AddOne(i);

        public static Result<int> Add(int a, int b) => Result.Result.Success(a + b);
        public static async Task<Result<int>> AddAsync(int a, int b) => Add(a,b);

        public static Result.Result DoNothing(int i) => Result.Result.Success();
        public static async Task<Result.Result> DoNothingAsync(int i) => Result.Result.Success();
        public static Result.Result DoNothing(int a, int b) => Result.Result.Success();
        public static async Task<Result.Result> DoNothingAsync(int a, int b) => Result.Result.Success();
    }
}