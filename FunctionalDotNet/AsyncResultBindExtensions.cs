using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class AsyncResultBindExtensions
    {
        // Func<Result> -> Func<Result, Result>
        public static async Task<IResult> BindAsync(this IResult source, Func<Task<IResult>> f)
        {
            if (!source.IsSuccess)
                return Result.Failure(source.Errors);

            var result = f();
            return await result;
        }

        // Func<T, Result> -> Func<Result, Result>
        public static async Task<IResult> BindAsync<T1>(this IResult<T1> source, Func<T1, Task<IResult>> f)
        {
            if (!source.IsSuccess)
                return Result.Failure(source.Errors);

            var result = f(source.ItemOrDefault);
            return await result;
        }

        // AsyncFunc<T, Result> -> AsyncResult
        public static async Task<IResult> BindAsync<T1>(this Task<IResult<T1>> source, Func<T1, IResult> f) => 
            (await source).Bind(f);

        // AsyncFunc<T, Result<T>> -> AsyncResult<T>
        public static async Task<IResult<T2>> BindAsync<T1, T2>(this Task<IResult<T1>> source, Func<T1, IResult<T2>> f) =>
            (await source).Bind(f);

        // Func<T, Result> -> Func<Result, Result>
        public static async Task<IResult> BindAsync<T1>(this Task<IResult<T1>> source, Func<T1, Task<IResult>> f)
        {
            var r = await source;
            return await r.BindAsync(f);
        }

        // Func<T, Result> -> Func<Result, Result>
        public static async Task<IResult<T2>> BindAsync<T1, T2>(this IResult<T1> source, Func<T1, Task<IResult<T2>>> f)
        {
            if (!source.IsSuccess)
                return Result.Failure<T2>(source.Errors);

            var result = f(source.ItemOrDefault);
            return await result;
        }

        // Func<T, Result> -> Func<Result, Result>
        public static async Task<IResult<T2>> BindAsync<T1, T2>(this Task<IResult<T1>> source, Func<T1, Task<IResult<T2>>> f) => 
            await (await source).BindAsync(f);
    }
}