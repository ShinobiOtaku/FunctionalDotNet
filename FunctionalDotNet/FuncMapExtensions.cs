using System;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class FuncMapExtensions
    {
        // ------------------------
        // 1 parameter functions.
        // ------------------------

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult> Map<T1, T2>(
          this Func<IResult<T1>, IResult<T2>> source, Action<T2> f) =>
          (rt1) => source(rt1).Map(f);

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T3>> Map<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, T3> f) =>
          (rt1) => source(rt1).Map(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, Task> f) =>
          (rt1) => source(rt1).MapAsync(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, Task<IResult<T3>>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, Task<T3>> f) =>
          (rt1) => source(rt1).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, Task<IResult<T3>>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, Task<T3>> f) =>
          (rt1) => source(rt1).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, Task> f) =>
          (rt1) => source(rt1).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, Task<IResult<T3>>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, T3> f) =>
          (rt1) => source(rt1).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Action<T2> f) =>
          (rt1) => source(rt1).MapAsync(f);

        // ------------------------
        // 1 parameter functions. Capturing 1 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult> Map<T1, T2, TInner1>(
          this Func<IResult<T1>, IResult<T2>> source, Action<T2, TInner1> f) =>
          (rt1, rt2) => source(rt1).Bind(x => Result.Lift(f).Apply(x).Apply(rt2));

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<T3>> Map<T1, T2, T3, TInner1>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, TInner1, T3> f) =>
          (rt1, rt2) => source(rt1).Bind(x => Result.Lift(f).Apply(x).Apply(rt2));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, TInner1>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Action<T2, TInner1> f) =>
          (rt1, rt2) => source(rt1).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt2));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, Task<IResult<T3>>> MapAsync<T1, T2, T3, TInner1>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, T3> f) =>
          (rt1, rt2) => source(rt1).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt2));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, TInner1>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, Task> f) =>
          (rt1, rt2) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, Task<IResult<T3>>> MapAsync<T1, T2, T3, TInner1>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, Task<T3>> f) =>
          (rt1, rt2) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2));

        // ------------------------
        // 1 parameter functions. Capturing 2 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult> Map<T1, T2, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>> source, Action<T2, TInner1, TInner2> f) =>
          (rt1, rt2, rt3) => source(rt1).Bind(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3));

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<T3>> Map<T1, T2, T3, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, TInner1, TInner2, T3> f) =>
          (rt1, rt2, rt3) => source(rt1).Bind(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, TInner1, TInner2>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Action<T2, TInner1, TInner2> f) =>
          (rt1, rt2, rt3) => source(rt1).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T3>>> MapAsync<T1, T2, T3, TInner1, TInner2>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, T3> f) =>
          (rt1, rt2, rt3) => source(rt1).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, TInner1, TInner2>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, Task> f) =>
          (rt1, rt2, rt3) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2).ApplyAsync(rt3));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T3>>> MapAsync<T1, T2, T3, TInner1, TInner2>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, Task<T3>> f) =>
          (rt1, rt2, rt3) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2).ApplyAsync(rt3));

        // ------------------------
        // 1 parameter functions. Capturing 3 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult> Map<T1, T2, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>> source, Action<T2, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1).Bind(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4));

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<T3>> Map<T1, T2, T3, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, TInner1, TInner2, TInner3, T3> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1).Bind(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Action<T2, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T3>>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, TInner3, T3> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, TInner3, Task> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2).ApplyAsync(rt3).ApplyAsync(rt4));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T3>>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, TInner3, Task<T3>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2).ApplyAsync(rt3).ApplyAsync(rt4));

        // ------------------------
        // 1 parameter functions. Capturing 4 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult> Map<T1, T2, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>> source, Action<T2, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1).Bind(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4).Apply(rt5));

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<T3>> Map<T1, T2, T3, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, TInner1, TInner2, TInner3, TInner4, T3> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1).Bind(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4).Apply(rt5));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Action<T2, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4).Apply(rt5));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T3>>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, TInner3, TInner4, T3> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4).Apply(rt5));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, TInner3, TInner4, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2).ApplyAsync(rt3).ApplyAsync(rt4).ApplyAsync(rt5));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T3>>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, TInner3, TInner4, Task<T3>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2).ApplyAsync(rt3).ApplyAsync(rt4).ApplyAsync(rt5));

        // ------------------------
        // 1 parameter functions. Capturing 5 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult> Map<T1, T2, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>> source, Action<T2, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1).Bind(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult<T3>> Map<T1, T2, T3, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>> source, Func<T2, TInner1, TInner2, TInner3, TInner4, TInner5, T3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1).Bind(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Action<T2, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T3>>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, TInner3, TInner4, TInner5, T3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt2).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, TInner3, TInner4, TInner5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2).ApplyAsync(rt3).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T3>>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, TInner1, TInner2, TInner3, TInner4, TInner5, Task<T3>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2).ApplyAsync(rt3).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6));

        // ------------------------
        // 2 parameter functions.
        // ------------------------

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult> Map<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Action<T3> f) =>
          (rt1, rt2) => source(rt1, rt2).Map(f);

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T4>> Map<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, T4> f) =>
          (rt1, rt2) => source(rt1, rt2).Map(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, Task> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, Task<T4>> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, Task<T4>> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, Task> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, T4> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult>> MapAsync<T1, T2, T3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Action<T3> f) =>
          (rt1, rt2) => source(rt1, rt2).MapAsync(f);

        // ------------------------
        // 2 parameter functions. Capturing 1 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult> Map<T1, T2, T3, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Action<T3, TInner1> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2).Bind(x => Result.Lift(f).Apply(x).Apply(rt3));

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<T4>> Map<T1, T2, T3, T4, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, TInner1, T4> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2).Bind(x => Result.Lift(f).Apply(x).Apply(rt3));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, TInner1>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Action<T3, TInner1> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt3));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4, TInner1>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, T4> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt3));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, TInner1>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, Task> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt3));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4, TInner1>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, Task<T4>> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt3));

        // ------------------------
        // 2 parameter functions. Capturing 2 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult> Map<T1, T2, T3, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Action<T3, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2).Bind(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4));

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<T4>> Map<T1, T2, T3, T4, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, TInner1, TInner2, T4> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2).Bind(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Action<T3, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, T4> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, Task> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt3).ApplyAsync(rt4));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, Task<T4>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt3).ApplyAsync(rt4));

        // ------------------------
        // 2 parameter functions. Capturing 3 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult> Map<T1, T2, T3, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Action<T3, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2).Bind(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5));

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<T4>> Map<T1, T2, T3, T4, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, TInner1, TInner2, TInner3, T4> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2).Bind(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Action<T3, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, TInner3, T4> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, TInner3, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt3).ApplyAsync(rt4).ApplyAsync(rt5));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, TInner3, Task<T4>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt3).ApplyAsync(rt4).ApplyAsync(rt5));

        // ------------------------
        // 2 parameter functions. Capturing 4 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult> Map<T1, T2, T3, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Action<T3, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2).Bind(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<T4>> Map<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, TInner1, TInner2, TInner3, TInner4, T4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2).Bind(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Action<T3, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, TInner3, TInner4, T4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, TInner3, TInner4, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt3).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, TInner3, TInner4, Task<T4>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt3).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6));

        // ------------------------
        // 2 parameter functions. Capturing 5 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult> Map<T1, T2, T3, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Action<T3, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2).Bind(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult<T4>> Map<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, TInner1, TInner2, TInner3, TInner4, TInner5, T4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2).Bind(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Action<T3, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, TInner3, TInner4, TInner5, T4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt3).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, TInner3, TInner4, TInner5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt3).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T4>>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, TInner1, TInner2, TInner3, TInner4, TInner5, Task<T4>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt3).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7));

        // ------------------------
        // 3 parameter functions.
        // ------------------------

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult> Map<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Action<T4> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).Map(f);

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T5>> Map<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, T5> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).Map(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, Task> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, Task<T5>> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, Task<T5>> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, Task> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, T5> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> MapAsync<T1, T2, T3, T4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Action<T4> f) =>
          (rt1, rt2, rt3) => source(rt1, rt2, rt3).MapAsync(f);

        // ------------------------
        // 3 parameter functions. Capturing 1 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult> Map<T1, T2, T3, T4, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Action<T4, TInner1> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3).Bind(x => Result.Lift(f).Apply(x).Apply(rt4));

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<T5>> Map<T1, T2, T3, T4, T5, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, TInner1, T5> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3).Bind(x => Result.Lift(f).Apply(x).Apply(rt4));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Action<T4, TInner1> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt4));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, T5> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt4));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, Task> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt4));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, Task<T5>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt4));

        // ------------------------
        // 3 parameter functions. Capturing 2 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult> Map<T1, T2, T3, T4, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Action<T4, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3).Bind(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5));

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<T5>> Map<T1, T2, T3, T4, T5, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, TInner1, TInner2, T5> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3).Bind(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Action<T4, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, T5> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt4).ApplyAsync(rt5));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, Task<T5>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt4).ApplyAsync(rt5));

        // ------------------------
        // 3 parameter functions. Capturing 3 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult> Map<T1, T2, T3, T4, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Action<T4, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3).Bind(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<T5>> Map<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, TInner1, TInner2, TInner3, T5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3).Bind(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Action<T4, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, TInner3, T5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, TInner3, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, TInner3, Task<T5>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6));

        // ------------------------
        // 3 parameter functions. Capturing 4 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult> Map<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Action<T4, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3).Bind(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<T5>> Map<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, TInner1, TInner2, TInner3, TInner4, T5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3).Bind(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Action<T4, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, TInner3, TInner4, T5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, TInner3, TInner4, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, TInner3, TInner4, Task<T5>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7));

        // ------------------------
        // 3 parameter functions. Capturing 5 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult> Map<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Action<T4, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3).Bind(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult<T5>> Map<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> source, Func<T4, TInner1, TInner2, TInner3, TInner4, TInner5, T5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3).Bind(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Action<T4, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, TInner3, TInner4, TInner5, T5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt4).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, TInner3, TInner4, TInner5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T5>>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> source, Func<T4, TInner1, TInner2, TInner3, TInner4, TInner5, Task<T5>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt4).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8));

        // ------------------------
        // 4 parameter functions.
        // ------------------------

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult> Map<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Action<T5> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).Map(f);

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T6>> Map<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, T6> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).Map(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, Task> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, Task<T6>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, Task<T6>> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, Task> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, T6> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Action<T5> f) =>
          (rt1, rt2, rt3, rt4) => source(rt1, rt2, rt3, rt4).MapAsync(f);

        // ------------------------
        // 4 parameter functions. Capturing 1 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult> Map<T1, T2, T3, T4, T5, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Action<T5, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4).Bind(x => Result.Lift(f).Apply(x).Apply(rt5));

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<T6>> Map<T1, T2, T3, T4, T5, T6, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, TInner1, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4).Bind(x => Result.Lift(f).Apply(x).Apply(rt5));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Action<T5, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt5));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt5));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt5));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, Task<T6>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt5));

        // ------------------------
        // 4 parameter functions. Capturing 2 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult> Map<T1, T2, T3, T4, T5, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Action<T5, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4).Bind(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6));

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<T6>> Map<T1, T2, T3, T4, T5, T6, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, TInner1, TInner2, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4).Bind(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Action<T5, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt5).ApplyAsync(rt6));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, Task<T6>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt5).ApplyAsync(rt6));

        // ------------------------
        // 4 parameter functions. Capturing 3 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult> Map<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Action<T5, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4).Bind(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<T6>> Map<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, TInner1, TInner2, TInner3, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4).Bind(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Action<T5, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, TInner3, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, TInner3, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, TInner3, Task<T6>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7));

        // ------------------------
        // 4 parameter functions. Capturing 4 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult> Map<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Action<T5, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4).Bind(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<T6>> Map<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, TInner1, TInner2, TInner3, TInner4, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4).Bind(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Action<T5, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, TInner3, TInner4, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, TInner3, TInner4, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, TInner3, TInner4, Task<T6>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8));

        // ------------------------
        // 4 parameter functions. Capturing 5 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult> Map<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Action<T5, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4).Bind(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult<T6>> Map<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> source, Func<T5, TInner1, TInner2, TInner3, TInner4, TInner5, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4).Bind(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Action<T5, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, TInner3, TInner4, TInner5, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt5).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, TInner3, TInner4, TInner5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T6>>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> source, Func<T5, TInner1, TInner2, TInner3, TInner4, TInner5, Task<T6>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt5).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9));

        // ------------------------
        // 5 parameter functions.
        // ------------------------

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> Map<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Action<T6> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).Map(f);

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T7>> Map<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).Map(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, Task<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, Task<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Action<T6> f) =>
          (rt1, rt2, rt3, rt4, rt5) => source(rt1, rt2, rt3, rt4, rt5).MapAsync(f);

        // ------------------------
        // 5 parameter functions. Capturing 1 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult> Map<T1, T2, T3, T4, T5, T6, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Action<T6, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5).Bind(x => Result.Lift(f).Apply(x).Apply(rt6));

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<T7>> Map<T1, T2, T3, T4, T5, T6, T7, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, TInner1, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5).Bind(x => Result.Lift(f).Apply(x).Apply(rt6));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Action<T6, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt6));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt6));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt6));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, Task<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt6));

        // ------------------------
        // 5 parameter functions. Capturing 2 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult> Map<T1, T2, T3, T4, T5, T6, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Action<T6, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5).Bind(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7));

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<T7>> Map<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, TInner1, TInner2, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5).Bind(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Action<T6, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt6).ApplyAsync(rt7));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, Task<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt6).ApplyAsync(rt7));

        // ------------------------
        // 5 parameter functions. Capturing 3 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult> Map<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Action<T6, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5).Bind(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<T7>> Map<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, TInner1, TInner2, TInner3, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5).Bind(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Action<T6, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, TInner3, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, TInner3, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, TInner3, Task<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8));

        // ------------------------
        // 5 parameter functions. Capturing 4 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult> Map<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Action<T6, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5).Bind(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<T7>> Map<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, TInner1, TInner2, TInner3, TInner4, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5).Bind(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Action<T6, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, TInner3, TInner4, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, TInner3, TInner4, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, TInner3, TInner4, Task<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9));

        // ------------------------
        // 5 parameter functions. Capturing 5 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult> Map<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Action<T6, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5).Bind(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult<T7>> Map<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> source, Func<T6, TInner1, TInner2, TInner3, TInner4, TInner5, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5).Bind(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Action<T6, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, TInner3, TInner4, TInner5, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt6).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, TInner3, TInner4, TInner5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T7>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> source, Func<T6, TInner1, TInner2, TInner3, TInner4, TInner5, Task<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt6).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10));

        // ------------------------
        // 6 parameter functions.
        // ------------------------

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> Map<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Action<T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).Map(f);

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T8>> Map<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).Map(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, Task<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, Task<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Action<T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => source(rt1, rt2, rt3, rt4, rt5, rt6).MapAsync(f);

        // ------------------------
        // 6 parameter functions. Capturing 1 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Action<T7, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(x => Result.Lift(f).Apply(x).Apply(rt7));

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<T8>> Map<T1, T2, T3, T4, T5, T6, T7, T8, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, TInner1, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(x => Result.Lift(f).Apply(x).Apply(rt7));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Action<T7, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt7));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt7));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt7));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, Task<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt7));

        // ------------------------
        // 6 parameter functions. Capturing 2 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Action<T7, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8));

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<T8>> Map<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, TInner1, TInner2, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Action<T7, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt7).ApplyAsync(rt8));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, Task<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt7).ApplyAsync(rt8));

        // ------------------------
        // 6 parameter functions. Capturing 3 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Action<T7, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<T8>> Map<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, TInner1, TInner2, TInner3, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Action<T7, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, TInner3, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, TInner3, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, TInner3, Task<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9));

        // ------------------------
        // 6 parameter functions. Capturing 4 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Action<T7, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<T8>> Map<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, TInner1, TInner2, TInner3, TInner4, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Action<T7, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, TInner3, TInner4, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, TInner3, TInner4, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, TInner3, TInner4, Task<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10));

        // ------------------------
        // 6 parameter functions. Capturing 5 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Action<T7, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult<T8>> Map<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> source, Func<T7, TInner1, TInner2, TInner3, TInner4, TInner5, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6).Bind(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Action<T7, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, TInner3, TInner4, TInner5, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt7).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, TInner3, TInner4, TInner5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T8>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> source, Func<T7, TInner1, TInner2, TInner3, TInner4, TInner5, Task<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt7).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11));

        // ------------------------
        // 7 parameter functions.
        // ------------------------

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Action<T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Map(f);

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T9>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Map(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, Task<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, Task<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Action<T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).MapAsync(f);

        // ------------------------
        // 7 parameter functions. Capturing 1 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Action<T8, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(x => Result.Lift(f).Apply(x).Apply(rt8));

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<T9>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, TInner1, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(x => Result.Lift(f).Apply(x).Apply(rt8));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Action<T8, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt8));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt8));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt8));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, Task<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt8));

        // ------------------------
        // 7 parameter functions. Capturing 2 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Action<T8, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9));

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<T9>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, TInner1, TInner2, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Action<T8, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt8).ApplyAsync(rt9));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, Task<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt8).ApplyAsync(rt9));

        // ------------------------
        // 7 parameter functions. Capturing 3 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Action<T8, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<T9>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, TInner1, TInner2, TInner3, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Action<T8, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, TInner3, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, TInner3, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, TInner3, Task<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10));

        // ------------------------
        // 7 parameter functions. Capturing 4 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Action<T8, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<T9>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, TInner1, TInner2, TInner3, TInner4, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Action<T8, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, TInner3, TInner4, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, TInner3, TInner4, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, TInner3, TInner4, Task<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11));

        // ------------------------
        // 7 parameter functions. Capturing 5 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Action<T8, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult<T9>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> source, Func<T8, TInner1, TInner2, TInner3, TInner4, TInner5, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).Bind(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Action<T8, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, TInner3, TInner4, TInner5, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt8).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, TInner3, TInner4, TInner5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T9>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> source, Func<T8, TInner1, TInner2, TInner3, TInner4, TInner5, Task<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt8).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12));

        // ------------------------
        // 8 parameter functions.
        // ------------------------

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Action<T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Map(f);

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T10>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Map(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, Task<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, Task<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Action<T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).MapAsync(f);

        // ------------------------
        // 8 parameter functions. Capturing 1 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Action<T9, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(x => Result.Lift(f).Apply(x).Apply(rt9));

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<T10>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, TInner1, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(x => Result.Lift(f).Apply(x).Apply(rt9));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Action<T9, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt9));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt9));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt9));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, Task<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt9));

        // ------------------------
        // 8 parameter functions. Capturing 2 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Action<T9, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10));

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<T10>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, TInner1, TInner2, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Action<T9, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt9).ApplyAsync(rt10));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, Task<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt9).ApplyAsync(rt10));

        // ------------------------
        // 8 parameter functions. Capturing 3 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Action<T9, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<T10>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, TInner1, TInner2, TInner3, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Action<T9, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, TInner3, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, TInner3, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, TInner3, Task<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11));

        // ------------------------
        // 8 parameter functions. Capturing 4 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Action<T9, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<T10>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, TInner1, TInner2, TInner3, TInner4, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Action<T9, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, TInner3, TInner4, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, TInner3, TInner4, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, TInner3, TInner4, Task<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12));

        // ------------------------
        // 8 parameter functions. Capturing 5 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Action<T9, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult<T10>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> source, Func<T9, TInner1, TInner2, TInner3, TInner4, TInner5, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).Bind(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Action<T9, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, TInner3, TInner4, TInner5, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt9).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, TInner3, TInner4, TInner5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T10>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> source, Func<T9, TInner1, TInner2, TInner3, TInner4, TInner5, Task<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt9).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13));

        // ------------------------
        // 9 parameter functions.
        // ------------------------

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Action<T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Map(f);

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T11>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Map(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, Task<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, Task<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Action<T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).MapAsync(f);

        // ------------------------
        // 9 parameter functions. Capturing 1 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Action<T10, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(x => Result.Lift(f).Apply(x).Apply(rt10));

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<T11>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, TInner1, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(x => Result.Lift(f).Apply(x).Apply(rt10));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Action<T10, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt10));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt10));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt10));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, Task<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt10));

        // ------------------------
        // 9 parameter functions. Capturing 2 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Action<T10, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11));

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<T11>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, TInner1, TInner2, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Action<T10, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt10).ApplyAsync(rt11));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, Task<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt10).ApplyAsync(rt11));

        // ------------------------
        // 9 parameter functions. Capturing 3 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Action<T10, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<T11>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, TInner1, TInner2, TInner3, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Action<T10, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, TInner3, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, TInner3, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, TInner3, Task<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12));

        // ------------------------
        // 9 parameter functions. Capturing 4 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Action<T10, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<T11>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, TInner1, TInner2, TInner3, TInner4, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Action<T10, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, TInner3, TInner4, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, TInner3, TInner4, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, TInner3, TInner4, Task<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13));

        // ------------------------
        // 9 parameter functions. Capturing 5 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Action<T10, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14));

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult<T11>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> source, Func<T10, TInner1, TInner2, TInner3, TInner4, TInner5, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).Bind(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Action<T10, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, TInner3, TInner4, TInner5, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt10).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, TInner3, TInner4, TInner5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13).ApplyAsync(rt14));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T11>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> source, Func<T10, TInner1, TInner2, TInner3, TInner4, TInner5, Task<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt10).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13).ApplyAsync(rt14));

        // ------------------------
        // 10 parameter functions.
        // ------------------------

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Action<T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Map(f);

        /// Chains the previous function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T12>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Map(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        /// Chains the previous function to an async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, Task<T12>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, Task<T12>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        /// Chains the previous async function to another async function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        /// Chains the previous async function to another function.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Action<T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).MapAsync(f);

        // ------------------------
        // 10 parameter functions. Capturing 1 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Action<T11, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(x => Result.Lift(f).Apply(x).Apply(rt11));

        /// Chains the previous function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<T12>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, TInner1, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(x => Result.Lift(f).Apply(x).Apply(rt11));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Action<T11, TInner1> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt11));

        /// Chains the previous async function to another function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt11));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt11));

        /// Chains the previous async function to another async function with 1 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, Task<T12>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt11));

        // ------------------------
        // 10 parameter functions. Capturing 2 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Action<T11, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12));

        /// Chains the previous function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<T12>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, TInner1, TInner2, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Action<T11, TInner1, TInner2> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt11).ApplyAsync(rt12));

        /// Chains the previous async function to another async function with 2 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, Task<T12>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt11).ApplyAsync(rt12));

        // ------------------------
        // 10 parameter functions. Capturing 3 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Action<T11, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<T12>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, TInner1, TInner2, TInner3, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Action<T11, TInner1, TInner2, TInner3> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous async function to another function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, TInner3, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, TInner3, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13));

        /// Chains the previous async function to another async function with 3 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2, TInner3>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, TInner3, Task<T12>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13));

        // ------------------------
        // 10 parameter functions. Capturing 4 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Action<T11, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14));

        /// Chains the previous function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<T12>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, TInner1, TInner2, TInner3, TInner4, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Action<T11, TInner1, TInner2, TInner3, TInner4> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14));

        /// Chains the previous async function to another function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, TInner3, TInner4, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, TInner3, TInner4, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13).ApplyAsync(rt14));

        /// Chains the previous async function to another async function with 4 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2, TInner3, TInner4>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, TInner3, TInner4, Task<T12>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13).ApplyAsync(rt14));

        // ------------------------
        // 10 parameter functions. Capturing 5 additional parameters.
        // ------------------------

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Action<T11, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14, rt15) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14).Apply(rt15));

        /// Chains the previous function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, IResult<T12>> Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> source, Func<T11, TInner1, TInner2, TInner3, TInner4, TInner5, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14, rt15) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).Bind(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14).Apply(rt15));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Action<T11, TInner1, TInner2, TInner3, TInner4, TInner5> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14, rt15) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14).Apply(rt15));

        /// Chains the previous async function to another function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, TInner3, TInner4, TInner5, T12> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14, rt15) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.Lift(f).Apply(x).Apply(rt11).Apply(rt12).Apply(rt13).Apply(rt14).Apply(rt15));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, TInner3, TInner4, TInner5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14, rt15) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13).ApplyAsync(rt14).ApplyAsync(rt15));

        /// Chains the previous async function to another async function with 5 additional parameters.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<TInner1>, IResult<TInner2>, IResult<TInner3>, IResult<TInner4>, IResult<TInner5>, Task<IResult<T12>>> MapAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInner1, TInner2, TInner3, TInner4, TInner5>(
          this Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> source, Func<T11, TInner1, TInner2, TInner3, TInner4, TInner5, Task<T12>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10, rt11, rt12, rt13, rt14, rt15) => source(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt11).ApplyAsync(rt12).ApplyAsync(rt13).ApplyAsync(rt14).ApplyAsync(rt15));


    }
}