Functional Classes and Extensions for C#
======================================================
[![Nuget downloads](https://img.shields.io/nuget/v/FunctionalDotNet.svg)](https://www.nuget.org/packages/FunctionalDotNet/)
[![GitHub license](https://img.shields.io/github/license/thelegendofando/FunctionalDotNet)](https://github.com/thelegendofando/FunctionalDotNet/blob/main/LICENSE)

Inspired by FSharp and [Railway Oriented Programming](https://fsharpforfunandprofit.com/rop/).

## Installation

Available on [nuget](https://www.nuget.org/packages/FunctionalDotNet/)

	PM> Install-Package FunctionalDotNet

## Getting Started - Using results

### Creating Results

```csharp
// Success - captures a value.
Result.Success("hello")

// Success - indicates a success, but no value to capture.
Result.Success()

// Failure - captures the reason(s) for failure
Result.Failure<int>("It went wrong!")

Result.Failure("It went so wrong", "really wrong", "no seriously, so bad!")
```

### Combine

Combines two or more `Result`, useful for chaining into functions that require multiple parameters (see further down).

```csharp
var value1 = Result.Success(1);
var value2 = Result.Success(2);

IResult combined = Result.Combine(value1, value2);
```

note: combined here has no value, because at this stage you haven't actually done anything with it. The values 1 and 2 are just stored for later use.

If you want the values out, you can map them. See Result Computations further down for more.

```csharp
IResult<int> three = combined.Map((one, two) => one + two);
```

### Sequence

Reduces a collection of `Result`s into a `Result` of a collection

```csharp
var numbersToDivide = new [] {2, 1, 0};

IEnumerable<IResult<int>> results =
    numbersToDivide.Select(i => Calculator.TryDivide(10, i));

IResult<IEnumerable<int>> combined = results.Sequence();
```

## Getting Started - Chaining functions

### Chaining functions with Map & Apply

If the functions do not return `Result` use `Map(next_function)`.

```csharp
var value = Result.Success(1);

IResult<int> four = value
    .Map(Calculator.AddOne)
    .Map(Calculator.Square);

four.Map(i => CsvFile.WriteLine($"The answer is: {i}"));
```

If the functions do return `Result` use `Bind(next_function)`.

```csharp
var value = Result.Success(1);

IResult<int> four = value
    .Bind(SafeCalculator.AddOne)
    .Bind(SafeCalculator.Square);

four.Bind(i => CsvFile.TryWriteLine($"The answer is: {i}"));
```

### Chaining async functions

```csharp
var value = Result.Success(1);

IResult<int> four = await value
    .Map(Calculator.AddOne)
    .MapAsync(Calculator.SquareAsync);

await four.BindAsync(i => CsvFile.TryWriteLineAsync($"The answer is: {i}"));
```

### Result computations

Combining results will return a result computation, which allows you to chain it.

```csharp
var value1 = Result.Success(1);
var value2 = Result.Success(2);

IResult<int> three = Result
    .Combine(value1, value2)
    .Map((one, two) => Calculator.Add(one, two));
```

## Advanced chaining

Everything you've seen up until this point starts with a `Result`, but what if we don't have a `Result` yet.

We can `Lift`, `Bind` and `Map` functions directly, and then `Apply` a `Result` once we have one.

### Lift

Turns a normal function into one that accepts and returns `Result`s, allowing you to map etc.

* note: you must specify the types the function takes and returns. *

```csharp
var readIntFromS3 = Result
    .Lift<string, object>(S3Bucket.GetObject)
    .Map(Convert.ToInt32);

IResult<int> result1 = readIntFromS3(Result.Success("key1"));
```

Or

```csharp
var readIntFromS3 = Result
    .Lift((string key) =>  S3Bucket.GetObject(key))
    .Map(Convert.ToInt32);
```

### Apply

Applies a single value to a lifted function, returning a new function with fewer parameters.

```csharp
var divideByTwo = Result
    .Lift((int a, int b) => Calculator.TryDivide(a, b))
    .Apply(2);

IResult<int> five = divideByTwo(Result.Success(10));
```

### Capturing extra parameters

If a function in your chain requires more than one value, you can capture them.

```csharp
// A function which takes 2 parameters
var addOneDivideByX = Result
    .Lift((int a) => Calculator.AddOne(a))
    .Map((int resultOfPrevious, int x) => Calculator.TryDivide(resultOfPrevious, x));// x is captured

// partially apply the function, returning a new function which takes just one parameter.
var divideTenByX = addOneDivideByX.Apply(10);
```

## Beyond the basics

See the `FunctionalDotNet.Examples` project for more examples.