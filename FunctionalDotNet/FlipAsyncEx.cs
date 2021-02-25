using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class FlipAsyncEx
    {
        public static async Task<IResult> FlipAsync(this IResult<Task> s)
        {
            if (s.IsSuccess) await s.ItemOrDefault;
            return s.IsSuccess ? Result.Success() : Result.Failure(s.Errors);
        }
        public static async Task<IResult<T1>> FlipAsync<T1>(this IResult<Task<T1>> s) =>
            s.IsSuccess ? Result.Success(await s.ItemOrDefault) : Result.Failure<T1>(s.Errors);
    }
}