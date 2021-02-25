using System;

namespace FunctionalDotNet
{
    public static class FuncBindExtensions
    {
        public static Func<IResult<T1>, IResult<T3>> Bind<T1, T2, T3>(this Func<IResult<T1>, IResult<T2>> source, Func<T2, IResult<T3>> f) =>
            rt1 => source(rt1).Bind(f);

        public static Func<IResult<T1>, IResult<T2>, IResult<T4>> Bind<T1, T2, T3, T4>(this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, IResult<T4>> f) =>
            (rt1, rt2) => source(rt1, rt2).Bind(f);
    }
}