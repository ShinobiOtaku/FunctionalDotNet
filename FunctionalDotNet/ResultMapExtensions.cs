using System;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class ResultMapExtensions
    {
        // Result<T1> -> Result<T2>
        public static IResult<T2> Map<T1, T2>(this IResult<T1> source, Func<T1, T2> f) =>
            source.MapAsync(arg => Task.FromResult(f(arg))).Result;

        // Result<T1> -> Result
        public static IResult Map<T1>(this IResult<T1> source, Action<T1> f) =>
            source.MapAsync(async arg => f(arg)).Result;
    }
}