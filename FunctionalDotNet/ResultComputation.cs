using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public class ResultComputation<T1, T2> : IResult
    {
        private readonly IResult<(T1, T2)> _inner;

        internal ResultComputation(IResult<(T1,T2)> inner) =>
            _inner = inner;

        public bool IsSuccess => _inner.IsSuccess;
        public IEnumerable<string> Errors => _inner.Errors;

        public IResult Bind(Func<T1, T2, IResult> f) => 
            BindAsync((fst, snd) => Task.FromResult(f(fst, snd))).Result;

        public Task<IResult> BindAsync(Func<T1, T2, Task<IResult>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2));

        public IResult<T3> Bind<T3>(Func<T1, T2, IResult<T3>> f) =>
            BindAsync((fst, snd) => Task.FromResult(f(fst, snd))).Result;

        public Task<IResult<T3>> BindAsync<T3>(Func<T1, T2, Task<IResult<T3>>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2));

        public IResult<T3> Map<T3>(Func<T1, T2, T3> f) =>
            MapAsync((fst, snd) => Task.FromResult(f(fst, snd))).Result;

        public Task<IResult<T3>> MapAsync<T3>(Func<T1, T2, Task<T3>> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2));

        public IResult Map(Action<T1, T2> f) =>
            MapAsync(async (fst, snd) => f(fst, snd)).Result;

        public Task<IResult> MapAsync(Func<T1, T2, Task> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2));
    }
    
    public static partial class ResultComputation
    {
        private static IResult<(T1, T2)> Combine<T1, T2>(IResult<T1> first, IResult<T2> second)
        {
            var results = new IResult[] { first, second };
            if (results.All(x => x.IsSuccess))
                return Result.Success((first.ItemOrDefault, second.ItemOrDefault));

            var errors = results.SelectMany(x => x.Errors);
            return Result.Failure<(T1, T2)>(errors.ToArray());
        }

        public static ResultComputation<T1, T2> Create<T1, T2>(IResult<T1> first, IResult<T2> second)
            => new ResultComputation<T1, T2>(Combine(first, second));
    }
}