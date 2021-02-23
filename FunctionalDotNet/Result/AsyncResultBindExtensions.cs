using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet.Result
{
    public static class AsyncResultBindExtensions
    {
        // Func<Result> -> Func<Result, Result>
        public static async Task<Result> BindAsync(this Result source, Func<Task<Result>> f)
        {
            if (!source.IsSuccess)
                return Result.Failure(source.Errors.ToArray());

            var result = f();
            return await result;
        }

        // Func<T, Result> -> Func<Result, Result>
        public static async Task<Result> BindAsync<T1>(this Result<T1> source, Func<T1, Task<Result>> f)
        {
            if (!source.IsSuccess)
                return Result.Failure(source.Errors.ToArray());

            var result = f(source.ItemOrDefault);
            return await result;
        }

        // Func<T, Result> -> Func<Result, Result>
        public static async Task<Result> BindAsync<T1>(this Task<Result<T1>> source, Func<T1, Task<Result>> f)
        {
            var r = await source;
            return await r.BindAsync(f);
        }

        // Func<T, Result> -> Func<Result, Result>
        public static async Task<Result<T2>> BindAsync<T1, T2>(this Result<T1> source, Func<T1, Task<Result<T2>>> f)
        {
            if (!source.IsSuccess)
                return Result.Failure<T2>(source.Errors.ToArray());

            var result = f(source.ItemOrDefault);
            return await result;
        }

        // Func<T, Result> -> Func<Result, Result>
        public static async Task<Result<T2>> BindAsync<T1, T2>(this Task<Result<T1>> source, Func<T1, Task<Result<T2>>> f)
        {
            var r = await source;
            return await r.BindAsync(f);
        }
    }
}