using System;
using System.Threading.Tasks;
using static FunctionalDotNet.Result;

namespace FunctionalDotNet
{
    //TODO: apply multiple at once?
    //TODO: async T1 input

    public static class FuncApplyExtensions
    {
        // ------------------------
        // single parameter functions.
        // ------------------------
        /// Apply a value to a single parameter function.
        public static IResult Apply<T1>(this Func<IResult<T1>, IResult> source, IResult<T1> rt1) => source(rt1);
        
        /// Apply a value to a single parameter function.
        public static IResult<T2> Apply<T1, T2>(this Func<IResult<T1>, IResult<T2>> source, IResult<T1> rt1) => source(rt1);

        /// Apply a value to a single parameter function.
        public static IResult<T2> Apply<T1, T2>(this Func<IResult<T1>, IResult<T2>> source, T1 t1) => source(Success(t1));

        /// Apply a value to a single parameter function.
        public static IResult Apply<T1>(this Func<IResult<T1>, IResult> source, T1 t1) => source(Success(t1));

        /// Apply a value to a single parameter async function.
        public static Task<IResult> ApplyAsync<T1>(this Func<IResult<T1>, Task<IResult>> source, T1 rt1) => source(Success(rt1));

        /// Apply a value to a single parameter async function.
        public static Task<IResult> ApplyAsync<T1>(this Func<IResult<T1>, Task<IResult>> source, IResult<T1> rt1) => source(rt1);

        /// Apply a value to a single parameter async function.
        public static Task<IResult<T2>> ApplyAsync<T1, T2>(this Func<IResult<T1>, Task<IResult<T2>>> source, T1 rt1) => source(Success(rt1));

        /// Apply a value to a single parameter async function.
        public static Task<IResult<T2>> ApplyAsync<T1, T2>(this Func<IResult<T1>, Task<IResult<T2>>> source, IResult<T1> rt1) => source(rt1);

        // ------------------------
        // 2 parameter functions.
        // ------------------------
        /// Apply the first value to a 2 parameter function.
        public static Func<IResult<T2>, IResult> Apply<T1, T2>(
          this Func<IResult<T1>, IResult<T2>, IResult> source, T1 rt1) =>
          (rt2) => source(Success(rt1), rt2);

        /// Apply the first value to a 2 parameter function.
        public static Func<IResult<T2>, IResult<T3>> Apply<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, T1 rt1) =>
          (rt2) => source(Success(rt1), rt2);

        /// Apply the first value to a 2 parameter function.
        public static Func<IResult<T2>, IResult> Apply<T1, T2>(
          this Func<IResult<T1>, IResult<T2>, IResult> source, IResult<T1> rt1) =>
          (rt2) => source(rt1, rt2);

        /// Apply the first value to a 2 parameter function.
        public static Func<IResult<T2>, IResult<T3>> Apply<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, IResult<T1> rt1) =>
          (rt2) => source(rt1, rt2);

        /// Apply the first value to a 2 parameter async function.
        public static Func<IResult<T2>, Task<IResult>> ApplyAsync<T1, T2>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult>> source, T1 rt1) =>
          (rt2) => source(Success(rt1), rt2);

        /// Apply the first value to a 2 parameter function.
        public static Func<IResult<T2>, Task<IResult<T3>>> ApplyAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, T1 rt1) =>
          (rt2) => source(Success(rt1), rt2);

        /// Apply the first value to a 2 parameter async function.
        public static Func<IResult<T2>, Task<IResult>> ApplyAsync<T1, T2>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult>> source, IResult<T1> rt1) =>
          (rt2) => source(rt1, rt2);

        /// Apply the first value to a 2 parameter function.
        public static Func<IResult<T2>, Task<IResult<T3>>> ApplyAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, IResult<T1> rt1) =>
          (rt2) => source(rt1, rt2);

        // ------------------------
        // 3 parameter functions.
        // ------------------------
        /// Apply the first value to a 3 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult> Apply<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult> source, T1 rt1) =>
          (rt2, rt3) => source(Success(rt1), rt2, rt3);

        /// Apply the first value to a 3 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>> Apply<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, T1 rt1) =>
          (rt2, rt3) => source(Success(rt1), rt2, rt3);

        /// Apply the first value to a 3 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult> Apply<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult> source, IResult<T1> rt1) =>
          (rt2, rt3) => source(rt1, rt2, rt3);

        /// Apply the first value to a 3 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>> Apply<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, IResult<T1> rt1) =>
          (rt2, rt3) => source(rt1, rt2, rt3);

        /// Apply the first value to a 3 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, Task<IResult>> ApplyAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> source, T1 rt1) =>
          (rt2, rt3) => source(Success(rt1), rt2, rt3);

        /// Apply the first value to a 3 parameter function.
        public static Func<IResult<T2>, IResult<T3>, Task<IResult<T4>>> ApplyAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, T1 rt1) =>
          (rt2, rt3) => source(Success(rt1), rt2, rt3);

        /// Apply the first value to a 3 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, Task<IResult>> ApplyAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> source, IResult<T1> rt1) =>
          (rt2, rt3) => source(rt1, rt2, rt3);

        /// Apply the first value to a 3 parameter function.
        public static Func<IResult<T2>, IResult<T3>, Task<IResult<T4>>> ApplyAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, IResult<T1> rt1) =>
          (rt2, rt3) => source(rt1, rt2, rt3);

        // ------------------------
        // 4 parameter functions.
        // ------------------------
        /// Apply the first value to a 4 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult> Apply<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult> source, T1 rt1) =>
          (rt2, rt3, rt4) => source(Success(rt1), rt2, rt3, rt4);

        /// Apply the first value to a 4 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> Apply<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, T1 rt1) =>
          (rt2, rt3, rt4) => source(Success(rt1), rt2, rt3, rt4);

        /// Apply the first value to a 4 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult> Apply<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4);

        /// Apply the first value to a 4 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> Apply<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4);

        /// Apply the first value to a 4 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> ApplyAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> source, T1 rt1) =>
          (rt2, rt3, rt4) => source(Success(rt1), rt2, rt3, rt4);

        /// Apply the first value to a 4 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> ApplyAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, T1 rt1) =>
          (rt2, rt3, rt4) => source(Success(rt1), rt2, rt3, rt4);

        /// Apply the first value to a 4 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> ApplyAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4);

        /// Apply the first value to a 4 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> ApplyAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4);

        // ------------------------
        // 5 parameter functions.
        // ------------------------
        /// Apply the first value to a 5 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> Apply<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5) => source(Success(rt1), rt2, rt3, rt4, rt5);

        /// Apply the first value to a 5 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> Apply<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5) => source(Success(rt1), rt2, rt3, rt4, rt5);

        /// Apply the first value to a 5 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> Apply<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5);

        /// Apply the first value to a 5 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> Apply<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5);

        /// Apply the first value to a 5 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5) => source(Success(rt1), rt2, rt3, rt4, rt5);

        /// Apply the first value to a 5 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> ApplyAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5) => source(Success(rt1), rt2, rt3, rt4, rt5);

        /// Apply the first value to a 5 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5);

        /// Apply the first value to a 5 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> ApplyAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5);

        // ------------------------
        // 6 parameter functions.
        // ------------------------
        /// Apply the first value to a 6 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> Apply<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6);

        /// Apply the first value to a 6 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> Apply<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6);

        /// Apply the first value to a 6 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> Apply<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6);

        /// Apply the first value to a 6 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> Apply<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6);

        /// Apply the first value to a 6 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6);

        /// Apply the first value to a 6 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6);

        /// Apply the first value to a 6 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6);

        /// Apply the first value to a 6 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6);

        // ------------------------
        // 7 parameter functions.
        // ------------------------
        /// Apply the first value to a 7 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult> Apply<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7);

        /// Apply the first value to a 7 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> Apply<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7);

        /// Apply the first value to a 7 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult> Apply<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7);

        /// Apply the first value to a 7 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> Apply<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7);

        /// Apply the first value to a 7 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7);

        /// Apply the first value to a 7 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7);

        /// Apply the first value to a 7 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7);

        /// Apply the first value to a 7 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7);

        // ------------------------
        // 8 parameter functions.
        // ------------------------
        /// Apply the first value to a 8 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8);

        /// Apply the first value to a 8 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8);

        /// Apply the first value to a 8 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8);

        /// Apply the first value to a 8 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8);

        /// Apply the first value to a 8 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8);

        /// Apply the first value to a 8 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8);

        /// Apply the first value to a 8 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8);

        /// Apply the first value to a 8 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8);

        // ------------------------
        // 9 parameter functions.
        // ------------------------
        /// Apply the first value to a 9 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9);

        /// Apply the first value to a 9 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9);

        /// Apply the first value to a 9 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9);

        /// Apply the first value to a 9 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9);

        /// Apply the first value to a 9 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9);

        /// Apply the first value to a 9 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9);

        /// Apply the first value to a 9 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9);

        /// Apply the first value to a 9 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9);

        // ------------------------
        // 10 parameter functions.
        // ------------------------
        /// Apply the first value to a 10 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10);

        /// Apply the first value to a 10 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10);

        /// Apply the first value to a 10 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10);

        /// Apply the first value to a 10 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10);

        /// Apply the first value to a 10 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10);

        /// Apply the first value to a 10 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, T1 rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(Success(rt1), rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10);

        /// Apply the first value to a 10 parameter async function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10);

        /// Apply the first value to a 10 parameter function.
        public static Func<IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> ApplyAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, IResult<T1> rt1) =>
          (rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10);


    }
}