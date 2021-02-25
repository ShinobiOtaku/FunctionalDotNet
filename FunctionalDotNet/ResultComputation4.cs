using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public class ResultComputation<T1, T2, T3, T4> : IResult
    {
        private readonly IResult<(T1, T2, T3, T4)> _inner;

        internal ResultComputation(IResult<(T1, T2, T3, T4)> inner) =>
            _inner = inner;

        public bool IsSuccess => _inner.IsSuccess;
        public IEnumerable<string> Errors => _inner.Errors;

        public IResult Bind(Func<T1, T2, T3, T4, IResult> f) =>
            BindAsync((fst, snd, trd, frth) => Task.FromResult(f(fst, snd, trd, frth))).Result;

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, Task<IResult>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4));

        public IResult<T5> Bind<T5>(Func<T1, T2, T3, T4, IResult<T5>> f) =>
            BindAsync((fst, snd, trd, frth) => Task.FromResult(f(fst, snd, trd, frth))).Result;

        public Task<IResult<T5>> BindAsync<T5>(Func<T1, T2, T3, T4, Task<IResult<T5>>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4));

        public IResult<T5> Map<T5>(Func<T1, T2, T3, T4, T5> f) =>
            MapAsync((fst, snd, trd, frth) => Task.FromResult(f(fst, snd, trd, frth))).Result;

        public Task<IResult<T5>> MapAsync<T5>(Func<T1, T2, T3, T4, Task<T5>> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4));

        public IResult Map(Action<T1, T2, T3, T4> f) =>
            MapAsync(async (fst, snd, trd, frth) => f(fst, snd, trd, frth)).Result;

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, Task> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4));
    }
    
    public static partial class ResultComputation
    {
        //4
        private static IResult<(T1, T2, T3, T4)> Combine<T1, T2, T3, T4>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth)
        {
            var results = new IResult[] { first, second, third };
            if (results.All(x => x.IsSuccess))
                return Result.Success((first.ItemOrDefault, second.ItemOrDefault, third.ItemOrDefault, forth.ItemOrDefault));

            var errors = results.SelectMany(x => x.Errors);
            return Result.Failure<(T1, T2, T3, T4)>(errors.ToArray());
        }

        public static ResultComputation<T1, T2, T3, T4> Create<T1, T2, T3, T4>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth)
            => new ResultComputation<T1, T2, T3, T4>(Combine(first, second, third, forth));
    }
}