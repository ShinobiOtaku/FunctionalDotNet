using System;
using System.Linq;
using CodegenCS;
using static CodeGen.Global;

namespace CodeGen
{
    class Program
    {
        static string alphabet = ".abcdefghijklmnopqrstuvwxyz";

        static string Repeat(int start, int count, Func<int, string> template, string delim = ", ")
        {
            var ts = Enumerable.Range(start, count).Select(template);
            return string.Join(delim, ts);
        }

        static string Items(int count) => Repeat(1, count, i => $"{alphabet[i]}.ItemOrDefault");
        static string TupleItems(int count) => count != 1 
            ? Repeat(1, count, i => $"x.Item{i}")
            : "x";

        static string Rts(int start, int count) => Repeat(start, count, i => $"rt{i}");
        static string Ts(int start, int count) => Repeat(start, count, i => $"T{i}");
        static string IResultT(int start, int count) => Repeat(start, count, i => $"IResult<T{i}>");
        static string IResultTParams(int count) => Repeat(1, count, i => $"IResult<T{i}> {alphabet[i]}");
        static string Letters(int count) => Repeat(1, count, i => $"{alphabet[i]}");
        static string LettersU(int count) => Repeat(1, count, i => $"_{alphabet[i]}");
        static string Fields(int count) => Repeat(1, count, i => $"private readonly IResult<T{i}> _{alphabet[i]};", Environment.NewLine);
        static string FieldsAssignment(int count) => Repeat(1, count, i => $"_{alphabet[i]} = {alphabet[i]};", Environment.NewLine);
        static string IsSuccess(int count) => Repeat(1, count, i => $"_{alphabet[i]}.IsSuccess", " && ");
        static string Errors(int count) => Repeat(1, count, i => $"_{alphabet[i]}.Errors", ").Concat(");
        static string Apply(int count) => Repeat(1, count, i => $".Apply(_{alphabet[i]})", "");
        static string ApplyAsync(int count) => Repeat(1, count, i => $".ApplyAsync(_{alphabet[i]})", "");

        static void Main(string[] args)
        {
            
        }

        private static void ResultComputation()
        {
            var w = new CodegenTextWriter();

            for (var i = 2; i <= Number; i++)
            {
                w.WriteLine($"// ------------------------");
                w.WriteLine($"// {i} parameter functions.");
                w.WriteLine($"// ------------------------");
                w.WriteLine($"public class ResultComputation<{Ts(1, i)}> : IResult");
                w.WriteLine($"{{");
                w.WriteLine(Fields(i));
                w.WriteLine();
                w.WriteLine($"internal ResultComputation({IResultTParams(i)})");
                w.WriteLine($"{{");
                w.WriteLine($"{FieldsAssignment(i)}");
                w.WriteLine($"}}");
                w.WriteLine();
                w.WriteLine($"public bool IsSuccess => {IsSuccess(i)};");
                w.WriteLine($"public IEnumerable<string> Errors => ({Errors(i)});");
                w.WriteLine();
                w.WriteLine($"public IResult Bind(Func<{Ts(1, i)}, IResult> f) =>");
                w.WriteLine($"{Tab}Lift(f){Apply(i)};");
                w.WriteLine();
                w.WriteLine($"public Task<IResult> BindAsync(Func<{Ts(1, i)}, Task<IResult>> f) =>");
                w.WriteLine($"{Tab}LiftAsync(f){ApplyAsync(i)};");
                w.WriteLine();
                w.WriteLine($"public IResult<T{i + 1}> Bind<T{i + 1}>(Func<{Ts(1, i)}, IResult<{Ts(i + 1, 1)}>> f) =>");
                w.WriteLine($"{Tab}Lift(f){Apply(i)};");
                w.WriteLine();
                w.WriteLine($"public Task<IResult<T{i + 1}>> BindAsync<T{i + 1}>(Func<{Ts(1, i)}, Task<IResult<T{i + 1}>>> f) =>");
                w.WriteLine($"{Tab}LiftAsync(f){ApplyAsync(i)};");
                w.WriteLine();
                w.WriteLine($"public IResult<T{i + 1}> Map<T{i + 1}>(Func<{Ts(1, i + 1)}> f) =>");
                w.WriteLine($"{Tab}Lift(f){Apply(i)};");
                w.WriteLine();
                w.WriteLine($"public Task<IResult<T{i + 1}>> MapAsync<T{i + 1}>(Func<{Ts(1, i)}, Task<T{i + 1}>> f) =>");
                w.WriteLine($"{Tab}LiftAsync(f){ApplyAsync(i)};");
                w.WriteLine();
                w.WriteLine($"public IResult Map(Action<{Ts(1, i)}> f) =>");
                w.WriteLine($"{Tab}Lift(f){Apply(i)};");
                w.WriteLine();
                w.WriteLine($"public Task<IResult> MapAsync(Func<{Ts(1, i)}, Task> f) =>");
                w.WriteLine($"{Tab}LiftAsync(f){ApplyAsync(i)};");
                w.WriteLine($"}}");
                w.WriteLine();
                w.WriteLine($"public static partial class ResultComputation");
                w.WriteLine($"{{");
                w.WriteLine($"public static ResultComputation<{Ts(1, i)}> Create<{Ts(1, i)}>({IResultTParams(i)}) =>");
                w.WriteLine($"{Tab}new ResultComputation<{Ts(1, i)}>({Letters(i)});");
                w.WriteLine($"}}");
                w.WriteLine();
            }

            w.SaveToFile("ResultComputation.cs");
        }

        private static void Lift()
        {
            var w = new CodegenTextWriter();

            w.WriteLine($"// ------------------------");
            w.WriteLine($"// Mergers.");
            w.WriteLine($"// ------------------------");

            for (var i = 1; i < Number + 1; i++)
            {
                //private static IResult<(T1, T2)> Merge<T1, T2>(
                //  IResult<T1> fst, IResult<T2> snd) =>
                //  Sequence(fst, snd).Map(() => (fst.ItemOrDefault, snd.ItemOrDefault));
                if (i == 1)
                    w.WriteLine($"private static IResult<{Ts(1, i)}> Merge<{Ts(1, i)}>(");
                else
                    w.WriteLine($"private static IResult<({Ts(1, i)})> Merge<{Ts(1, i)}>(");

                w.WriteLine($"{Tab}{IResultTParams(i)}) =>");
                w.WriteLine($"{Tab}Sequence({Letters(i)}).Map(() => ({Items(i)}));");
                w.WriteLine();
            }

            w.WriteLine($"// ------------------------");
            w.WriteLine($"// Lift Bind");
            w.WriteLine($"// ------------------------");
            w.WriteLine();

            for (var i = 1; i < Number + 1; i++)
            {
                w.WriteLine($"// ------------------------");
                w.WriteLine($"// {i} parameter functions.");
                w.WriteLine($"// ------------------------");

                //public static Func<IResult<T1>, IResult<T2>, IResult> Lift<T1, T2>(
                //  Func<T1, T2, IResult> func) => 
                //    (rt1, rt2) => Binder(Merge(rt1, rt2), x => func(x.Item1, x.Item2));
                w.WriteLine($"/// Lifts a function into a function that inputs and outputs results.");
                w.WriteLine($"public static Func<{IResultT(1, i)}, IResult> Lift<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}Func<{Ts(1, i)}, IResult> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i)}) => Binder(Merge({Rts(1, i)}), x => f({TupleItems(i)}));");
                w.WriteLine();

                //public static Func<IResult<T1>, IResult<T2>, IResult<T3>> Lift<T1, T2, T3>(
                //  Func<T1, T2, IResult<T3>> func) => 
                //    (rt1, rt2) => Binder(Merge(rt1, rt2), x => func(x.Item1, x.Item2));
                w.WriteLine($"/// Lifts a function into a function that inputs and outputs results.");
                w.WriteLine($"public static Func<{IResultT(1, i + 1)}> Lift<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}Func<{Ts(1, i)}, {IResultT(i + 1, 1)}> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i)}) => Binder(Merge({Rts(1, i)}), x => f({TupleItems(i)}));");
                w.WriteLine();

                //public static Func<IResult<T1>, IResult<T2>, Task<IResult>> LiftAsync<T1, T2>(
                //  Func<T1, T2, Task<IResult>> func) => 
                //    (rt1, rt2) => Binder(Merge(rt1, rt2), x => func(x.Item1, x.Item2));
                w.WriteLine($"/// Lifts a function into a function that inputs and outputs results.");
                w.WriteLine($"public static Func<{IResultT(1, i)}, Task<IResult>> LiftAsync<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}Func<{Ts(1, i)}, Task<IResult>> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i)}) => BinderAsync(Merge({Rts(1, i)}), x => f({TupleItems(i)}));");
                w.WriteLine();

                //public static Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> Lift<T1, T2, T3>(
                //  Func<T1, T2, Task<IResult<T3>>>> func) => 
                //    (rt1, rt2) => Binder(Merge(rt1, rt2), x => func(x.Item1, x.Item2));
                w.WriteLine($"/// Lifts a function into a function that inputs and outputs results.");
                w.WriteLine($"public static Func<{IResultT(1, i)}, Task<{IResultT(i + 1, 1)}>> LiftAsync<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}Func<{Ts(1, i)}, Task<{IResultT(i + 1, 1)}>> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i)}) => BinderAsync(Merge({Rts(1, i)}), x => f({TupleItems(i)}));");
                w.WriteLine();
            }

            w.WriteLine($"// ------------------------");
            w.WriteLine($"// Lift Map");
            w.WriteLine($"// ------------------------");
            w.WriteLine();

            for (var i = 1; i < Number + 1; i++)
            {
                w.WriteLine($"// ------------------------");
                w.WriteLine($"// {i} parameter functions.");
                w.WriteLine($"// ------------------------");

                //public static Func<IResult<T1>, IResult> Lift<T1>(
                //  Action<T1> f) =>
                //  (rt1) => Binder(Merge(rt1), x => { f(x); return Success(); });
                w.WriteLine($"/// Lifts a function into a function that inputs and outputs results.");
                w.WriteLine($"public static Func<{IResultT(1, i)}, IResult> Lift<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}Action<{Ts(1, i)}> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i)}) => Binder(Merge({Rts(1, i)}), x => {{ f({TupleItems(i)}); return Success(); }});");
                w.WriteLine();

                //public static Func<IResult<T1>, IResult<T2>> Lift<T1, T2>(
                //  Func<T1, T2> f) => 
                //  rt1 => Binder(Merge(rt1), x => Success(f(x)));
                w.WriteLine($"/// Lifts a function into a function that inputs and outputs results.");
                w.WriteLine($"public static Func<{IResultT(1, i + 1)}> Lift<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}Func<{Ts(1, i + 1)}> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i)}) => Binder(Merge({Rts(1, i)}), x => Success(f({TupleItems(i)})));");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult>> LiftAsync<T1>(
                //  Func<T1, Task> f) =>
                //  (rt1) => BinderAsync(Merge(rt1), async x => { await f(x); return Success(); });
                w.WriteLine($"/// Lifts an async function into a function that inputs and outputs results.");
                w.WriteLine($"public static Func<{IResultT(1, i)}, Task<IResult>> LiftAsync<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}Func<{Ts(1, i)}, Task> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i)}) => BinderAsync(Merge({Rts(1, i)}), async x => {{ await f({TupleItems(i)}); return Success(); }});");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult<T2>>> LiftAsync<T1, T2>(
                //  Func<T1, T2> f) => 
                //  rt1 => Binder(Merge(rt1), x => Success(f(x)));
                w.WriteLine($"/// Lifts a function into a function that inputs and outputs results.");
                w.WriteLine($"public static Func<{IResultT(1, i)}, Task<{IResultT(i + 1, 1)}>> LiftAsync<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}Func<{Ts(1, i)}, Task<T{i + 1}>> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i)}) => BinderAsync(Merge({Rts(1, i)}), async x => Success(await f({TupleItems(i)})));");
                w.WriteLine();
            }

            w.SaveToFile("Lift.cs");
        }

        private static void Map()
        {
            var w = new CodegenTextWriter();

            for (var i = 2; i <= Number + 1; i++)
            {
                w.WriteLine($"// ------------------------");
                w.WriteLine($"// {i - 1} parameter functions.");
                w.WriteLine($"// ------------------------");

                //public static Func<IResult<T1>, IResult> Map<T1, T2>(
                //  this Func<IResult<T1>, IResult<T2>> source, Func<T2, IResult> f) =>
                //  rt1 => source(rt1).Map(f);
                w.WriteLine($"/// Chains the previous function to another function using Map.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, IResult> Map<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}> source, Action<T{i}> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).Map(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, IResult<T3>> Map<T1, T2, T3>(
                //  this Func<IResult<T1>, IResult<T2>> source, Func<T2, IResult<T3>> f) =>
                //  rt1 => source(rt1).Map(f);
                w.WriteLine($"/// Chains the previous function to another function using Map.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, {IResultT(i + 1, 1)}> Map<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}> source, Func<T{i}, T{i + 1}> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).Map(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
                //  this Func<IResult<T1>, IResult<T2>> source, Func<T2, Task<IResult>> f) =>
                //  rt1 => source(rt1).MapAsync(f);
                w.WriteLine($"/// Chains the previous function to an async function using Map.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, Task<IResult>> MapAsync<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}> source, Func<T{i}, Task> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).MapAsync(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult<T3>>> MapAsync<T1, T2, T3>(
                //  this Func<IResult<T1>, IResult<T2>> source, Func<T2, Task<IResult<T3>>> f) =>
                //  rt1 => source(rt1).MapAsync(f);
                w.WriteLine($"/// Chains the previous function to an async function using Map.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, Task<{IResultT(i + 1, 1)}>> MapAsync<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}> source, Func<T{i}, Task<T{i + 1}>> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).MapAsync(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
                //  this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, IResult> f) =>
                //  rt1 => source(rt1).MapAsync(f);
                w.WriteLine($"/// Chains the previous async function to another async function using Map.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, Task<{IResultT(i + 1, 1)}>> MapAsync<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i - 1)}, Task<{IResultT(i, 1)}>> source, Func<T{i}, Task<T{i + 1}>> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).MapAsync(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
                //  this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, IResult> f) =>
                //  rt1 => source(rt1).MapAsync(f);
                w.WriteLine($"/// Chains the previous async function to another async function using Map.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, Task<IResult>> MapAsync<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i - 1)}, Task<{IResultT(i, 1)}>> source, Func<T{i}, Task> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).MapAsync(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
                //  this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, IResult> f) =>
                //  rt1 => source(rt1).MapAsync(f);
                w.WriteLine($"/// Chains the previous async function to another function using Map.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, Task<{IResultT(i + 1, 1)}>> MapAsync<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i - 1)}, Task<{IResultT(i, 1)}>> source, Func<T{i}, T{i + 1}> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).MapAsync(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult>> MapAsync<T1, T2>(
                //  this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, IResult> f) =>
                //  rt1 => source(rt1).MapAsync(f);
                w.WriteLine($"/// Chains the previous async function to another function using Map.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, Task<IResult>> MapAsync<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i - 1)}, Task<{IResultT(i, 1)}>> source, Action<T{i}> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).MapAsync(f);");
                w.WriteLine();
            }

            w.SaveToFile("Map.cs");
        }

        private static void Bind()
        {
            var w = new CodegenTextWriter();

            for (var i = 2; i <= Number + 1; i++)
            {
                w.WriteLine($"// ------------------------");
                w.WriteLine($"// {i - 1} parameter functions.");
                w.WriteLine($"// ------------------------");

                //public static Func<IResult<T1>, IResult> Bind<T1, T2>(
                //  this Func<IResult<T1>, IResult<T2>> source, Func<T2, IResult> f) =>
                //  rt1 => source(rt1).Bind(f);
                w.WriteLine($"/// Chains the previous function to another function using Bind.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, IResult> Bind<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}> source, Func<T{i}, IResult> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).Bind(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, IResult<T3>> Bind<T1, T2, T3>(
                //  this Func<IResult<T1>, IResult<T2>> source, Func<T2, IResult<T3>> f) =>
                //  rt1 => source(rt1).Bind(f);
                w.WriteLine($"/// Chains the previous function to another function using Bind.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, {IResultT(i + 1, 1)}> Bind<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}> source, Func<T{i}, {IResultT(i + 1, 1)}> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).Bind(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult>> BindAsync<T1, T2>(
                //  this Func<IResult<T1>, IResult<T2>> source, Func<T2, Task<IResult>> f) =>
                //  rt1 => source(rt1).BindAsync(f);
                w.WriteLine($"/// Chains the previous function to an async function using Bind.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, Task<IResult>> BindAsync<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}> source, Func<T{i}, Task<IResult>> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).BindAsync(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult<T3>>> BindAsync<T1, T2, T3>(
                //  this Func<IResult<T1>, IResult<T2>> source, Func<T2, Task<IResult<T3>>> f) =>
                //  rt1 => source(rt1).BindAsync(f);
                w.WriteLine($"/// Chains the previous function to an async function using Bind.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, Task<{IResultT(i + 1, 1)}>> BindAsync<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}> source, Func<T{i}, Task<{IResultT(i + 1, 1)}>> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).BindAsync(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult>> BindAsync<T1, T2>(
                //  this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, IResult> f) =>
                //  rt1 => source(rt1).BindAsync(f);
                w.WriteLine($"/// Chains the previous async function to another function using Bind.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, Task<{IResultT(i + 1, 1)}>> BindAsync<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i - 1)}, Task<{IResultT(i, 1)}>> source, Func<T{i}, Task<{IResultT(i + 1, 1)}>> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).BindAsync(f);");
                w.WriteLine();

                //public static Func<IResult<T1>, Task<IResult>> BindAsync<T1, T2>(
                //  this Func<IResult<T1>, Task<IResult<T2>>> source, Func<T2, IResult> f) =>
                //  rt1 => source(rt1).BindAsync(f);
                w.WriteLine($"/// Chains the previous async function to another function using Bind.");
                w.WriteLine($"public static Func<{IResultT(1, i - 1)}, Task<IResult>> BindAsync<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i - 1)}, Task<{IResultT(i, 1)}>> source, Func<T{i}, Task<IResult>> f) =>");
                w.WriteLine($"{Tab}({Rts(1, i - 1)}) => source({Rts(1, i - 1)}).BindAsync(f);");
                w.WriteLine();

            }

            w.SaveToFile("Bind.cs");
        }

        private static void Apply()
        {
            var w = new CodegenTextWriter();

            for (var i = 2; i <= Number; i++)
            {
                w.WriteLine($"// ------------------------");
                w.WriteLine($"// {i} parameter functions.");
                w.WriteLine($"// ------------------------");

                //public static Func<IResult<T2>, IResult> Apply<T1, T2>(
                //  this Func<IResult<T1>, IResult<T2>, IResult> source, T1 rt1) =>
                //  rt2 => source(Success(rt1), rt2);
                w.WriteLine($"/// Apply the first value to a {i} parameter function.");
                w.WriteLine($"public static Func<{IResultT(2, i - 1)}, IResult> Apply<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}, IResult> source, T1 rt1) =>");
                w.WriteLine($"{Tab}({Rts(2, i - 1)}) => source(Success(rt1), {Rts(2, i - 1)});");
                w.WriteLine();

                //public static Func<IResult<T2>, IResult<T3>> Apply<T1, T2, T3>(
                //  this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, T1 rt1) =>
                //  rt2 => source(Success(rt1), rt2);
                w.WriteLine($"/// Apply the first value to a {i} parameter function.");
                w.WriteLine($"public static Func<{IResultT(2, i)}> Apply<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i + 1)}> source, T1 rt1) =>");
                w.WriteLine($"{Tab}({Rts(2, i - 1)}) => source(Success(rt1), {Rts(2, i - 1)});");
                w.WriteLine();

                //public static Func<IResult<T2>, IResult> Apply<T1, T2>(
                //  this Func<IResult<T1>, IResult<T2>, IResult> source, IResult<T1> rt1) =>
                //  rt2 => source(rt1, rt2);
                w.WriteLine($"/// Apply the first value to a {i} parameter function.");
                w.WriteLine($"public static Func<{IResultT(2, i - 1)}, IResult> Apply<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}, IResult> source, IResult<T1> rt1) =>");
                w.WriteLine($"{Tab}({Rts(2, i - 1)}) => source({Rts(1, i)});");
                w.WriteLine();

                //public static Func<IResult<T2>, IResult<T3>> Apply<T1, T2, T3>(
                //  this Func<IResult<T1>, IResult<T2>, IResult<T3>> source, IResult<T1> rt1) =>
                //  (rt2) => source(rt1, rt2);
                w.WriteLine($"/// Apply the first value to a {i} parameter function.");
                w.WriteLine($"public static Func<{IResultT(2, i)}> Apply<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i + 1)}> source, IResult<T1> rt1) =>");
                w.WriteLine($"{Tab}({Rts(2, i - 1)}) => source({Rts(1, i)});");
                w.WriteLine();

                //public static Func<IResult<T2>, Task<IResult>> ApplyAsync<T1, T2>(
                //  this Func<IResult<T1>, IResult<T2>, Task<IResult>> source, T1 rt1) =>
                //  rt2 => source(Success(rt1), rt2);
                w.WriteLine($"/// Apply the first value to a {i} parameter async function.");
                w.WriteLine($"public static Func<{IResultT(2, i - 1)}, Task<IResult>> ApplyAsync<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}, Task<IResult>> source, T1 rt1) =>");
                w.WriteLine($"{Tab}({Rts(2, i - 1)}) => source(Success(rt1), {Rts(2, i - 1)});");
                w.WriteLine();

                //public static Func<IResult<T2>, Task<IResult<T3>>> ApplyAsync<T1, T2, T3>(
                //  this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, T1 rt1) =>
                //  rt2 => source(Success(rt1), rt2);
                w.WriteLine($"/// Apply the first value to a {i} parameter function.");
                w.WriteLine($"public static Func<{IResultT(2, i - 1)}, Task<{IResultT(i + 1, 1)}>> ApplyAsync<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}, Task<{IResultT(i + 1, 1)}>> source, T1 rt1) =>");
                w.WriteLine($"{Tab}({Rts(2, i - 1)}) => source(Success(rt1), {Rts(2, i - 1)});");
                w.WriteLine();

                //public static Func<IResult<T2>, Task<IResult>> ApplyAsync<T1, T2>(
                //  this Func<IResult<T1>, IResult<T2>, Task<IResult>> source, IResult<T1> rt1) =>
                //  rt2 => source(rt1, rt2);
                w.WriteLine($"/// Apply the first value to a {i} parameter async function.");
                w.WriteLine($"public static Func<{IResultT(2, i - 1)}, Task<IResult>> ApplyAsync<{Ts(1, i)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}, Task<IResult>> source, IResult<T1> rt1) =>");
                w.WriteLine($"{Tab}({Rts(2, i - 1)}) => source(rt1, {Rts(2, i - 1)});");
                w.WriteLine();

                //public static Func<IResult<T2>, Task<IResult<T3>>> ApplyAsync<T1, T2, T3>(
                //  this Func<IResult<T1>, IResult<T2>, Task<IResult<T3>>> source, IResult<T1> rt1) =>
                //  rt2 => source(rt1, rt2);
                w.WriteLine($"/// Apply the first value to a {i} parameter function.");
                w.WriteLine($"public static Func<{IResultT(2, i - 1)}, Task<{IResultT(i + 1, 1)}>> ApplyAsync<{Ts(1, i + 1)}>(");
                w.WriteLine($"{Tab}this Func<{IResultT(1, i)}, Task<{IResultT(i + 1, 1)}>> source, IResult<T1> rt1) =>");
                w.WriteLine($"{Tab}({Rts(2, i - 1)}) => source(rt1, {Rts(2, i - 1)});");
                w.WriteLine();
            }

            w.SaveToFile("Apply.cs");
        }
    }
}
