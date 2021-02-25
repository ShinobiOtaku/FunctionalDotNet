using System;

namespace FunctionalDotNet
{
    public static class ResultBindExtensions
    {
        public static IResult<T2> Bind<T1, T2>(this IResult<T1> source, Func<T1, IResult<T2>> f) => Result.Lift(f).Apply(source);
        public static IResult Bind<T1>(this IResult<T1> source, Func<T1, IResult> f) => Result.Lift(f).Apply(source);
    }
}