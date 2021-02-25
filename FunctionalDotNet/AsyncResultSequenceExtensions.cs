using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class AsyncResultSequenceExtensions
    {
        // AsyncList<IResult> -> AsyncResult<List>
        public static async Task<IResult> SequenceAsync(this Task<IEnumerable<IResult>> results)
        {
            var result = await results;
            return result.Sequence();
        }

        // AsyncList<IResult> -> AsyncResult<List>
        public static async Task<IResult<IEnumerable<T>>> SequenceAsync<T>(this Task<IEnumerable<IResult<T>>> results)
        {
            var result = await results;
            return result.Sequence();
        }

        // List<AsyncResult> -> AsyncResult<List>
        public static async Task<IResult> SequenceAsync(this IEnumerable<Task<IResult>> results)
        {
            var result = await Task.WhenAll(results);
            return result.Sequence();
        }

        // List<AsyncResult> -> AsyncResult<List>
        public static async Task<IResult<IEnumerable<T>>> SequenceAsync<T>(this IEnumerable<Task<IResult<T>>> results)
        {
            var result = await Task.WhenAll(results);
            return result.Sequence();
        }
    }
}