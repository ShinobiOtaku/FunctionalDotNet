using System;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public readonly partial struct Result
    {
        //----------------
        //   Binders
        //----------------
        private static IResult<T2> Binder<T1, T2>(IResult<T1> rt1, Func<T1, IResult<T2>> func) =>
            rt1.IsSuccess ? func(rt1.ItemOrDefault) : Failure<T2>(rt1.Errors);
        private static async Task<IResult<T2>> BinderAsync<T1, T2>(IResult<T1> rt1, Func<T1, Task<IResult<T2>>> func) =>
            rt1.IsSuccess ? await func(rt1.ItemOrDefault) : Failure<T2>(rt1.Errors);
        private static IResult Binder<T1>(IResult<T1> rt1, Func<T1, IResult> func) =>
            rt1.IsSuccess ? func(rt1.ItemOrDefault) : Failure(rt1.Errors);
        private static async Task<IResult> BinderAsync<T1>(IResult<T1> rt1, Func<T1, Task<IResult>> func) =>
            rt1.IsSuccess ? await func(rt1.ItemOrDefault) : Failure(rt1.Errors);

        ///--------------------------------------------------

        // ------------------------
        // Mergers.
        // ------------------------
        private static IResult<T1> Merge<T1>(
          IResult<T1> b) =>
          Sequence(b).Map(() => (b.ItemOrDefault));

        private static IResult<(T1, T2)> Merge<T1, T2>(
          IResult<T1> b, IResult<T2> c) =>
          Sequence(b, c).Map(() => (b.ItemOrDefault, c.ItemOrDefault));

        private static IResult<(T1, T2, T3)> Merge<T1, T2, T3>(
          IResult<T1> b, IResult<T2> c, IResult<T3> d) =>
          Sequence(b, c, d).Map(() => (b.ItemOrDefault, c.ItemOrDefault, d.ItemOrDefault));

        private static IResult<(T1, T2, T3, T4)> Merge<T1, T2, T3, T4>(
          IResult<T1> b, IResult<T2> c, IResult<T3> d, IResult<T4> e) =>
          Sequence(b, c, d, e).Map(() => (b.ItemOrDefault, c.ItemOrDefault, d.ItemOrDefault, e.ItemOrDefault));

        private static IResult<(T1, T2, T3, T4, T5)> Merge<T1, T2, T3, T4, T5>(
          IResult<T1> b, IResult<T2> c, IResult<T3> d, IResult<T4> e, IResult<T5> f) =>
          Sequence(b, c, d, e, f).Map(() => (b.ItemOrDefault, c.ItemOrDefault, d.ItemOrDefault, e.ItemOrDefault, f.ItemOrDefault));

        private static IResult<(T1, T2, T3, T4, T5, T6)> Merge<T1, T2, T3, T4, T5, T6>(
          IResult<T1> b, IResult<T2> c, IResult<T3> d, IResult<T4> e, IResult<T5> f, IResult<T6> g) =>
          Sequence(b, c, d, e, f, g).Map(() => (b.ItemOrDefault, c.ItemOrDefault, d.ItemOrDefault, e.ItemOrDefault, f.ItemOrDefault, g.ItemOrDefault));

        private static IResult<(T1, T2, T3, T4, T5, T6, T7)> Merge<T1, T2, T3, T4, T5, T6, T7>(
          IResult<T1> b, IResult<T2> c, IResult<T3> d, IResult<T4> e, IResult<T5> f, IResult<T6> g, IResult<T7> h) =>
          Sequence(b, c, d, e, f, g, h).Map(() => (b.ItemOrDefault, c.ItemOrDefault, d.ItemOrDefault, e.ItemOrDefault, f.ItemOrDefault, g.ItemOrDefault, h.ItemOrDefault));

        private static IResult<(T1, T2, T3, T4, T5, T6, T7, T8)> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(
          IResult<T1> b, IResult<T2> c, IResult<T3> d, IResult<T4> e, IResult<T5> f, IResult<T6> g, IResult<T7> h, IResult<T8> i) =>
          Sequence(b, c, d, e, f, g, h, i).Map(() => (b.ItemOrDefault, c.ItemOrDefault, d.ItemOrDefault, e.ItemOrDefault, f.ItemOrDefault, g.ItemOrDefault, h.ItemOrDefault, i.ItemOrDefault));

        private static IResult<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          IResult<T1> b, IResult<T2> c, IResult<T3> d, IResult<T4> e, IResult<T5> f, IResult<T6> g, IResult<T7> h, IResult<T8> i, IResult<T9> j) =>
          Sequence(b, c, d, e, f, g, h, i, j).Map(() => (b.ItemOrDefault, c.ItemOrDefault, d.ItemOrDefault, e.ItemOrDefault, f.ItemOrDefault, g.ItemOrDefault, h.ItemOrDefault, i.ItemOrDefault, j.ItemOrDefault));

        private static IResult<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          IResult<T1> b, IResult<T2> c, IResult<T3> d, IResult<T4> e, IResult<T5> f, IResult<T6> g, IResult<T7> h, IResult<T8> i, IResult<T9> j, IResult<T10> k) =>
          Sequence(b, c, d, e, f, g, h, i, j, k).Map(() => (b.ItemOrDefault, c.ItemOrDefault, d.ItemOrDefault, e.ItemOrDefault, f.ItemOrDefault, g.ItemOrDefault, h.ItemOrDefault, i.ItemOrDefault, j.ItemOrDefault, k.ItemOrDefault));

        // ------------------------
        // Lift Bind
        // ------------------------

        // ------------------------
        // 1 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult> Lift<T1>(
          Func<T1, IResult> f) =>
          (rt1) => Binder(Merge(rt1), x => f(x));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>> Lift<T1, T2>(
          Func<T1, IResult<T2>> f) =>
          (rt1) => Binder(Merge(rt1), x => f(x));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, Task<IResult>> LiftAsync<T1>(
          Func<T1, Task<IResult>> f) =>
          (rt1) => BinderAsync(Merge(rt1), x => f(x));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, Task<IResult<T2>>> LiftAsync<T1, T2>(
          Func<T1, Task<IResult<T2>>> f) =>
          (rt1) => BinderAsync(Merge(rt1), x => f(x));

        // ------------------------
        // 2 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult> Lift<T1, T2>(
          Func<T1, T2, IResult> f) =>
          (rt1, rt2) => Binder(Merge(rt1, rt2), x => f(x.Item1, x.Item2));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>> Lift<T1, T2, T3>(
          Func<T1, T2, IResult<T3>> f) =>
          (rt1, rt2) => Binder(Merge(rt1, rt2), x => f(x.Item1, x.Item2));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult>> LiftAsync<T1, T2>(
          Func<T1, T2, Task<IResult>> f) =>
          (rt1, rt2) => BinderAsync(Merge(rt1, rt2), x => f(x.Item1, x.Item2));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> LiftAsync<T1, T2, T3>(
          Func<T1, T2, Task<IResult<T3>>> f) =>
          (rt1, rt2) => BinderAsync(Merge(rt1, rt2), x => f(x.Item1, x.Item2));

        // ------------------------
        // 3 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult> Lift<T1, T2, T3>(
          Func<T1, T2, T3, IResult> f) =>
          (rt1, rt2, rt3) => Binder(Merge(rt1, rt2, rt3), x => f(x.Item1, x.Item2, x.Item3));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> Lift<T1, T2, T3, T4>(
          Func<T1, T2, T3, IResult<T4>> f) =>
          (rt1, rt2, rt3) => Binder(Merge(rt1, rt2, rt3), x => f(x.Item1, x.Item2, x.Item3));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> LiftAsync<T1, T2, T3>(
          Func<T1, T2, T3, Task<IResult>> f) =>
          (rt1, rt2, rt3) => BinderAsync(Merge(rt1, rt2, rt3), x => f(x.Item1, x.Item2, x.Item3));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> LiftAsync<T1, T2, T3, T4>(
          Func<T1, T2, T3, Task<IResult<T4>>> f) =>
          (rt1, rt2, rt3) => BinderAsync(Merge(rt1, rt2, rt3), x => f(x.Item1, x.Item2, x.Item3));

        // ------------------------
        // 4 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult> Lift<T1, T2, T3, T4>(
          Func<T1, T2, T3, T4, IResult> f) =>
          (rt1, rt2, rt3, rt4) => Binder(Merge(rt1, rt2, rt3, rt4), x => f(x.Item1, x.Item2, x.Item3, x.Item4));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> Lift<T1, T2, T3, T4, T5>(
          Func<T1, T2, T3, T4, IResult<T5>> f) =>
          (rt1, rt2, rt3, rt4) => Binder(Merge(rt1, rt2, rt3, rt4), x => f(x.Item1, x.Item2, x.Item3, x.Item4));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> LiftAsync<T1, T2, T3, T4>(
          Func<T1, T2, T3, T4, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4) => BinderAsync(Merge(rt1, rt2, rt3, rt4), x => f(x.Item1, x.Item2, x.Item3, x.Item4));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> LiftAsync<T1, T2, T3, T4, T5>(
          Func<T1, T2, T3, T4, Task<IResult<T5>>> f) =>
          (rt1, rt2, rt3, rt4) => BinderAsync(Merge(rt1, rt2, rt3, rt4), x => f(x.Item1, x.Item2, x.Item3, x.Item4));

        // ------------------------
        // 5 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> Lift<T1, T2, T3, T4, T5>(
          Func<T1, T2, T3, T4, T5, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5) => Binder(Merge(rt1, rt2, rt3, rt4, rt5), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> Lift<T1, T2, T3, T4, T5, T6>(
          Func<T1, T2, T3, T4, T5, IResult<T6>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => Binder(Merge(rt1, rt2, rt3, rt4, rt5), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5>(
          Func<T1, T2, T3, T4, T5, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> LiftAsync<T1, T2, T3, T4, T5, T6>(
          Func<T1, T2, T3, T4, T5, Task<IResult<T6>>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5));

        // ------------------------
        // 6 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> Lift<T1, T2, T3, T4, T5, T6>(
          Func<T1, T2, T3, T4, T5, T6, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> Lift<T1, T2, T3, T4, T5, T6, T7>(
          Func<T1, T2, T3, T4, T5, T6, IResult<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5, T6>(
          Func<T1, T2, T3, T4, T5, T6, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> LiftAsync<T1, T2, T3, T4, T5, T6, T7>(
          Func<T1, T2, T3, T4, T5, T6, Task<IResult<T7>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6));

        // ------------------------
        // 7 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult> Lift<T1, T2, T3, T4, T5, T6, T7>(
          Func<T1, T2, T3, T4, T5, T6, T7, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> Lift<T1, T2, T3, T4, T5, T6, T7, T8>(
          Func<T1, T2, T3, T4, T5, T6, T7, IResult<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5, T6, T7>(
          Func<T1, T2, T3, T4, T5, T6, T7, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          Func<T1, T2, T3, T4, T5, T6, T7, Task<IResult<T8>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7));

        // ------------------------
        // 8 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult> Lift<T1, T2, T3, T4, T5, T6, T7, T8>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> Lift<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, IResult<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<IResult<T9>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8));

        // ------------------------
        // 9 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult> Lift<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> Lift<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IResult<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<IResult<T10>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9));

        // ------------------------
        // 10 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult> Lift<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IResult> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9, x.Item10));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> Lift<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IResult<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9, x.Item10));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<IResult>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9, x.Item10));

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<IResult<T11>>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10), x => f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9, x.Item10));

        // ------------------------
        // Lift Map
        // ------------------------

        // ------------------------
        // 1 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult> Lift<T1>(
          Action<T1> f) =>
          (rt1) => Binder(Merge(rt1), x => { f(x); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>> Lift<T1, T2>(
          Func<T1, T2> f) =>
          (rt1) => Binder(Merge(rt1), x => Success(f(x)));

        /// Lifts an async function into a function that inputs and outputs results.
        public static Func<IResult<T1>, Task<IResult>> LiftAsync<T1>(
          Func<T1, Task> f) =>
          (rt1) => BinderAsync(Merge(rt1), async x => { await f(x); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, Task<IResult<T2>>> LiftAsync<T1, T2>(
          Func<T1, Task<T2>> f) =>
          (rt1) => BinderAsync(Merge(rt1), async x => Success(await f(x)));

        // ------------------------
        // 2 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult> Lift<T1, T2>(
          Action<T1, T2> f) =>
          (rt1, rt2) => Binder(Merge(rt1, rt2), x => { f(x.Item1, x.Item2); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>> Lift<T1, T2, T3>(
          Func<T1, T2, T3> f) =>
          (rt1, rt2) => Binder(Merge(rt1, rt2), x => Success(f(x.Item1, x.Item2)));

        /// Lifts an async function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult>> LiftAsync<T1, T2>(
          Func<T1, T2, Task> f) =>
          (rt1, rt2) => BinderAsync(Merge(rt1, rt2), async x => { await f(x.Item1, x.Item2); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> LiftAsync<T1, T2, T3>(
          Func<T1, T2, Task<T3>> f) =>
          (rt1, rt2) => BinderAsync(Merge(rt1, rt2), async x => Success(await f(x.Item1, x.Item2)));

        // ------------------------
        // 3 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult> Lift<T1, T2, T3>(
          Action<T1, T2, T3> f) =>
          (rt1, rt2, rt3) => Binder(Merge(rt1, rt2, rt3), x => { f(x.Item1, x.Item2, x.Item3); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> Lift<T1, T2, T3, T4>(
          Func<T1, T2, T3, T4> f) =>
          (rt1, rt2, rt3) => Binder(Merge(rt1, rt2, rt3), x => Success(f(x.Item1, x.Item2, x.Item3)));

        /// Lifts an async function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult>> LiftAsync<T1, T2, T3>(
          Func<T1, T2, T3, Task> f) =>
          (rt1, rt2, rt3) => BinderAsync(Merge(rt1, rt2, rt3), async x => { await f(x.Item1, x.Item2, x.Item3); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, Task<IResult<T4>>> LiftAsync<T1, T2, T3, T4>(
          Func<T1, T2, T3, Task<T4>> f) =>
          (rt1, rt2, rt3) => BinderAsync(Merge(rt1, rt2, rt3), async x => Success(await f(x.Item1, x.Item2, x.Item3)));

        // ------------------------
        // 4 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult> Lift<T1, T2, T3, T4>(
          Action<T1, T2, T3, T4> f) =>
          (rt1, rt2, rt3, rt4) => Binder(Merge(rt1, rt2, rt3, rt4), x => { f(x.Item1, x.Item2, x.Item3, x.Item4); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> Lift<T1, T2, T3, T4, T5>(
          Func<T1, T2, T3, T4, T5> f) =>
          (rt1, rt2, rt3, rt4) => Binder(Merge(rt1, rt2, rt3, rt4), x => Success(f(x.Item1, x.Item2, x.Item3, x.Item4)));

        /// Lifts an async function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult>> LiftAsync<T1, T2, T3, T4>(
          Func<T1, T2, T3, T4, Task> f) =>
          (rt1, rt2, rt3, rt4) => BinderAsync(Merge(rt1, rt2, rt3, rt4), async x => { await f(x.Item1, x.Item2, x.Item3, x.Item4); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, Task<IResult<T5>>> LiftAsync<T1, T2, T3, T4, T5>(
          Func<T1, T2, T3, T4, Task<T5>> f) =>
          (rt1, rt2, rt3, rt4) => BinderAsync(Merge(rt1, rt2, rt3, rt4), async x => Success(await f(x.Item1, x.Item2, x.Item3, x.Item4)));

        // ------------------------
        // 5 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> Lift<T1, T2, T3, T4, T5>(
          Action<T1, T2, T3, T4, T5> f) =>
          (rt1, rt2, rt3, rt4, rt5) => Binder(Merge(rt1, rt2, rt3, rt4, rt5), x => { f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> Lift<T1, T2, T3, T4, T5, T6>(
          Func<T1, T2, T3, T4, T5, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5) => Binder(Merge(rt1, rt2, rt3, rt4, rt5), x => Success(f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5)));

        /// Lifts an async function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5>(
          Func<T1, T2, T3, T4, T5, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5), async x => { await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, Task<IResult<T6>>> LiftAsync<T1, T2, T3, T4, T5, T6>(
          Func<T1, T2, T3, T4, T5, Task<T6>> f) =>
          (rt1, rt2, rt3, rt4, rt5) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5), async x => Success(await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5)));

        // ------------------------
        // 6 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> Lift<T1, T2, T3, T4, T5, T6>(
          Action<T1, T2, T3, T4, T5, T6> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6), x => { f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> Lift<T1, T2, T3, T4, T5, T6, T7>(
          Func<T1, T2, T3, T4, T5, T6, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6), x => Success(f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6)));

        /// Lifts an async function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5, T6>(
          Func<T1, T2, T3, T4, T5, T6, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6), async x => { await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, Task<IResult<T7>>> LiftAsync<T1, T2, T3, T4, T5, T6, T7>(
          Func<T1, T2, T3, T4, T5, T6, Task<T7>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6), async x => Success(await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6)));

        // ------------------------
        // 7 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult> Lift<T1, T2, T3, T4, T5, T6, T7>(
          Action<T1, T2, T3, T4, T5, T6, T7> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7), x => { f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>> Lift<T1, T2, T3, T4, T5, T6, T7, T8>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7), x => Success(f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7)));

        /// Lifts an async function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5, T6, T7>(
          Func<T1, T2, T3, T4, T5, T6, T7, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7), async x => { await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, Task<IResult<T8>>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          Func<T1, T2, T3, T4, T5, T6, T7, Task<T8>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7), async x => Success(await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7)));

        // ------------------------
        // 8 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult> Lift<T1, T2, T3, T4, T5, T6, T7, T8>(
          Action<T1, T2, T3, T4, T5, T6, T7, T8> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8), x => { f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>> Lift<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8), x => Success(f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8)));

        /// Lifts an async function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8), async x => { await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, Task<IResult<T9>>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<T9>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8), async x => Success(await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8)));

        // ------------------------
        // 9 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult> Lift<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9), x => { f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>> Lift<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9), x => Success(f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9)));

        /// Lifts an async function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9), async x => { await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, Task<IResult<T10>>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<T10>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9), async x => Success(await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9)));

        // ------------------------
        // 10 parameter functions.
        // ------------------------
        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult> Lift<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10), x => { f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9, x.Item10); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, IResult<T11>> Lift<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10), x => Success(f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9, x.Item10)));

        /// Lifts an async function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10), async x => { await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9, x.Item10); return Success(); });

        /// Lifts a function into a function that inputs and outputs results.
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>, IResult<T8>, IResult<T9>, IResult<T10>, Task<IResult<T11>>> LiftAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
          Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<T11>> f) =>
          (rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10) => BinderAsync(Merge(rt1, rt2, rt3, rt4, rt5, rt6, rt7, rt8, rt9, rt10), async x => Success(await f(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6, x.Item7, x.Item8, x.Item9, x.Item10)));
    }
}
