using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalDotNet.Examples
{
    public static class Calculator
    {
        public static IResult<int> TryDivide(int a, int b) => Result.Success(a/b);

        public static int Add(int a, int b) => a + b;
        public static int AddOne(int a) => a + 1;
        public static int Square(int a) => a * a;
        public static async Task<int> SquareAsync(int a) => a * a;
    }
    
    public static class CsvFile
    {
        public static IResult<string> TryReadLine() => Result.Success("1");
        public static IResult TryWriteLine(string line) => Result.Success();
        public static async Task<IResult> TryWriteLineAsync(string line) => Result.Success();
    }

    public static class S3Bucket
    {
        public static object GetObject(string key) => "1";
        public static string PutObject(string key, object contents) => "1";
    }

    public class FileContentsReporter
    {
        public static void Report()
        {
            var value = Result.Success(1);

            IResult<int> four = value
                .Map(Calculator.AddOne)
                .Map(Calculator.Square);

            four.Bind(i => CsvFile.TryWriteLine($"The answer is: {i}"));
        }

        public static async Task ReportAsync()
        {
            var value = Result.Success(1);

            IResult<int> four = await value
                .Map(Calculator.AddOne)
                .MapAsync(Calculator.SquareAsync);

            await four.BindAsync(i => CsvFile.TryWriteLineAsync($"The answer is: {i}"));
        }

        public static void Combine()
        {
            var value1 = Result.Success(1);
            var value2 = Result.Success(2);

            IResult<int> three = Result
                .Combine(value1, value2)
                .Map((one, two) => Calculator.Add(one, two));
        }

        public static void Sequence()
        {
            var numbersToDivide = new [] {2, 1, 0};

            IEnumerable<IResult<int>> results =
                numbersToDivide.Select(i => Calculator.TryDivide(10, i));

            IResult<IEnumerable<int>> combined = results.Sequence();
        }

        public static void Lift()
        {
            var readIntFromS3 = Result
                .Lift<string, object>(S3Bucket.GetObject)
                .Map(Convert.ToInt32);

            IResult<int> result1 = readIntFromS3(Result.Success("key1"));
        }

        public static void Apply()
        {
            var divideByTwo = Result
                .Lift<int, int, int>(Calculator.TryDivide)
                .Apply(2);

            IResult<int> five = divideByTwo(Result.Success(10));
        }
    }
}
