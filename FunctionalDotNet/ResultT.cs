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
        // Convenience ctors
        public static IResult<T> Success<T>(T item) => Result<T>.Success(item);
        public static IResult<T> Failure<T>(params string[] errors) => Result<T>.Failure(errors);

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

        // Lift - map
        public static Func<IResult<T1>, IResult<T2>> Lift<T1, T2>(Func<T1, T2> func) => 
            rt1 => rt1.Map(func);

        public static Func<IResult<T1>, IResult<T2>, IResult<T3>> Lift<T1, T2, T3>(Func<T1, T2, T3> func) =>
            (rt1, rt2) => rt1.Bind(t1 => rt2.Map(t2 => func(t1, t2)));

        // Lift - bind
        public static Func<IResult<T1>, IResult<T2>> Lift<T1, T2>(Func<T1, IResult<T2>> func) =>
            rt1 => rt1.Bind(func);

        public static Func<IResult<T1>, IResult<T2>, IResult<T3>> Lift<T1, T2, T3>(Func<T1, T2, IResult<T3>> func) =>
            (rt1, rt2) => rt1.Bind(t1 => rt2.Bind(t2 => func(t1, t2)));
    }
}
