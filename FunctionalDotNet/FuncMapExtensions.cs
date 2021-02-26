using System;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class FuncMapExtensions
    {
        //TODO pull in more params
        //public static Func<IResult<T1>, IResult<T3>, Task<IResult>> MapAsync<T1, T2, T3>(
        //    this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, T3, Task> f) =>
        //    (rt1, rt2) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2));


        // ------------------------
        // 1 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult> Map<T1, T2>(
          this Func<IResult<T1>, IResult<T2>> source, Action<T2> f) =>
          (rt1) => source(rt1).Map(f);

        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T3>> Map<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, T3> f) =>
          (rt1) => source(rt1).Map(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, Task> f) =>
          (rt1) => source(rt1).MapAsync(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, Task<IResult<T3>>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, Task<T3>> f) =>
          (rt1) => source(rt1).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, Task<IResult<T3>>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, Task<T3>> f) =>
          (rt1) => source(rt1).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, Task> f) =>
          (rt1) => source(rt1).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, Task<IResult<T3>>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, T3> f) =>
          (rt1) => source(rt1).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Action<T2> f) =>
          (rt1) => source(rt1).MapAsync(f);

        // ------------------------
        // 2 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult> Map<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Action<T3> f) =>
          (rt1, rt2) => source(rt1, rt2).Map(f);

        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T4>> Map<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, T4> f) =>
          (rt1, rt2) => source(rt1, rt2).Map(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, Task> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, Task<T4>> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, Task<T4>> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, Task> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, T4> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Action<T3> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        // ------------------------
        // 3 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult> Map<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Action<T4> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).Map(f);

        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T5>> Map<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, T5> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).Map(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, Task> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, Task<T5>> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, Task<T5>> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, Task> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, T5> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Action<T4> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        // ------------------------
        // 4 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult> Map<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Action<T5> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).Map(f);

        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T6>> Map<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, T6> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).Map(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, Task> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, Task<T6>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, Task<T6>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, Task> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, T6> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Action<T5> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        // ------------------------
        // 5 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> Map<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Action<T6> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).Map(f);

        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T7>> Map<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).Map(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, Task<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, Task<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Action<T6> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        // ------------------------
        // 6 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> Map<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Action<T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).Map(f);

        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T8>> Map<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).Map(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, Task<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, Task<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Action<T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        // ------------------------
        // 7 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Action<T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Map(f);

        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T9>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Map(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, Task<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, Task<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Action<T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        // ------------------------
        // 8 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Action<T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Map(f);

        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T10>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Map(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, Task<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, Task<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Action<T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        // ------------------------
        // 9 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Action<T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Map(f);

        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T11>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Map(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, Task<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, Task<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Action<T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        // ------------------------
        // 10 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Action<T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Map(f);

        /// Chains the previous function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T12>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Map(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        /// Chains the previous function to an async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, Task<T12>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, Task<T12>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        /// Chains the previous async function to another async function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        /// Chains the previous async function to another function using Map.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Action<T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);


    }
}