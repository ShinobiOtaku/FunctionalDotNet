Functional Classes and Extensions for C#
======================================================
[![Nuget downloads](https://img.shields.io/nuget/v/FunctionalDotNet.svg)](https://www.nuget.org/packages/FunctionalDotNet/)
[![GitHub license](https://img.shields.io/github/license/thelegendofando/FunctionalDotNet)](https://github.com/thelegendofando/FunctionalDotNet/blob/main/LICENSE)

Inspired by FSharp and [Railway Oriented Programming](https://fsharpforfunandprofit.com/rop/).

## Installation

Available on [nuget](https://www.nuget.org/packages/FunctionalDotNet/)

	PM> Install-Package FunctionalDotNet

## Getting Started

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

### Chaining functions with Map

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

### Chaining async functions with Bind

```csharp
var value = Result.Success(1);

IResult<int> four = await value
    .Map(Calculator.AddOne)
    .MapAsync(Calculator.SquareAsync);

await four.BindAsync(i => CsvFile.TryWriteLineAsync($"The answer is: {i}"));
```

### Combine

Combines two or more `Result` in order to chain them, useful for functions that require multiple parameters.

```csharp
var value1 = Result.Success(1);
var value2 = Result.Success(2);

IResult<int> three = Result
    .Combine(value1, value2)
    .Map((one, two) => Calculator.Add(one, two));
```

### Sequence

Reduces a collection of `Result`s into a `Result` of a collection

```csharp
var numbersToDivide = new [] {2, 1, 0};

IEnumerable<IResult<int>> results =
    numbersToDivide.Select(i => Calculator.TryDivide(10, i));

IResult<IEnumerable<int>> combined = results.Sequence();
```

### Lift

Turns a normal function into one that accepts and returns `Result`s, allowing you to map etc.

```csharp
var readIntFromS3 = Result
    .Lift<string, object>(S3Bucket.GetObject)
    .Map(Convert.ToInt32);

IResult<int> result1 = readIntFromS3(Result.Success("key1"));
```

### Apply

Applies a single value to the function, returning a new function with one less parameter.

```csharp
var divideByTwo = Result
    .Lift<int, int, int>(Calculator.TryDivide)
    .Apply(2);

IResult<int> five = divideByTwo(Result.Success(10));
```