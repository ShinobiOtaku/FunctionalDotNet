using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FunctionalDotNet.Result;

namespace FunctionalDotNet
{
    public class ResultComputation<T1, T2, T3> : IResult
    {
        private readonly IResult<T1> _fst;
        private readonly IResult<T2> _snd;
        private readonly IResult<T3> _trd;

        internal ResultComputation(IResult<T1> fst, IResult<T2> snd, IResult<T3> trd)
        {
            _fst = fst;
            _snd = snd;
            _trd = trd;
        }

        public bool IsSuccess => _fst.IsSuccess && _snd.IsSuccess && _trd.IsSuccess;
        public IEnumerable<string> Errors => _fst.Errors.Concat(_snd.Errors).Concat(_trd.Errors);
        public IResult Bind(Func<T1, T2, T3, IResult> f) => Lift(f).Apply(_fst).Apply(_snd).Apply(_trd);
        public Task<IResult> BindAsync(Func<T1, T2, T3, Task<IResult>> f) => 
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).FlipAsync().IgnoreAsync();
        public IResult<T4> Bind<T4>(Func<T1, T2, T3, IResult<T4>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd);
        public Task<IResult<T4>> BindAsync<T4>(Func<T1, T2, T3, Task<IResult<T4>>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).FlipAsync().FlattenAsync();
        public IResult<T4> Map<T4>(Func<T1, T2, T3, T4> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd);
        public Task<IResult<T4>> MapAsync<T4>(Func<T1, T2, T3, Task<T4>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).FlipAsync();
        public IResult Map(Action<T1, T2, T3> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd);
        public Task<IResult> MapAsync(Func<T1, T2, T3, Task> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).FlipAsync();
    }
    
    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3> Create<T1, T2, T3>(IResult<T1> first, IResult<T2> second, IResult<T3> third)
            => new ResultComputation<T1, T2, T3>(first, second, third);
    }
}