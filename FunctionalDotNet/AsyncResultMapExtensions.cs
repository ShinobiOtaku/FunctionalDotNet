using System;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class AsyncResultMapExtensions
    {
        // IResult<T1> -> AsyncIResult<T2>
        public static async Task<IResult<T1>> MapAsync<T1, T2>(this IResult<T2> source, Func<T2, Task<T1>> f)
        {
            if (!source.IsSuccess)
                return Result.Failure<T1>(source.Errors);

            var newItem = await f(source.ItemOrDefault);
            return Result.Success(newItem);
        }

        // AsyncIResult<T1> -> AsyncIResult<T2>
        public static async Task<IResult<T1>> MapAsync<T1, T2>(this Task<IResult<T2>> source, Func<T2, Task<T1>> f)
        {
            var r = await source;
            return await r.MapAsync(f);
        }

        // IResult<T1> -> IResult<T2>
        public static async Task<IResult<T1>> MapAsync<T1, T2>(this Task<IResult<T2>> source, Func<T2, T1> f)
        {
            var r = await source;
            return r.Map(f);
        }

        // IResult<T1> -> AsyncResult
        public static async Task<IResult> MapAsync<T1>(this IResult<T1> source, Func<T1, Task> f)
        {
            if (!source.IsSuccess)
                return Result.Failure<T1>(source.Errors);

            await f(source.ItemOrDefault);
            return Result.Success();
        }

        // AsyncIResult<T1> -> AsyncResult
        public static async Task<IResult> MapAsync<T1>(this Task<IResult<T1>> source, Func<T1, Task> f)
        {
            var r = await source;
            return await r.MapAsync(f);
        }

        // IResult<T1> -> Result
        public static async Task<IResult> MapAsync<T1>(this Task<IResult<T1>> source, Action<T1> f)
        {
            var r = await source;
            return r.Map(f);
        }
    }
}