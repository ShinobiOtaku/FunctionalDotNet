using System;

namespace FunctionalDotNet
{
    public static class FuncApplyExtensions
    {
        //1
        public static IResult<T2> Apply<T1, T2>(this Func<IResult<T1>, IResult<T2>> source, IResult<T1> rt1) => source(rt1);
        
        public static IResult Apply<T1>(this Func<IResult<T1>, IResult> source, IResult<T1> rt1) => source(rt1);

        //2
        public static Func<IResult<T2>, IResult> Apply<T1, T2>(
            this Func<IResult<T1>, IResult<T2>, IResult> source, IResult<T1> rt1) =>
            rt2 => source(rt1, rt2);
        
        public static Func<IResult<T2>, IResult<T3>> Apply<T1, T2, T3>(
            this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, IResult<T1> rt1) =>
            rt2 => source(rt1, rt2);
        //3
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>> Apply<T1, T2, T3, T4>(
            this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, IResult<T1> rt1) =>
            (rt2, rt3) => source(rt1, rt2, rt3);

        public static Func<IResult<T2>, IResult<T3>, IResult> Apply<T1, T2, T3>(
            this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult> source, IResult<T1> rt1) =>
            (rt2, rt3) => source(rt1, rt2, rt3);

        //4
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> Apply<T1, T2, T3, T4, T5>(
            this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, IResult<T1> rt1) =>
            (rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4);

        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult> Apply<T1, T2, T3, T4>(
            this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult> source, IResult<T1> rt1) =>
            (rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4);

        //5
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> Apply<T1, T2, T3, T4, T5, T6>(
            this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, IResult<T1> rt1) =>
            (rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5);

        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> Apply<T1, T2, T3, T4, T5>(
            this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> source, IResult<T1> rt1) =>
            (rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5);

        //6
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> Apply<T1, T2, T3, T4, T5, T6, T7>(
            this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, IResult<T1> rt1) =>
            (rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6);

        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> Apply<T1, T2, T3, T4, T5, T6>(
            this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> source, IResult<T1> rt1) =>
            (rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6);
    }
}