using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet.Result
{
    public class ResultComputation<T1, T2> : Result
    {
        private readonly Result<(T1, T2)> _inner;

        internal ResultComputation(Result<(T1,T2)> inner) : base(inner.IsSuccess, inner.Errors) =>
            _inner = inner;

        public Result Bind(Func<T1, T2, Result> f) => 
            BindAsync((fst, snd) => Task.FromResult(f(fst, snd))).Result;

        public Task<Result> BindAsync(Func<T1, T2, Task<Result>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2));

        public Result<T3> Bind<T3>(Func<T1, T2, Result<T3>> f) =>
            BindAsync((fst, snd) => Task.FromResult(f(fst, snd))).Result;

        public Task<Result<T3>> BindAsync<T3>(Func<T1, T2, Task<Result<T3>>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2));

        public Result<T3> Map<T3>(Func<T1, T2, T3> f) =>
            MapAsync((fst, snd) => Task.FromResult(f(fst, snd))).Result;

        public Task<Result<T3>> MapAsync<T3>(Func<T1, T2, Task<T3>> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2));

        public Result Map(Action<T1, T2> f) =>
            MapAsync(async (fst, snd) => f(fst, snd)).Result;

        public Task<Result> MapAsync(Func<T1, T2, Task> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2));
    }

    public static class ResultComputation
    {
        private static Result<(T1, T2)> Combine<T1, T2>(Result<T1> first, Result<T2> second)
        {
            var results = new Result[] { first, second };
            if (results.All(x => x.IsSuccess))
                return Result.Success((first.ItemOrDefault, second.ItemOrDefault));

            var errors = results.SelectMany(x => x.Errors);
            return Result.Failure<(T1, T2)>(errors.ToArray());
        }

        public static ResultComputation<T1, T2> Create<T1, T2>(Result<T1> first, Result<T2> second)
            => new ResultComputation<T1, T2>(Combine(first, second));
    }
}