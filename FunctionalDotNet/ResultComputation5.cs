using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FunctionalDotNet.Result;

namespace FunctionalDotNet
{
    public class ResultComputation<T1, T2, T3, T4, T5> : IResult
    {
        private readonly IResult<T1> _fst;
        private readonly IResult<T2> _snd;
        private readonly IResult<T3> _trd;
        private readonly IResult<T4> _frth;
        private readonly IResult<T5> _fifth;

        internal ResultComputation(IResult<T1> fst, IResult<T2> snd, IResult<T3> trd, IResult<T4> frth, IResult<T5> fifth)
        {
            _fifth = fifth;
            _fst = fst;
            _snd = snd;
            _trd = trd;
            _frth = frth;
        }

        public bool IsSuccess => _fst.IsSuccess && _snd.IsSuccess && _trd.IsSuccess && _frth.IsSuccess && _fifth.IsSuccess;
        public IEnumerable<string> Errors => _fst.Errors.Concat(_snd.Errors).Concat(_trd.Errors).Concat(_frth.Errors).Concat(_fifth.Errors);

        public IResult Bind(Func<T1, T2, T3, T4, T5, IResult> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth);

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, T5, Task<IResult>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).FlipAsync().IgnoreAsync();

        public IResult<T6> Bind<T6>(Func<T1, T2, T3, T4, T5, IResult<T6>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth);

        public Task<IResult<T6>> BindAsync<T6>(Func<T1, T2, T3, T4, T5, Task<IResult<T6>>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).FlipAsync().FlattenAsync();

        public IResult<T6> Map<T6>(Func<T1, T2, T3, T4, T5, T6> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth);

        public Task<IResult<T6>> MapAsync<T6>(Func<T1, T2, T3, T4, T5, Task<T6>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).FlipAsync();

        public IResult Map(Action<T1, T2, T3, T4, T5> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth);

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, T5, Task> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).FlipAsync();
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth, IResult<T5> fifth)
            => new ResultComputation<T1, T2, T3, T4, T5>(first, second, third, forth, fifth);
    }
}