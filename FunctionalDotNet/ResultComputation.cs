using System;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public class ResultComputation<T1, T2> : Result
    {
        private readonly Result<(T1, T2)> _inner;

        internal ResultComputation(Result<(T1,T2)> inner) : base(inner.IsSuccess, inner.Errors) =>
            _inner = inner;

        public Result Bind(Func<T1, T2, Result> f) => 
            BindAsync((fst, snd) => Task.FromResult(f(fst, snd))).Result;

        public Task<Result> BindAsync(Func<T1, T2, Task<Result>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2));

        public Result<T3> Bind<T3>(Func<T1, T2, Result<T3>> f) =>
            BindAsync((fst, snd) => Task.FromResult(f(fst, snd))).Result;

        public Task<Result<T3>> BindAsync<T3>(Func<T1, T2, Task<Result<T3>>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2));

        public Result<T3> Map<T3>(Func<T1, T2, T3> f) =>
            MapAsync((fst, snd) => Task.FromResult(f(fst, snd))).Result;

        public Task<Result<T3>> MapAsync<T3>(Func<T1, T2, Task<T3>> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2));

        public Result Map(Action<T1, T2> f) =>
            MapAsync(async (fst, snd) => f(fst, snd)).Result;

        public Task<Result> MapAsync(Func<T1, T2, Task> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2));
    }

    public class ResultComputation<T1, T2, T3> : Result
    {
        private readonly Result<(T1, T2, T3)> _inner;

        internal ResultComputation(Result<(T1, T2, T3)> inner) : base(inner.IsSuccess, inner.Errors) =>
            _inner = inner;

        public Result Bind(Func<T1, T2, T3, Result> f) =>
            BindAsync((fst, snd, trd) => Task.FromResult(f(fst, snd, trd))).Result;

        public Task<Result> BindAsync(Func<T1, T2, T3, Task<Result>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3));

        public Result<T4> Bind<T4>(Func<T1, T2, T3, Result<T4>> f) =>
            BindAsync((fst, snd, trd) => Task.FromResult(f(fst, snd, trd))).Result;

        public Task<Result<T4>> BindAsync<T4>(Func<T1, T2, T3, Task<Result<T4>>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3));

        public Result<T4> Map<T4>(Func<T1, T2, T3, T4> f) =>
            MapAsync((fst, snd, trd) => Task.FromResult(f(fst, snd, trd))).Result;

        public Task<Result<T4>> MapAsync<T4>(Func<T1, T2, T3, Task<T4>> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3));

        public Result Map(Action<T1, T2, T3> f) =>
            MapAsync(async (fst, snd, trd) => f(fst, snd, trd)).Result;

        public Task<Result> MapAsync(Func<T1, T2, T3, Task> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3));
    }

    public class ResultComputation<T1, T2, T3, T4> : Result
    {
        private readonly Result<(T1, T2, T3, T4)> _inner;

        internal ResultComputation(Result<(T1, T2, T3, T4)> inner) : base(inner.IsSuccess, inner.Errors) =>
            _inner = inner;

        public Result Bind(Func<T1, T2, T3, T4, Result> f) =>
            BindAsync((fst, snd, trd, frth) => Task.FromResult(f(fst, snd, trd, frth))).Result;

        public Task<Result> BindAsync(Func<T1, T2, T3, T4, Task<Result>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4));

        public Result<T5> Bind<T5>(Func<T1, T2, T3, T4, Result<T5>> f) =>
            BindAsync((fst, snd, trd, frth) => Task.FromResult(f(fst, snd, trd, frth))).Result;

        public Task<Result<T5>> BindAsync<T5>(Func<T1, T2, T3, T4, Task<Result<T5>>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4));

        public Result<T5> Map<T5>(Func<T1, T2, T3, T4, T5> f) =>
            MapAsync((fst, snd, trd, frth) => Task.FromResult(f(fst, snd, trd, frth))).Result;

        public Task<Result<T5>> MapAsync<T5>(Func<T1, T2, T3, T4, Task<T5>> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4));

        public Result Map(Action<T1, T2, T3, T4> f) =>
            MapAsync(async (fst, snd, trd, frth) => f(fst, snd, trd, frth)).Result;

        public Task<Result> MapAsync(Func<T1, T2, T3, T4, Task> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4));
    }

    public class ResultComputation<T1, T2, T3, T4, T5> : Result
    {
        private readonly Result<(T1, T2, T3, T4, T5)> _inner;

        internal ResultComputation(Result<(T1, T2, T3, T4, T5)> inner) : base(inner.IsSuccess, inner.Errors) =>
            _inner = inner;

        public Result Bind(Func<T1, T2, T3, T4, T5, Result> f) =>
            BindAsync((fst, snd, trd, frth, fifth) => Task.FromResult(f(fst, snd, trd, frth, fifth))).Result;

        public Task<Result> BindAsync(Func<T1, T2, T3, T4, T5, Task<Result>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5));

        public Result<T6> Bind<T6>(Func<T1, T2, T3, T4, T5, Result<T6>> f) =>
            BindAsync((fst, snd, trd, frth, fifth) => Task.FromResult(f(fst, snd, trd, frth, fifth))).Result;

        public Task<Result<T6>> BindAsync<T6>(Func<T1, T2, T3, T4, T5, Task<Result<T6>>> f) =>
            _inner.BindAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5));

        public Result<T6> Map<T6>(Func<T1, T2, T3, T4, T5, T6> f) =>
            MapAsync((fst, snd, trd, frth, fifth) => Task.FromResult(f(fst, snd, trd, frth, fifth))).Result;

        public Task<Result<T6>> MapAsync<T6>(Func<T1, T2, T3, T4, T5, Task<T6>> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5));

        public Result Map(Action<T1, T2, T3, T4, T5> f) =>
            MapAsync(async (fst, snd, trd, frth, fifth) => f(fst, snd, trd, frth, fifth)).Result;

        public Task<Result> MapAsync(Func<T1, T2, T3, T4, T5, Task> f) =>
            _inner.MapAsync(t => f(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5));
    }

    public static class ResultComputation
    {
        private static Result<(T1, T2)> Combine<T1, T2>(Result<T1> first, Result<T2> second)
        {
            var results = new Result[] { first, second };
            if (results.All(x => x.IsSuccess))
                return Result.Success((first.ItemOrDefault, second.ItemOrDefault));

            var errors = results.SelectMany(x => x.Errors);
            return Result.Failure<(T1, T2)>(errors.ToArray());
        }

        public static ResultComputation<T1, T2> Create<T1, T2>(Result<T1> first, Result<T2> second)
            => new ResultComputation<T1, T2>(Combine(first, second));
        //3
        private static Result<(T1, T2, T3)> Combine<T1, T2, T3>(Result<T1> first, Result<T2> second, Result<T3> third)
        {
            var results = new Result[] { first, second, third };
            if (results.All(x => x.IsSuccess))
                return Result.Success((first.ItemOrDefault, second.ItemOrDefault, third.ItemOrDefault));

            var errors = results.SelectMany(x => x.Errors);
            return Result.Failure<(T1, T2, T3)>(errors.ToArray());
        }

        public static ResultComputation<T1, T2, T3> Create<T1, T2, T3>(Result<T1> first, Result<T2> second, Result<T3> third)
            => new ResultComputation<T1, T2, T3>(Combine(first, second, third));
        //4
        private static Result<(T1, T2, T3, T4)> Combine<T1, T2, T3, T4>(Result<T1> first, Result<T2> second, Result<T3> third, Result<T4> forth)
        {
            var results = new Result[] { first, second, third };
            if (results.All(x => x.IsSuccess))
                return Result.Success((first.ItemOrDefault, second.ItemOrDefault, third.ItemOrDefault, forth.ItemOrDefault));

            var errors = results.SelectMany(x => x.Errors);
            return Result.Failure<(T1, T2, T3, T4)>(errors.ToArray());
        }

        public static ResultComputation<T1, T2, T3, T4> Create<T1, T2, T3, T4>(Result<T1> first, Result<T2> second, Result<T3> third, Result<T4> forth)
            => new ResultComputation<T1, T2, T3, T4>(Combine(first, second, third, forth));
        //5
        private static Result<(T1, T2, T3, T4, T5)> Combine<T1, T2, T3, T4, T5>(Result<T1> first, Result<T2> second, Result<T3> third, Result<T4> forth, Result<T5> fifth)
        {
            var results = new Result[] { first, second, third };
            if (results.All(x => x.IsSuccess))
                return Result.Success((first.ItemOrDefault, second.ItemOrDefault, third.ItemOrDefault, forth.ItemOrDefault, fifth.ItemOrDefault));

            var errors = results.SelectMany(x => x.Errors);
            return Result.Failure<(T1, T2, T3, T4, T5)>(errors.ToArray());
        }

        public static ResultComputation<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(Result<T1> first, Result<T2> second, Result<T3> third, Result<T4> forth, Result<T5> fifth)
            => new ResultComputation<T1, T2, T3, T4, T5>(Combine(first, second, third, forth, fifth));
    }
}