using System.Collections.Generic;
using System.Linq;

namespace FunctionalDotNet.Result
{
    public static class ResultSequenceExtensions
    {
        // List<Result> -> Result<List>
        public static Result Sequence(this IEnumerable<Result> results)
        {
            if (results.Any(x => !x.IsSuccess))
            {
                var errors = results.SelectMany(x => x.Errors);
                return Result.Failure(errors.ToArray());
            }

            return Result.Success();
        }

        // List<Result> -> Result<List>
        public static Result<IEnumerable<T>> Sequence<T>(this IEnumerable<Result<T>> results)
        {
            if (results.Any(x => !x.IsSuccess))
            {
                var errors = results.SelectMany(x => x.Errors);
                return Result.Failure<IEnumerable<T>>(errors.ToArray());
            }

            var components = results.Select(x => x.ItemOrDefault);
            return Result.Success(components);
        }
    }
}