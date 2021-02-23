using System;
using System.Threading.Tasks;

namespace FunctionalDotNet.Result
{
    public static class ResultMapExtensions
    {
        // Result<T1> -> Result<T2>
        public static Result<T1> Map<T1, T2>(this Result<T2> source, Func<T2, T1> f) =>
            source.MapAsync(arg => Task.FromResult(f(arg))).Result;

        // Result<T1> -> Result
        public static Result Map<T1>(this Result<T1> source, Action<T1> f) =>
            source.MapAsync(async arg => f(arg)).Result;
    }
}