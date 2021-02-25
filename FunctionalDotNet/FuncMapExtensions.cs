using System;

namespace FunctionalDotNet
{
    public static class FuncMapExtensions
    {
        public static Func<IResult<T1>, IResult<T3>> Map<T1, T2, T3>(this Func<IResult<T1>, IResult<T2>> source, Func<T2, T3> f) =>
            rt1 => source(rt1).Map(f);

        public static Func<IResult<T1>, IResult<T2>, IResult<T4>> Map<T1, T2, T3, T4>(this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, T4> f) =>
            (rt1, rt2) => source(rt1, rt2).Map(f);
    }
}