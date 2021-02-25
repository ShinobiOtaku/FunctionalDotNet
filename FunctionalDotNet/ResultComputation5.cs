using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public class ResultComputation<T1, T2, T3, T4, T5> : IResult
    {
        private readonly IResult<(T1, T2, T3, T4, T5)> _inner;

        internal ResultComputation(IResult<(T1, T2, T3, T4, T5)> inner) =>
            _inner = inner;

        public bool IsSuccess => _inner.IsSuccess;
        public IEnumerable<string> Errors => _inner.Errors;

        public IResult Bind(Func<T1, T2, T3, T4, T5, IResult> f) =>
            BindAsync((fst, snd, trd, frth, fifth) => Task.FromResult(f(fst, snd, trd, frth, fifth))).Result;

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, T5, Task<IResult>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5));

        public IResult<T6> Bind<T6>(Func<T1, T2, T3, T4, T5, IResult<T6>> f) =>
            BindAsync((fst, snd, trd, frth, fifth) => Task.FromResult(f(fst, snd, trd, frth, fifth))).Result;

        public Task<IResult<T6>> BindAsync<T6>(Func<T1, T2, T3, T4, T5, Task<IResult<T6>>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5));

        public IResult<T6> Map<T6>(Func<T1, T2, T3, T4, T5, T6> f) =>
            MapAsync((fst, snd, trd, frth, fifth) => Task.FromResult(f(fst, snd, trd, frth, fifth))).Result;

        public Task<IResult<T6>> MapAsync<T6>(Func<T1, T2, T3, T4, T5, Task<T6>> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5));

        public IResult Map(Action<T1, T2, T3, T4, T5> f) =>
            MapAsync(async (fst, snd, trd, frth, fifth) => f(fst, snd, trd, frth, fifth)).Result;

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, T5, Task> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5));
    }

    public static partial class ResultComputation
    {
        //5
        private static IResult<(T1, T2, T3, T4, T5)> Combine<T1, T2, T3, T4, T5>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth, IResult<T5> fifth)
        {
            var results = new IResult[] { first, second, third };
            if (results.All(x => x.IsSuccess))
                return Result.Success((first.ItemOrDefault, second.ItemOrDefault, third.ItemOrDefault, forth.ItemOrDefault, fifth.ItemOrDefault));

            var errors = results.SelectMany(x => x.Errors);
            return Result.Failure<(T1, T2, T3, T4, T5)>(errors.ToArray());
        }

        public static ResultComputation<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth, IResult<T5> fifth)
            => new ResultComputation<T1, T2, T3, T4, T5>(Combine(first, second, third, forth, fifth));
    }
}