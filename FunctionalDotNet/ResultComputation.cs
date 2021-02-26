using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FunctionalDotNet.Result;

namespace FunctionalDotNet
{
    //TODO: combine again to add more results
    //use this one

    public class ResultComputation<T1, T2> : IResult
    {
        private readonly IResult<T1> _fst;
        private readonly IResult<T2> _snd;

        internal ResultComputation(IResult<T1> fst, IResult<T2> snd)
        {
            _fst = fst;
            _snd = snd;
        }

        public bool IsSuccess => _fst.IsSuccess && _snd.IsSuccess;
        public IEnumerable<string> Errors => _fst.Errors.Concat(_snd.Errors);

        public IResult Bind(Func<T1, T2, IResult> f) =>
            Lift(f).Apply(_fst).Apply(_snd);

        public Task<IResult> BindAsync(Func<T1, T2, Task<IResult>> f) =>
            LiftAsync(f).ApplyAsync(_fst).ApplyAsync(_snd);

        public IResult<T3> Bind<T3>(Func<T1, T2, IResult<T3>> f) =>
            Lift(f).Apply(_fst).Apply(_snd);

        public Task<IResult<T3>> BindAsync<T3>(Func<T1, T2, Task<IResult<T3>>> f) =>
            LiftAsync(f).ApplyAsync(_fst).ApplyAsync(_snd);

        public IResult<T3> Map<T3>(Func<T1, T2, T3> f) =>
            Lift(f).Apply(_fst).Apply(_snd);

        public Task<IResult<T3>> MapAsync<T3>(Func<T1, T2, Task<T3>> f) =>
            LiftAsync(f).ApplyAsync(_fst).ApplyAsync(_snd);

        public IResult Map(Action<T1, T2> f) =>
            Lift(f).Apply(_fst).Apply(_snd);

        public Task<IResult> MapAsync(Func<T1, T2, Task> f) =>
            LiftAsync(f).ApplyAsync(_fst).ApplyAsync(_snd);
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2> Create<T1, T2>(IResult<T1> first, IResult<T2> second) =>
            new ResultComputation<T1, T2>(first, second);
    }
}