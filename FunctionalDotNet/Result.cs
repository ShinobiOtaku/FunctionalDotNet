using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    /// <inheritdoc />
    public readonly partial struct Result : IResult
    {
        private readonly IEnumerable<string> _errors;

        private Result(bool isSuccess, IEnumerable<string> errors)
        {
            IsSuccess = isSuccess;
            _errors = errors;
        }

        public static IResult Success() =>
            new Result(true, Enumerable.Empty<string>());

        public static IResult Failure(params string[] errors) =>
            new Result(false, errors);
        public static IResult Failure(IEnumerable<string> errors) =>
            Failure(errors.ToArray());

        public bool IsSuccess { get; }

        public IEnumerable<string> Errors => _errors ?? new[] { "Not initialized" };
    }

    public readonly partial struct Result
    {
        // Sequence
        public static IResult Sequence(params IResult[] results) => results.Sequence();
        public static Task<IResult> SequenceAsync(params Task<IResult>[] results) => results.SequenceAsync();
    }
}
