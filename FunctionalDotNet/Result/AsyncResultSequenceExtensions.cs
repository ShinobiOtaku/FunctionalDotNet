using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionalDotNet.Result
{
    public static class AsyncResultSequenceExtensions
    {
        // AsyncList<Result> -> AsyncResult<List>
        public static async Task<Result> SequenceAsync(this Task<IEnumerable<Result>> results)
        {
            var result = await results;
            return result.Sequence();
        }

        // AsyncList<Result> -> AsyncResult<List>
        public static async Task<Result<IEnumerable<T>>> SequenceAsync<T>(this Task<IEnumerable<Result<T>>> results)
        {
            var result = await results;
            return result.Sequence();
        }

        // List<AsyncResult> -> AsyncResult<List>
        public static async Task<Result> SequenceAsync(this IEnumerable<Task<Result>> results)
        {
            var result = await Task.WhenAll(results);
            return result.Sequence();
        }

        // List<AsyncResult> -> AsyncResult<List>
        public static async Task<Result<IEnumerable<T>>> SequenceAsync<T>(this IEnumerable<Task<Result<T>>> results)
        {
            var result = await Task.WhenAll(results);
            return result.Sequence();
        }
    }
}