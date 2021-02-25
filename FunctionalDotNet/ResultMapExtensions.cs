using System;

namespace FunctionalDotNet
{
    public static class ResultMapExtensions
    {
        public static IResult<T2> Map<T1, T2>(this IResult<T1> source, Func<T1, T2> f) => Result.Lift(f).Apply(source);
        public static IResult Map<T1>(this IResult<T1> source, Action<T1> f) => Result.Lift(f).Apply(source);
        public static IResult<T1> Map<T1>(this IResult source, Func<T1> f)
        {
            return source.IsSuccess
                ? Result.Lift(f)()
                : Result.Failure<T1>(source.Errors);
        }
    }
}