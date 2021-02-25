using System;
using System.Linq;

namespace FunctionalDotNet
{
    public static class ResultMapErrorExtensions
    {
        // Change error message(s)
        public static IResult MapError(this IResult source, Func<string, string> f)
        {
            if (!source.IsSuccess)
            {
                return Result.Failure(source.Errors.Select(f).ToArray());
            }

            return Result.Success();
        }

        // Change error message(s)
        public static IResult<T> MapError<T>(this IResult<T> source, Func<string, string> f)
        {
            if (!source.IsSuccess)
            {
                return Result.Failure<T>(source.Errors.Select(f).ToArray());
            }

            return Result.Success(source.ItemOrDefault);
        }
    }
}