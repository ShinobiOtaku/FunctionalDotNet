using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet.Tests.Helpers
{
    /*
     * Ideas:
     *  - AsyncResult?
     *  - AsyncEnumerable
     *  - Testing helpers
     *  - options?
     *  - apply? Result<Func<T1, T2>> -> Func<T1, Result<T2>>
     *  - monadic vs applicative
     *  - Result<t1, t2>
     *  - from bool? Wrap().Handle()
     */

    public static class Calculator
    {
        public static int AddOne(int i) => ++i;
        public static async Task<int> AddOneAsync(int i) => AddOne(i);

        public static int Add(int a, int b) => a + b;
        public static async Task<int> AddAsync(int a, int b) => a + b;

        public static int Sum(IEnumerable<int> a) => a.Sum();
        public static async Task<int> SumAsync(IEnumerable<int> a) => Sum(a);

        public static void DoNothing(int i) { }
        public static async Task DoNothingAsync(int i) { }
        public static void DoNothing(int a, int b) { }
        public static async Task DoNothingAsync(int a, int b) { }
    }
}