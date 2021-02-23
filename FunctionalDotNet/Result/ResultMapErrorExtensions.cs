using System;
using System.Linq;

namespace FunctionalDotNet.Result
{
    public static class ResultMapErrorExtensions
    {
        // Change error message(s)
        public static Result MapError(this Result source, Func<string, string> f)
        {
            if (!source.IsSuccess)
            {
                return Result.Failure(source.Errors.Select(f).ToArray());
            }

            return Result.Success();
        }

        // Change error message(s)
        public static Result<T> MapError<T>(this Result<T> source, Func<string, string> f)
        {
            if (!source.IsSuccess)
            {
                return Result.Failure<T>(source.Errors.Select(f).ToArray());
            }

            return Result.Success(source.ItemOrDefault);
        }
    }
}