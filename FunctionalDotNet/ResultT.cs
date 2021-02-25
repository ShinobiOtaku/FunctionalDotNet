using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    /// <inheritdoc />
    public readonly struct Result<T> : IResult<T>
    {
        private readonly IEnumerable<string> _errors;
        
        private Result(bool isSuccess, IEnumerable<string> errors, T itemOrDefault)
        {
            ItemOrDefault = itemOrDefault;
            IsSuccess = isSuccess;
            _errors = errors;
        }

        public T ItemOrDefault { get; }

        public bool IsSuccess { get; }

        public IEnumerable<string> Errors => _errors ?? new[] { "Not initialized" };

        internal static IResult<T> Success(T item) =>
            new Result<T>(true, Enumerable.Empty<string>(), item);

        internal static IResult<T> Failure(params string[] errors) =>
            new Result<T>(false, errors, default);
    }

    public readonly partial struct Result
    {
        //----------------
        //   Merge
        //----------------
        //2
        private static IResult<(T1, T2)> Merge<T1, T2>(IResult<T1> fst, IResult<T2> snd) =>
            Sequence(fst,snd).Map(() => (fst.ItemOrDefault, snd.ItemOrDefault));
        //3
        private static IResult<(T1, T2, T3)> Merge<T1, T2, T3>(IResult<T1> fst, IResult<T2> snd, IResult<T3> trd) =>
            Sequence(fst, snd, trd).Map(() => (fst.ItemOrDefault, snd.ItemOrDefault, trd.ItemOrDefault));
        //4
        private static IResult<(T1, T2, T3, T4)> Merge<T1, T2, T3, T4>(IResult<T1> fst, IResult<T2> snd, IResult<T3> trd, IResult<T4> forth) =>
            Sequence(fst, snd, trd, forth).Map(() => (fst.ItemOrDefault, snd.ItemOrDefault, trd.ItemOrDefault, forth.ItemOrDefault));
        //5
        private static IResult<(T1, T2, T3, T4, T5)> Merge<T1, T2, T3, T4, T5>(IResult<T1> fst, IResult<T2> snd, IResult<T3> trd, IResult<T4> forth, IResult<T5> fifth) =>
            Sequence(fst, snd, trd, forth, fifth).Map(() => (fst.ItemOrDefault, snd.ItemOrDefault, trd.ItemOrDefault, forth.ItemOrDefault, fifth.ItemOrDefault));
        //6
        private static IResult<(T1, T2, T3, T4, T5, T6)> Merge<T1, T2, T3, T4, T5, T6>(IResult<T1> fst, IResult<T2> snd, IResult<T3> trd, IResult<T4> forth, IResult<T5> fifth, IResult<T6> six) =>
            Sequence(fst, snd, trd, forth, fifth, six).Map(() => (fst.ItemOrDefault, snd.ItemOrDefault, trd.ItemOrDefault, forth.ItemOrDefault, fifth.ItemOrDefault, six.ItemOrDefault));

        //----------------
        //   Binders
        //----------------
        private static IResult<T2> Binder<T1, T2>(IResult<T1> rt1, Func<T1, IResult<T2>> func) =>
            rt1.IsSuccess ? func(rt1.ItemOrDefault) : Failure<T2>(rt1.Errors);
        private static IResult Binder<T1>(IResult<T1> rt1, Func<T1, IResult> func) =>
            rt1.IsSuccess ? func(rt1.ItemOrDefault) : Failure(rt1.Errors);

        // Convenience ctors
        public static IResult<T> Success<T>(T item) => Result<T>.Success(item);
        public static IResult<T> Failure<T>(params string[] errors) => Result<T>.Failure(errors);
        public static IResult<T> Failure<T>(IEnumerable<string> errors) => Result<T>.Failure(errors.ToArray());

        // Sequence
        public static IResult<IEnumerable<T>> Sequence<T>(params IResult<T>[] results) => results.Sequence();
        public static Task<IResult<IEnumerable<T>>> SequenceAsync<T>(params Task<IResult<T>>[] results) => results.SequenceAsync();

        // Combine
        public static ResultComputation<T1, T2> Combine<T1, T2>(IResult<T1> first, IResult<T2> second) =>
            ResultComputation.Create(first, second);
        public static ResultComputation<T1, T2, T3> Combine<T1, T2, T3>(IResult<T1> first, IResult<T2> second, IResult<T3> third) =>
            ResultComputation.Create(first, second, third);
        public static ResultComputation<T1, T2, T3, T4> Combine<T1, T2, T3, T4>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth) =>
            ResultComputation.Create(first, second, third, forth);
        public static ResultComputation<T1, T2, T3, T4, T5> Combine<T1, T2, T3, T4, T5>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth, IResult<T5> fifth) =>
            ResultComputation.Create(first, second, third, forth, fifth);
        public static ResultComputation<T1, T2, T3, T4, T5, T6> Combine<T1, T2, T3, T4, T5, T6>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth, IResult<T5> fifth, IResult<T6> six) =>
            ResultComputation.Create(first, second, third, forth, fifth, six);

        //----------------
        //   Lift - map
        //----------------
        public static Func<IResult<T1>> Lift<T1>(Func<T1> func) =>
            () => Success(func());
        //1
        public static Func<IResult<T1>, IResult> Lift<T1>(Action<T1> func) =>
            rt1 => Binder(rt1, x => { func(x); return Success(); });
        //2
        public static Func<IResult<T1>, IResult<T2>, IResult> Lift<T1, T2>(Action<T1, T2> func) =>
            (rt1, rt2) => Binder(Merge(rt1, rt2), x => { func(x.Item1, x.Item2); return Success(); });
        //3
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult> Lift<T1, T2, T3>(Action<T1, T2, T3> func) =>
            (rt1, rt2, rt3) => Binder(Merge(rt1, rt2, rt3), x => { func(x.Item1, x.Item2, x.Item3); return Success(); });
        //4
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult> Lift<T1, T2, T3, T4>(Action<T1, T2, T3, T4> func) =>
            (rt1, rt2, rt3, rt4) => Binder(Merge(rt1, rt2, rt3, rt4), x => { func(x.Item1, x.Item2, x.Item3, x.Item4); return Success(); });
        //5
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> Lift<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> func) =>
            (rt1, rt2, rt3, rt4, rt5) => Binder(Merge(rt1, rt2, rt3, rt4, rt5), x => { func(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5); return Success(); });
        //6
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> Lift<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> func) =>
            (rt1, rt2, rt3, rt4, rt5, rt6) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6), x => { func(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6); return Success(); });

        //1
        public static Func<IResult<T1>, IResult<T2>> Lift<T1, T2>(Func<T1, T2> func) => 
            rt1 => Binder(rt1, x => Success(func(x)));
        //2
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>> Lift<T1, T2, T3>(Func<T1, T2, T3> func) =>
            (rt1, rt2) => Binder(Merge(rt1, rt2), x => Success(func(x.Item1, x.Item2)));
        //3
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> Lift<T1, T2, T3, T4>(Func<T1, T2, T3, T4> func) =>
            (rt1, rt2, rt3) => Binder(Merge(rt1, rt2, rt3), x => Success(func(x.Item1, x.Item2, x.Item3)));
        //4
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> Lift<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> func) =>
            (rt1, rt2, rt3, rt4) => Binder(Merge(rt1, rt2, rt3, rt4), x => Success(func(x.Item1, x.Item2, x.Item3, x.Item4)));
        //5
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> Lift<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6> func) =>
            (rt1, rt2, rt3, rt4, rt5) => Binder(Merge(rt1, rt2, rt3, rt4, rt5), x => Success(func(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5)));
        //6
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> Lift<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7> func) =>
            (rt1, rt2, rt3, rt4, rt5, rt6) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6), x => Success(func(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6)));

        //----------------
        //   Lift - bind
        //----------------
        //1
        public static Func<IResult<T1>, IResult<T2>> Lift<T1, T2>(Func<T1, IResult<T2>> func) =>
            rt1 => Binder(rt1, func);
        public static Func<IResult<T1>, IResult> Lift<T1>(Func<T1, IResult> func) =>
            rt1 => Binder(rt1, func);
        //2
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>> Lift<T1, T2, T3>(Func<T1, T2, IResult<T3>> func) => 
            (rt1, rt2) => Binder(Merge(rt1, rt2), x => func(x.Item1, x.Item2));
        public static Func<IResult<T1>, IResult<T2>, IResult> Lift<T1, T2>(Func<T1, T2, IResult> func) =>
            (rt1, rt2) => Binder(Merge(rt1, rt2), x => func(x.Item1, x.Item2));
        //3
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>> Lift<T1, T2, T3, T4>(Func<T1, T2, T3, IResult<T4>> func) =>
            (rt1, rt2, rt3) => Binder(Merge(rt1, rt2, rt3), x => func(x.Item1, x.Item2, x.Item3));
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult> Lift<T1, T2, T3>(Func<T1, T2, T3, IResult> func) =>
            (rt1, rt2, rt3) => Binder(Merge(rt1, rt2, rt3), x => func(x.Item1, x.Item2, x.Item3));
        //4
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>> Lift<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, IResult<T5>> func) =>
            (rt1, rt2, rt3, rt4) => Binder(Merge(rt1, rt2, rt3, rt4), x => func(x.Item1, x.Item2, x.Item3, x.Item4));
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult> Lift<T1, T2, T3, T4>(Func<T1, T2, T3, T4, IResult> func) =>
            (rt1, rt2, rt3, rt4) => Binder(Merge(rt1, rt2, rt3, rt4), x => func(x.Item1, x.Item2, x.Item3, x.Item4));
        //5
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>> Lift<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, IResult<T6>> func) =>
            (rt1, rt2, rt3, rt4, rt5) => Binder(Merge(rt1, rt2, rt3, rt4, rt5), x => func(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5));
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult> Lift<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, IResult> func) =>
            (rt1, rt2, rt3, rt4, rt5) => Binder(Merge(rt1, rt2, rt3, rt4, rt5), x => func(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5));
        //6
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult<T7>> Lift<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, IResult<T7>> func) =>
            (rt1, rt2, rt3, rt4, rt5, rt6) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6), x => func(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6));
        public static Func<IResult<T1>, IResult<T2>, IResult<T3>, IResult<T4>, IResult<T5>, IResult<T6>, IResult> Lift<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, IResult> func) =>
            (rt1, rt2, rt3, rt4, rt5, rt6) => Binder(Merge(rt1, rt2, rt3, rt4, rt5, rt6), x => func(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5, x.Item6));
    }
}
