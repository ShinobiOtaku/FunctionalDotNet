using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FunctionalDotNet.Result;

namespace FunctionalDotNet
{
    public class ResultComputation<T1, T2, T3, T4, T5, T6> : IResult
    {
        private readonly IResult<T1> _fst;
        private readonly IResult<T2> _snd;
        private readonly IResult<T3> _trd;
        private readonly IResult<T4> _frth;
        private readonly IResult<T5> _fifth;
        private readonly IResult<T6> _six;

        internal ResultComputation(IResult<T1> fst, IResult<T2> snd, IResult<T3> trd, IResult<T4> frth, IResult<T5> fifth, IResult<T6> six)
        {
            _fifth = fifth;
            _six = six;
            _fst = fst;
            _snd = snd;
            _trd = trd;
            _frth = frth;
        }

        public bool IsSuccess => _fst.IsSuccess && _snd.IsSuccess && _trd.IsSuccess && _frth.IsSuccess && _fifth.IsSuccess && _six.IsSuccess;
        public IEnumerable<string> Errors => _fst.Errors.Concat(_snd.Errors).Concat(_trd.Errors).Concat(_frth.Errors).Concat(_fifth.Errors).Concat(_six.Errors);

        public IResult Bind(Func<T1, T2, T3, T4, T5, T6, IResult> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).Apply(_six);

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, T5, T6, Task<IResult>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).Apply(_six).FlipAsync().IgnoreAsync();

        public IResult<T7> Bind<T7>(Func<T1, T2, T3, T4, T5, T6, IResult<T7>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).Apply(_six);

        public Task<IResult<T7>> BindAsync<T7>(Func<T1, T2, T3, T4, T5, T6, Task<IResult<T7>>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).Apply(_six).FlipAsync().FlattenAsync();

        public IResult<T7> Map<T7>(Func<T1, T2, T3, T4, T5, T6, T7> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).Apply(_six);

        public Task<IResult<T7>> MapAsync<T7>(Func<T1, T2, T3, T4, T5, T6, Task<T7>> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).Apply(_six).FlipAsync();

        public IResult Map(Action<T1, T2, T3, T4, T5, T6> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).Apply(_six);

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, T5, T6, Task> f) =>
            Lift(f).Apply(_fst).Apply(_snd).Apply(_trd).Apply(_frth).Apply(_fifth).Apply(_six).FlipAsync();
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(IResult<T1> first, IResult<T2> second, IResult<T3> third, IResult<T4> forth, IResult<T5> fifth, IResult<T6> six)
            => new ResultComputation<T1, T2, T3, T4, T5, T6>(first, second, third, forth, fifth, six);
    }
}