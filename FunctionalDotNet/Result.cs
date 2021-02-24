using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    /// <summary>
    /// The result of something.
    ///
    /// Has two states:
    /// - Success: <see cref="Errors"/> is empty.
    /// - Failure: <see cref="Errors"/> is populated.
    /// </summary>
    public partial class Result
    {
        protected Result(bool isSuccess, IEnumerable<string> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public bool IsSuccess { get; }

        public IEnumerable<string> Errors { get; }
    }

    /// <summary>
    /// The result of something.
    ///
    /// Has two states:
    /// - Success: <see cref="ItemOrDefault"/> is populated,<see cref="Errors"/> is empty.
    /// - Failure: <see cref="ItemOrDefault"/> is set to the default <see cref="T"/>,<see cref="Errors"/> is populated.
    /// </summary>
    public class Result<T> : Result
    {
        private Result(bool isSuccess, IEnumerable<string> errors, T itemOrDefault)
            : base(isSuccess, errors)
        {
            ItemOrDefault = itemOrDefault;
        }

        public T ItemOrDefault { get; }

        internal static Result<T> Success(T item) =>
            new Result<T>(true, Enumerable.Empty<string>(), item);

        internal static Result<T> Failure(params string[] errors) =>
            new Result<T>(false, errors, default);
    }

    public partial class Result
    {
        public static Result Success() =>
            new Result(true, Enumerable.Empty<string>());

        public static Result Failure(params string[] errors) =>
            new Result(false, errors);

        public static Result<T> Success<T>(T item) => Result<T>.Success(item);

        public static Result<T> Failure<T>(params string[] errors) => Result<T>.Failure(errors);

        public static Result Sequence(params Result[] results) => results.Sequence();
        public static Result<IEnumerable<T>> Sequence<T>(params Result<T>[] results) => results.Sequence();
        public static Task<Result> SequenceAsync(params Task<Result>[] results) => results.SequenceAsync();
        public static Task<Result<IEnumerable<T>>> SequenceAsync<T>(params Task<Result<T>>[] results) => results.SequenceAsync();

        public static ResultComputation<T1, T2> Combine<T1, T2>(Result<T1> first, Result<T2> second) =>
            ResultComputation.Create(first, second);
    }
}
