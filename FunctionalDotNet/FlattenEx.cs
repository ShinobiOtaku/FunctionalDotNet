using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class FlattenEx
    {
        public static IResult<T1> Flatten<T1>(this IResult<IResult<T1>> s) =>
            s.IsSuccess && s.ItemOrDefault.IsSuccess
                ? Result.Success(s.ItemOrDefault.ItemOrDefault)
                : Result.Failure<T1>(s.Errors.Concat(s.ItemOrDefault.Errors));
        public static async Task<IResult<T1>> FlattenAsync<T1>(this Task<IResult<IResult<T1>>> s) => (await s).Flatten();
    }
}