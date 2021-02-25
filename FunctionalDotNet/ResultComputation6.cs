using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public class ResultComputation<T1, T2, T3, T4, T5, T6> : IResult
    {
        private readonly IResult<(T1, T2, T3, T4, T5, T6)> _inner;

        internal ResultComputation(IResult<(T1, T2, T3, T4, T5, T6)> inner) =>
            _inner = inner;

        public bool IsSuccess => _inner.IsSuccess;
        public IEnumerable<string> Errors => _inner.Errors;

        public IResult Bind(Func<T1, T2, T3, T4, T5, T6, IResult> f) =>
            BindAsync((fst, snd, trd, frth, fifth, six) => Task.FromResult(f(fst, snd, trd, frth, fifth, six))).Result;

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, T5, T6, Task<IResult>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6));

        public IResult<T7> Bind<T7>(Func<T1, T2, T3, T4, T5, T6, IResult<T7>> f) =>
            BindAsync((fst, snd, trd, frth, fifth, six) => Task.FromResult(f(fst, snd, trd, frth, fifth, six))).Result;

        public Task<IResult<T7>> BindAsync<T7>(Func<T1, T2, T3, T4, T5, T6, Task<IResult<T7>>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6));

        public IResult<T7> Map<T7>(Func<T1, T2, T3, T4, T5, T6, T7> f) =>
            MapAsync((fst, snd, trd, frth, fifth, six) => Task.FromResult(f(fst, snd, trd, frth, fifth, six))).Result;

        public Task<IResult<T7>> MapAsync<T7>(Func<T1, T2, T3, T4, T5, T6, Task<T7>> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6));

        public IResult Map(Action<T1, T2, T3, T4, T5, T6> f) =>
            MapAsync(async (fst, snd, trd, frth, fifth, six) => f(fst, snd, trd, frth, fifth, six)).Result;

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, T5, T6, Task> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6));
    }

    public static partial class ResultComputation
    {
        //6
        private static IResult<(T1, T2, T3, T4, T5, T6)> Combine<T1, T2, T3, T4, T5, T6>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth, IResult<T5> fifth, IResult<T6> six)
        {
            var results = new IResult[] { first, second, third };
            if (results.All(x => x.IsSuccess))
                return Result.Success((first.ItemOrDefault, second.ItemOrDefault, third.ItemOrDefault, forth.ItemOrDefault, fifth.ItemOrDefault, six.ItemOrDefault));

            var errors = results.SelectMany(x => x.Errors);
            return Result.Failure<(T1, T2, T3, T4, T5, T6)>(errors.ToArray());
        }

        public static ResultComputation<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth, IResult<T5> fifth, IResult<T6> six)
            => new ResultComputation<T1, T2, T3, T4, T5, T6>(Combine(first, second, third, forth, fifth, six));
    }
}