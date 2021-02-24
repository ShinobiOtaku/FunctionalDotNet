using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class AsyncResultMapErrorExtensions
    {
        // Change error message(s)
        public static async Task<Result<T1>> MapErrorAsync<T1>(this Result<T1> source, Func<string, Task<string>> f)
        {
            if (!source.IsSuccess)
            {
                var errors = await Task.WhenAll(source.Errors.Select(f));
                return Result.Failure<T1>(errors);
            }

            return Result.Success(source.ItemOrDefault);
        }

        // Change error message(s)
        public static async Task<Result<T1>> MapErrorAsync<T1>(this Task<Result<T1>> source, Func<string, Task<string>> f)
        {
            var r = await source;
            return await r.MapErrorAsync(f);
        }

        // Change error message(s)
        public static async Task<Result<T1>> MapErrorAsync<T1>(this Task<Result<T1>> source, Func<string, string> f)
        {
            var r = await source;
            return r.MapError(f);
        }

        // Change error message(s)
        public static async Task<Result> MapErrorAsync(this Result source, Func<string, Task<string>> f)
        {
            if (!source.IsSuccess)
            {
                var errors = await Task.WhenAll(source.Errors.Select(f));
                return Result.Failure(errors);
            }

            return Result.Success();
        }

        // Change error message(s)
        public static async Task<Result> MapErrorAsync(this Task<Result> source, Func<string, string> f)
        {
            var r = await source;
            return r.MapError(f);
        }

        // Change error message(s)
        public static async Task<Result> MapErrorAsync(this Task<Result> source, Func<string, Task<string>> f)
        {
            var r = await source;
            return await r.MapErrorAsync(f);
        }
    }
}