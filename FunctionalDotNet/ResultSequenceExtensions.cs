using System.Collections.Generic;
using System.Linq;

namespace FunctionalDotNet
{
    public static class ResultSequenceExtensions
    {
        // List<Result> -> Result<List>
        public static IResult Sequence(this IEnumerable<IResult> results)
        {
            if (results.Any(x => !x.IsSuccess))
            {
                var errors = results.SelectMany(x => x.Errors);
                return Result.Failure(errors);
            }

            return Result.Success();
        }
        
        // List<Result> -> Result<List>
        public static IResult<IEnumerable<T>> Sequence<T>(this IEnumerable<IResult<T>> results)
        {
            if (results.Any(x => !x.IsSuccess))
            {
                var errors = results.SelectMany(x => x.Errors);
                return Result.Failure<IEnumerable<T>>(errors);
            }

            var components = results.Select(x => x.ItemOrDefault);
            return Result.Success(components);
        }
    }
}