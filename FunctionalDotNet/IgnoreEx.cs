using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class IgnoreEx
    {
        public static IResult Ignore<T1>(this IResult<T1> s) => s.IsSuccess ? Result.Success() : Result.Failure<T1>(s.Errors);
        public static async Task<IResult> IgnoreAsync<T1>(this Task<IResult<T1>> s) => (await s).Ignore();
    }
}