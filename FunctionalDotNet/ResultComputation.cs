using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FunctionalDotNet.Result;

namespace FunctionalDotNet
{
    ///TODO: document funcs
    // ------------------------
    // 2 parameter functions.
    // ------------------------
    public class ResultComputation<T1, T2> : IResult
    {
        private readonly IResult<T1> _a;
        private readonly IResult<T2> _b;

        internal ResultComputation(IResult<T1> a, IResult<T2> b)
        {
            _a = a;
            _b = b;
        }

        public bool IsSuccess => _a.IsSuccess && _b.IsSuccess;
        public IEnumerable<string> Errors => (_a.Errors).Concat(_b.Errors);

        public IResult Bind(Func<T1, T2, IResult> f) =>
          Lift(f).Apply(_a).Apply(_b);

        public Task<IResult> BindAsync(Func<T1, T2, Task<IResult>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b);

        public IResult<T3> Bind<T3>(Func<T1, T2, IResult<T3>> f) =>
          Lift(f).Apply(_a).Apply(_b);

        public Task<IResult<T3>> BindAsync<T3>(Func<T1, T2, Task<IResult<T3>>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b);

        public IResult<T3> Map<T3>(Func<T1, T2, T3> f) =>
          Lift(f).Apply(_a).Apply(_b);

        public Task<IResult<T3>> MapAsync<T3>(Func<T1, T2, Task<T3>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b);

        public IResult Map(Action<T1, T2> f) =>
          Lift(f).Apply(_a).Apply(_b);

        public Task<IResult> MapAsync(Func<T1, T2, Task> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b);
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2> Create<T1, T2>(IResult<T1> a, IResult<T2> b) =>
          new ResultComputation<T1, T2>(a, b);
    }

    // ------------------------
    // 3 parameter functions.
    // ------------------------
    public class ResultComputation<T1, T2, T3> : IResult
    {
        private readonly IResult<T1> _a;
        private readonly IResult<T2> _b;
        private readonly IResult<T3> _c;

        internal ResultComputation(IResult<T1> a, IResult<T2> b, IResult<T3> c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public bool IsSuccess => _a.IsSuccess && _b.IsSuccess && _c.IsSuccess;
        public IEnumerable<string> Errors => (_a.Errors).Concat(_b.Errors).Concat(_c.Errors);

        public IResult Bind(Func<T1, T2, T3, IResult> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c);

        public Task<IResult> BindAsync(Func<T1, T2, T3, Task<IResult>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c);

        public IResult<T4> Bind<T4>(Func<T1, T2, T3, IResult<T4>> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c);

        public Task<IResult<T4>> BindAsync<T4>(Func<T1, T2, T3, Task<IResult<T4>>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c);

        public IResult<T4> Map<T4>(Func<T1, T2, T3, T4> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c);

        public Task<IResult<T4>> MapAsync<T4>(Func<T1, T2, T3, Task<T4>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c);

        public IResult Map(Action<T1, T2, T3> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c);

        public Task<IResult> MapAsync(Func<T1, T2, T3, Task> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c);
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3> Create<T1, T2, T3>(IResult<T1> a, IResult<T2> b, IResult<T3> c) =>
          new ResultComputation<T1, T2, T3>(a, b, c);
    }

    // ------------------------
    // 4 parameter functions.
    // ------------------------
    public class ResultComputation<T1, T2, T3, T4> : IResult
    {
        private readonly IResult<T1> _a;
        private readonly IResult<T2> _b;
        private readonly IResult<T3> _c;
        private readonly IResult<T4> _d;

        internal ResultComputation(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public bool IsSuccess => _a.IsSuccess && _b.IsSuccess && _c.IsSuccess && _d.IsSuccess;
        public IEnumerable<string> Errors => (_a.Errors).Concat(_b.Errors).Concat(_c.Errors).Concat(_d.Errors);

        public IResult Bind(Func<T1, T2, T3, T4, IResult> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d);

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, Task<IResult>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d);

        public IResult<T5> Bind<T5>(Func<T1, T2, T3, T4, IResult<T5>> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d);

        public Task<IResult<T5>> BindAsync<T5>(Func<T1, T2, T3, T4, Task<IResult<T5>>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d);

        public IResult<T5> Map<T5>(Func<T1, T2, T3, T4, T5> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d);

        public Task<IResult<T5>> MapAsync<T5>(Func<T1, T2, T3, T4, Task<T5>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d);

        public IResult Map(Action<T1, T2, T3, T4> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d);

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, Task> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d);
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3, T4> Create<T1, T2, T3, T4>(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d) =>
          new ResultComputation<T1, T2, T3, T4>(a, b, c, d);
    }

    // ------------------------
    // 5 parameter functions.
    // ------------------------
    public class ResultComputation<T1, T2, T3, T4, T5> : IResult
    {
        private readonly IResult<T1> _a;
        private readonly IResult<T2> _b;
        private readonly IResult<T3> _c;
        private readonly IResult<T4> _d;
        private readonly IResult<T5> _e;

        internal ResultComputation(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _e = e;
        }

        public bool IsSuccess => _a.IsSuccess && _b.IsSuccess && _c.IsSuccess && _d.IsSuccess && _e.IsSuccess;
        public IEnumerable<string> Errors => (_a.Errors).Concat(_b.Errors).Concat(_c.Errors).Concat(_d.Errors).Concat(_e.Errors);

        public IResult Bind(Func<T1, T2, T3, T4, T5, IResult> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e);

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, T5, Task<IResult>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e);

        public IResult<T6> Bind<T6>(Func<T1, T2, T3, T4, T5, IResult<T6>> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e);

        public Task<IResult<T6>> BindAsync<T6>(Func<T1, T2, T3, T4, T5, Task<IResult<T6>>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e);

        public IResult<T6> Map<T6>(Func<T1, T2, T3, T4, T5, T6> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e);

        public Task<IResult<T6>> MapAsync<T6>(Func<T1, T2, T3, T4, T5, Task<T6>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e);

        public IResult Map(Action<T1, T2, T3, T4, T5> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e);

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, T5, Task> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e);
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e) =>
          new ResultComputation<T1, T2, T3, T4, T5>(a, b, c, d, e);
    }

    // ------------------------
    // 6 parameter functions.
    // ------------------------
    public class ResultComputation<T1, T2, T3, T4, T5, T6> : IResult
    {
        private readonly IResult<T1> _a;
        private readonly IResult<T2> _b;
        private readonly IResult<T3> _c;
        private readonly IResult<T4> _d;
        private readonly IResult<T5> _e;
        private readonly IResult<T6> _f;

        internal ResultComputation(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e, IResult<T6> f)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _e = e;
            _f = f;
        }

        public bool IsSuccess => _a.IsSuccess && _b.IsSuccess && _c.IsSuccess && _d.IsSuccess && _e.IsSuccess && _f.IsSuccess;
        public IEnumerable<string> Errors => (_a.Errors).Concat(_b.Errors).Concat(_c.Errors).Concat(_d.Errors).Concat(_e.Errors).Concat(_f.Errors);

        public IResult Bind(Func<T1, T2, T3, T4, T5, T6, IResult> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f);

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, T5, T6, Task<IResult>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f);

        public IResult<T7> Bind<T7>(Func<T1, T2, T3, T4, T5, T6, IResult<T7>> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f);

        public Task<IResult<T7>> BindAsync<T7>(Func<T1, T2, T3, T4, T5, T6, Task<IResult<T7>>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f);

        public IResult<T7> Map<T7>(Func<T1, T2, T3, T4, T5, T6, T7> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f);

        public Task<IResult<T7>> MapAsync<T7>(Func<T1, T2, T3, T4, T5, T6, Task<T7>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f);

        public IResult Map(Action<T1, T2, T3, T4, T5, T6> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f);

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, T5, T6, Task> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f);
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e, IResult<T6> f) =>
          new ResultComputation<T1, T2, T3, T4, T5, T6>(a, b, c, d, e, f);
    }

    // ------------------------
    // 7 parameter functions.
    // ------------------------
    public class ResultComputation<T1, T2, T3, T4, T5, T6, T7> : IResult
    {
        private readonly IResult<T1> _a;
        private readonly IResult<T2> _b;
        private readonly IResult<T3> _c;
        private readonly IResult<T4> _d;
        private readonly IResult<T5> _e;
        private readonly IResult<T6> _f;
        private readonly IResult<T7> _g;

        internal ResultComputation(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e, IResult<T6> f, IResult<T7> g)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _e = e;
            _f = f;
            _g = g;
        }

        public bool IsSuccess => _a.IsSuccess && _b.IsSuccess && _c.IsSuccess && _d.IsSuccess && _e.IsSuccess && _f.IsSuccess && _g.IsSuccess;
        public IEnumerable<string> Errors => (_a.Errors).Concat(_b.Errors).Concat(_c.Errors).Concat(_d.Errors).Concat(_e.Errors).Concat(_f.Errors).Concat(_g.Errors);

        public IResult Bind(Func<T1, T2, T3, T4, T5, T6, T7, IResult> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g);

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, T5, T6, T7, Task<IResult>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g);

        public IResult<T8> Bind<T8>(Func<T1, T2, T3, T4, T5, T6, T7, IResult<T8>> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g);

        public Task<IResult<T8>> BindAsync<T8>(Func<T1, T2, T3, T4, T5, T6, T7, Task<IResult<T8>>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g);

        public IResult<T8> Map<T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g);

        public Task<IResult<T8>> MapAsync<T8>(Func<T1, T2, T3, T4, T5, T6, T7, Task<T8>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g);

        public IResult Map(Action<T1, T2, T3, T4, T5, T6, T7> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g);

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, T5, T6, T7, Task> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g);
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e, IResult<T6> f, IResult<T7> g) =>
          new ResultComputation<T1, T2, T3, T4, T5, T6, T7>(a, b, c, d, e, f, g);
    }

    // ------------------------
    // 8 parameter functions.
    // ------------------------
    public class ResultComputation<T1, T2, T3, T4, T5, T6, T7, T8> : IResult
    {
        private readonly IResult<T1> _a;
        private readonly IResult<T2> _b;
        private readonly IResult<T3> _c;
        private readonly IResult<T4> _d;
        private readonly IResult<T5> _e;
        private readonly IResult<T6> _f;
        private readonly IResult<T7> _g;
        private readonly IResult<T8> _h;

        internal ResultComputation(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e, IResult<T6> f, IResult<T7> g, IResult<T8> h)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _e = e;
            _f = f;
            _g = g;
            _h = h;
        }

        public bool IsSuccess => _a.IsSuccess && _b.IsSuccess && _c.IsSuccess && _d.IsSuccess && _e.IsSuccess && _f.IsSuccess && _g.IsSuccess && _h.IsSuccess;
        public IEnumerable<string> Errors => (_a.Errors).Concat(_b.Errors).Concat(_c.Errors).Concat(_d.Errors).Concat(_e.Errors).Concat(_f.Errors).Concat(_g.Errors).Concat(_h.Errors);

        public IResult Bind(Func<T1, T2, T3, T4, T5, T6, T7, T8, IResult> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h);

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<IResult>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h);

        public IResult<T9> Bind<T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, IResult<T9>> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h);

        public Task<IResult<T9>> BindAsync<T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<IResult<T9>>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h);

        public IResult<T9> Map<T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h);

        public Task<IResult<T9>> MapAsync<T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<T9>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h);

        public IResult Map(Action<T1, T2, T3, T4, T5, T6, T7, T8> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h);

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h);
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e, IResult<T6> f, IResult<T7> g, IResult<T8> h) =>
          new ResultComputation<T1, T2, T3, T4, T5, T6, T7, T8>(a, b, c, d, e, f, g, h);
    }

    // ------------------------
    // 9 parameter functions.
    // ------------------------
    public class ResultComputation<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IResult
    {
        private readonly IResult<T1> _a;
        private readonly IResult<T2> _b;
        private readonly IResult<T3> _c;
        private readonly IResult<T4> _d;
        private readonly IResult<T5> _e;
        private readonly IResult<T6> _f;
        private readonly IResult<T7> _g;
        private readonly IResult<T8> _h;
        private readonly IResult<T9> _i;

        internal ResultComputation(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e, IResult<T6> f, IResult<T7> g, IResult<T8> h, IResult<T9> i)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _e = e;
            _f = f;
            _g = g;
            _h = h;
            _i = i;
        }

        public bool IsSuccess => _a.IsSuccess && _b.IsSuccess && _c.IsSuccess && _d.IsSuccess && _e.IsSuccess && _f.IsSuccess && _g.IsSuccess && _h.IsSuccess && _i.IsSuccess;
        public IEnumerable<string> Errors => (_a.Errors).Concat(_b.Errors).Concat(_c.Errors).Concat(_d.Errors).Concat(_e.Errors).Concat(_f.Errors).Concat(_g.Errors).Concat(_h.Errors).Concat(_i.Errors);

        public IResult Bind(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IResult> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h).Apply(_i);

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<IResult>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h).ApplyAsync(_i);

        public IResult<T10> Bind<T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, IResult<T10>> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h).Apply(_i);

        public Task<IResult<T10>> BindAsync<T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<IResult<T10>>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h).ApplyAsync(_i);

        public IResult<T10> Map<T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h).Apply(_i);

        public Task<IResult<T10>> MapAsync<T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<T10>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h).ApplyAsync(_i);

        public IResult Map(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h).Apply(_i);

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h).ApplyAsync(_i);
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e, IResult<T6> f, IResult<T7> g, IResult<T8> h, IResult<T9> i) =>
          new ResultComputation<T1, T2, T3, T4, T5, T6, T7, T8, T9>(a, b, c, d, e, f, g, h, i);
    }

    // ------------------------
    // 10 parameter functions.
    // ------------------------
    public class ResultComputation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IResult
    {
        private readonly IResult<T1> _a;
        private readonly IResult<T2> _b;
        private readonly IResult<T3> _c;
        private readonly IResult<T4> _d;
        private readonly IResult<T5> _e;
        private readonly IResult<T6> _f;
        private readonly IResult<T7> _g;
        private readonly IResult<T8> _h;
        private readonly IResult<T9> _i;
        private readonly IResult<T10> _j;

        internal ResultComputation(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e, IResult<T6> f, IResult<T7> g, IResult<T8> h, IResult<T9> i, IResult<T10> j)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _e = e;
            _f = f;
            _g = g;
            _h = h;
            _i = i;
            _j = j;
        }

        public bool IsSuccess => _a.IsSuccess && _b.IsSuccess && _c.IsSuccess && _d.IsSuccess && _e.IsSuccess && _f.IsSuccess && _g.IsSuccess && _h.IsSuccess && _i.IsSuccess && _j.IsSuccess;
        public IEnumerable<string> Errors => (_a.Errors).Concat(_b.Errors).Concat(_c.Errors).Concat(_d.Errors).Concat(_e.Errors).Concat(_f.Errors).Concat(_g.Errors).Concat(_h.Errors).Concat(_i.Errors).Concat(_j.Errors);

        public IResult Bind(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IResult> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h).Apply(_i).Apply(_j);

        public Task<IResult> BindAsync(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<IResult>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h).ApplyAsync(_i).ApplyAsync(_j);

        public IResult<T11> Bind<T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, IResult<T11>> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h).Apply(_i).Apply(_j);

        public Task<IResult<T11>> BindAsync<T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<IResult<T11>>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h).ApplyAsync(_i).ApplyAsync(_j);

        public IResult<T11> Map<T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h).Apply(_i).Apply(_j);

        public Task<IResult<T11>> MapAsync<T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<T11>> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h).ApplyAsync(_i).ApplyAsync(_j);

        public IResult Map(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> f) =>
          Lift(f).Apply(_a).Apply(_b).Apply(_c).Apply(_d).Apply(_e).Apply(_f).Apply(_g).Apply(_h).Apply(_i).Apply(_j);

        public Task<IResult> MapAsync(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task> f) =>
          LiftAsync(f).ApplyAsync(_a).ApplyAsync(_b).ApplyAsync(_c).ApplyAsync(_d).ApplyAsync(_e).ApplyAsync(_f).ApplyAsync(_g).ApplyAsync(_h).ApplyAsync(_i).ApplyAsync(_j);
    }

    public static partial class ResultComputation
    {
        public static ResultComputation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(IResult<T1> a, IResult<T2> b, IResult<T3> c, IResult<T4> d, IResult<T5> e, IResult<T6> f, IResult<T7> g, IResult<T8> h, IResult<T9> i, IResult<T10> j) =>
          new ResultComputation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(a, b, c, d, e, f, g, h, i, j);
    }
}