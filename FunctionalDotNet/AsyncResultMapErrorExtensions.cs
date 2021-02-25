using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class AsyncResultMapErrorExtensions
    {
        // Change error message(s)
        public static async Task<IResult<T1>> MapErrorAsync<T1>(this IResult<T1> source, Func<string, Task<string>> f)
        {
            if (!source.IsSuccess)
            {
                var errors = await Task.WhenAll(source.Errors.Select(f));
                return Result.Failure<T1>(errors);
            }

            return Result.Success(source.ItemOrDefault);
        }

        // Change error message(s)
        public static async Task<IResult<T1>> MapErrorAsync<T1>(this Task<IResult<T1>> source, Func<string, Task<string>> f)
        {
            var r = await source;
            return await r.MapErrorAsync(f);
        }

        // Change error message(s)
        public static async Task<IResult<T1>> MapErrorAsync<T1>(this Task<IResult<T1>> source, Func<string, string> f)
        {
            var r = await source;
            return r.MapError(f);
        }

        // Change error message(s)
        public static async Task<IResult> MapErrorAsync(this IResult source, Func<string, Task<string>> f)
        {
            if (!source.IsSuccess)
            {
                var errors = await Task.WhenAll(source.Errors.Select(f));
                return Result.Failure(errors);
            }

            return Result.Success();
        }

        // Change error message(s)
        public static async Task<IResult> MapErrorAsync(this Task<IResult> source, Func<string, string> f)
        {
            var r = await source;
            return r.MapError(f);
        }

        // Change error message(s)
        public static async Task<IResult> MapErrorAsync(this Task<IResult> source, Func<string, Task<string>> f)
        {
            var r = await source;
            return await r.MapErrorAsync(f);
        }
    }
}