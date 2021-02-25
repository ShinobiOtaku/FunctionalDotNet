using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FunctionalDotNet.Result;

namespace FunctionalDotNet
{
    public class ResultComputation<T1, T2, T3, T4> : IResult
    {
        private readonly IResult<T1> _fst;
        private readonly IResult<T2> _snd;
        private readonly IResult<T3> _trd;
        private readonly IResult<T4> _frth;

        internal ResultComputation(IResult<T1> fst, IResult<T2> snd, IResult<T3> trd, IResult<T4> frth)
        {
            _fst = fst;
            _snd = snd;
            _trd = trd;
            _frth = frth;
        }

        public bool IsSuccess => _fst.IsSuccess && _snd.IsSuccess && _trd.IsSuccess && _frth.IsSuccess;
        public IEnumerable<string> Errors => _fst.Errors.Concat(_snd.Errors).Concat(_trd.Errors).Concat(_frth.Errors);

        public IResult Bind(Func<T1, T2, T3, T4, IResult> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth);

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, Task<IResult>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).FlipAsync().IgnoreAsync();

        public IResult<T5> Bind<T5>(Func<T1, T2, T3, T4, IResult<T5>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth);

        public Task<IResult<T5>> BindAsync<T5>(Func<T1, T2, T3, T4, Task<IResult<T5>>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).FlipAsync().FlattenAsync();

        public IResult<T5> Map<T5>(Func<T1, T2, T3, T4, T5> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth);

        public Task<IResult<T5>> MapAsync<T5>(Func<T1, T2, T3, T4, Task<T5>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).FlipAsync();

        public IResult Map(Action<T1, T2, T3, T4> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth);

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, Task> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).FlipAsync();
    }
    
    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3, T4> Create<T1, T2, T3, T4>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth)
            => new ResultComputation<T1, T2, T3, T4>(first, second, third, forth);
    }
}