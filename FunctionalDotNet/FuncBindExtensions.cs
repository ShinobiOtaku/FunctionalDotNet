using System;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class FuncBindExtensions
    {
        //TODO pull in more params
        public static Func<IResult<T1>, IResult<T3>, Task<IResult>> BindAsync<T1, T2, T3>(
            this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, T3, Task<IResult>> f) =>
            (rt1, rt2) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2));

        // ------------------------
        // 1 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult> Bind<T1, T2>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, IResult> f) =>
          (rt1) => source(rt1).Bind(f);

        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T3>> Bind<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, IResult<T3>> f) =>
          (rt1) => source(rt1).Bind(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, Task<IResult>> BindAsync<T1, T2>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, Task<IResult>> f) =>
          (rt1) => source(rt1).BindAsync(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, Task<IResult<T3>>> BindAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, Task<IResult<T3>>> f) =>
          (rt1) => source(rt1).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, Task<IResult<T3>>> BindAsync<T1, T2, T3>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, Task<IResult<T3>>> f) =>
          (rt1) => source(rt1).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, Task<IResult>> BindAsync<T1, T2>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, Task<IResult>> f) =>
          (rt1) => source(rt1).BindAsync(f);

        // ------------------------
        // 2 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult> Bind<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, IResult> f) =>
          (rt1, rt2) => source(rt1, rt2).Bind(f);

        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T4>> Bind<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, IResult<T4>> f) =>
          (rt1, rt2) => source(rt1, rt2).Bind(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult>> BindAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, Task<IResult>> f) =>
          (rt1, rt2) => source(rt1, rt2).BindAsync(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T4>>> BindAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, Task<IResult<T4>>> f) =>
          (rt1, rt2) => source(rt1, rt2).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T4>>> BindAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, Task<IResult<T4>>> f) =>
          (rt1, rt2) => source(rt1, rt2).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult>> BindAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, Task<IResult>> f) =>
          (rt1, rt2) => source(rt1, rt2).BindAsync(f);

        // ------------------------
        // 3 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult> Bind<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, IResult> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).Bind(f);

        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T5>> Bind<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, IResult<T5>> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).Bind(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> BindAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, Task<IResult>> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).BindAsync(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T5>>> BindAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, Task<IResult<T5>>> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T5>>> BindAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, Task<IResult<T5>>> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> BindAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, Task<IResult>> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).BindAsync(f);

        // ------------------------
        // 4 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult> Bind<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, IResult> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).Bind(f);

        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T6>> Bind<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, IResult<T6>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).Bind(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).BindAsync(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T6>>> BindAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, Task<IResult<T6>>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T6>>> BindAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, Task<IResult<T6>>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).BindAsync(f);

        // ------------------------
        // 5 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> Bind<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).Bind(f);

        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T7>> Bind<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, IResult<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).Bind(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T7>>> BindAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, Task<IResult<T7>>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T7>>> BindAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, Task<IResult<T7>>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(f);

        // ------------------------
        // 6 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> Bind<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(f);

        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T8>> Bind<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, IResult<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T8>>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, Task<IResult<T8>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T8>>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, Task<IResult<T8>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(f);

        // ------------------------
        // 7 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult> Bind<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(f);

        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T9>> Bind<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, IResult<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T9>>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, Task<IResult<T9>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T9>>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, Task<IResult<T9>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(f);

        // ------------------------
        // 8 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult> Bind<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(f);

        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T10>> Bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, IResult<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T10>>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, Task<IResult<T10>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T10>>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, Task<IResult<T10>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(f);

        // ------------------------
        // 9 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult> Bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(f);

        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T11>> Bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, IResult<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T11>>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, Task<IResult<T11>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T11>>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, Task<IResult<T11>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(f);

        // ------------------------
        // 10 parameter functions.
        // ------------------------
        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult> Bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(f);

        /// Chains the previous function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T12>> Bind<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, IResult<T12>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(f);

        /// Chains the previous function to an async function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T12>>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, Task<IResult<T12>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T12>>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, Task<IResult<T12>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(f);

        /// Chains the previous async function to another function using Bind.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> BindAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(f);
    }
}