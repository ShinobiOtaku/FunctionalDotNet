using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class AsyncResultMapExtensions
    {
        // Result<T1> -> AsyncResult<T2>
        public static async Task<Result<T1>> MapAsync<T1, T2>(this Result<T2> source, Func<T2, Task<T1>> f)
        {
            if (!source.IsSuccess)
                return Result.Failure<T1>(source.Errors.ToArray());

            var newItem = await f(source.ItemOrDefault);
            return Result.Success(newItem);
        }

        // AsyncResult<T1> -> AsyncResult<T2>
        public static async Task<Result<T1>> MapAsync<T1, T2>(this Task<Result<T2>> source, Func<T2, Task<T1>> f)
        {
            var r = await source;
            return await r.MapAsync(f);
        }

        // Result<T1> -> Result<T2>
        public static async Task<Result<T1>> MapAsync<T1, T2>(this Task<Result<T2>> source, Func<T2, T1> f)
        {
            var r = await source;
            return r.Map(f);
        }

        // Result<T1> -> AsyncResult
        public static async Task<Result> MapAsync<T1>(this Result<T1> source, Func<T1, Task> f)
        {
            if (!source.IsSuccess)
                return Result.Failure<T1>(source.Errors.ToArray());

            await f(source.ItemOrDefault);
            return Result.Success();
        }

        // AsyncResult<T1> -> AsyncResult
        public static async Task<Result> MapAsync<T1>(this Task<Result<T1>> source, Func<T1, Task> f)
        {
            var r = await source;
            return await r.MapAsync(f);
        }

        // Result<T1> -> Result
        public static async Task<Result> MapAsync<T1>(this Task<Result<T1>> source, Action<T1> f)
        {
            var r = await source;
            return r.Map(f);
        }
    }
}