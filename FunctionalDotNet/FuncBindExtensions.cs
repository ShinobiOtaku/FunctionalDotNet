using System;
using System.Threading.Tasks;

namespace FunctionalDotNet
{
    public static class FuncBindExtensions
    {
        //TODO more params
        public static Func<IResult<T1>, IResult<T3>> Bind<T1, T2, T3>(this Func<IResult<T1>, IResult<T2>> source, Func<T2, IResult<T3>> f) =>
            rt1 => source(rt1).Bind(f);

        public static Func<IResult<T1>, IResult<T2>, IResult<T4>> Bind<T1, T2, T3, T4>(this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, Func<T3, IResult<T4>> f) =>
            (rt1, rt2) => source(rt1, rt2).Bind(f);
    }

    public static class AsyncFuncBindExtensions
    {
        //TODO more params
        public static Func<IResult<T1>, Task<IResult<T3>>> BindAsync<T1, T2, T3>(this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, Task<IResult<T3>>> f) =>
            rt1 => source(rt1).BindAsync(f);

        public static Func<IResult<T1>, Task<IResult>> BindAsync<T1, T2>(this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, Task<IResult>> f) =>
            rt1 => source(rt1).BindAsync(f);

        public static Func<IResult<T1>, IResult<T3>, Task<IResult>> BindAsync<T1, T2, T3>(this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, T3, Task<IResult>> f) =>
            (rt1, rt2) => source(rt1).BindAsync(x => Result.LiftAsync(f).ApplyAsync(x).ApplyAsync(rt2));

        public static Func<IResult<T1>, IResult<T2>, Task<IResult<T4>>> BindAsync<T1, T2, T3, T4>(this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, Func<T3, Task<IResult<T4>>> f) =>
            (rt1, rt2) => source(rt1, rt2).BindAsync(f);
    }
}