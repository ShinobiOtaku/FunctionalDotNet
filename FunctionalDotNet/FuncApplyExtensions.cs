using System;

namespace FunctionalDotNet
{
    public static class FuncApplyExtensions
    {
        public static Func<IResult<T2>, IResult<T3>> Apply<T1, T2, T3>(this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, IResult<T1> rt1) =>
            rt2 => source(rt1, rt2);
    }
}