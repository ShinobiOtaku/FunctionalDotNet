using System;
using System.Threading.Tasks;

namespace FunctionalDotNet.Result
{
    public static class ResultBindExtensions
    {
        // Func<T, Result> -> Func<Result, Result>
        public static Result<T2> Bind<T1, T2>(this Result<T1> source, Func<T1, Result<T2>> f) =>
            source.BindAsync(arg => Task.FromResult(f(arg))).Result;

        // Func<T, Result> -> Func<Result, Result>
        public static Result Bind<T1>(this Result<T1> source, Func<T1, Result> f) =>
            source.BindAsync(arg => Task.FromResult(f(arg))).Result;

        // Func<Result> -> Func<Result, Result>
        public static Result Bind(this Result source, Func<Result> f) =>
            source.BindAsync(() => Task.FromResult(f())).Result;
    }
}