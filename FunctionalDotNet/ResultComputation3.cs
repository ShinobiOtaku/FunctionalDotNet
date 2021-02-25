using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public class ResultComputation<T1, T2, T3> : IResult
    {
        private readonly IResult<(T1, T2, T3)> _inner;

        internal ResultComputation(IResult<(T1, T2, T3)> inner) =>
            _inner = inner;

        public bool IsSuccess => _inner.IsSuccess;
        public IEnumerable<string> Errors => _inner.Errors;

        public IResult Bind(Func<T1, T2, T3, IResult> f) =>
            BindAsync((fst, snd, trd) => Task.FromResult(f(fst, snd, trd))).Result;

        public Task<IResult> BindAsync(Func<T1, T2, T3, Task<IResult>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3));

        public IResult<T4> Bind<T4>(Func<T1, T2, T3, IResult<T4>> f) =>
            BindAsync((fst, snd, trd) => Task.FromResult(f(fst, snd, trd))).Result;

        public Task<IResult<T4>> BindAsync<T4>(Func<T1, T2, T3, Task<IResult<T4>>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3));

        public IResult<T4> Map<T4>(Func<T1, T2, T3, T4> f) =>
            MapAsync((fst, snd, trd) => Task.FromResult(f(fst, snd, trd))).Result;

        public Task<IResult<T4>> MapAsync<T4>(Func<T1, T2, T3, Task<T4>> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3));

        public IResult Map(Action<T1, T2, T3> f) =>
            MapAsync(async (fst, snd, trd) => f(fst, snd, trd)).Result;

        public Task<IResult> MapAsync(Func<T1, T2, T3, Task> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3));
    }
    
    public static partial class ResultComputation
    {
        private static IResult<(T1, T2, T3)> Combine<T1, T2, T3>(IResult<T1> first, IResult<T2> second, IResult<T3> third)
        {
            var results = new IResult[] { first, second, third };
            if (results.All(x => x.IsSuccess))
                return Result.Success((first.ItemOrDefault, second.ItemOrDefault, third.ItemOrDefault));

            var errors = results.SelectMany(x => x.Errors);
            return Result.Failure<(T1, T2, T3)>(errors.ToArray());
        }

        public static ResultComputation<T1, T2, T3> Create<T1, T2, T3>(IResult<T1> first, IResult<T2> second, IResult<T3> third)
            => new ResultComputation<T1, T2, T3>(Combine(first, second, third));
    }
}