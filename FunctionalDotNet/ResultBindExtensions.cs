using System;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class ResultBindExtensions
    {
        // Func<T, Result> -> Func<Result, Result>
        public static IResult<T2> Bind<T1, T2>(this IResult<T1> source, Func<T1, IResult<T2>> f) =>
            source.BindAsync(arg => Task.FromResult(f(arg))).Result;

        // Func<T, Result> -> Func<Result, Result>
        public static IResult Bind<T1>(this IResult<T1> source, Func<T1, IResult> f) =>
            source.BindAsync(arg => Task.FromResult(f(arg))).Result;

        // Func<Result> -> Func<Result, Result>
        public static IResult Bind(this IResult source, Func<IResult> f) =>
            source.BindAsync(() => Task.FromResult(f())).Result;
    }
}