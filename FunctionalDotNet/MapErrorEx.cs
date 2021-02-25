using System;
using System.Linq;
using static FunctionalDotNet.Result;

namespace FunctionalDotNet
{
    public static class MapErrorEx
    {
        public static IResult MapError(this IResult source, Func<string, string> f) => 
            source.IsSuccess ? Success() : Failure(source.Errors.Select(f));
        
        public static IResult<T> MapError<T>(this IResult<T> source, Func<string, string> f) => 
            source.IsSuccess ? Success(source.ItemOrDefault) : Failure<T>(source.Errors.Select(f));
    }
}