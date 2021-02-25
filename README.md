Functional Classes and Extensions for C#
======================================================
[![Nuget downloads](https://img.shields.io/nuget/v/FunctionalDotNet.svg)](https://www.nuget.org/packages/FunctionalDotNet/)
[![GitHub license](https://img.shields.io/github/license/thelegendofando/FunctionalDotNet)](https://github.com/thelegendofando/FunctionalDotNet/blob/main/LICENSE)

Inspired by FSharp and [Railway Oriented Programming](https://fsharpforfunandprofit.com/rop/).

## Installation

Available on [nuget](https://www.nuget.org/packages/FunctionalDotNet/)

	PM> Install-Package FunctionalDotNet

## Result

### Usage

Creating Results

```csharp
// Success - captures a value.
Result.Success("1")

// Success - indicates a success, but no value to capture.
Result.Success()

// Failure - captures the reason(s) for failure
Result.Failure<int>("It went wrong!")

Result.Failure("It went so wrong", "really wrong", "no seriously, so bad!")
```

Chaining functions

```csharp
var value = Result.Success(1);

IResult<int> four = value
    .Map(Calculator.AddOne)
    .Map(Calculator.Square);

four.Bind(i => CsvFile.TryWriteLine($"The answer is: {i}"));
```

Chaining async functions

```csharp
var value = Result.Success(1);

IResult<int> four = await value
    .Map(Calculator.AddOne)
    .MapAsync(Calculator.SquareAsync);

await four.BindAsync(i => CsvFile.TryWriteLineAsync($"The answer is: {i}"));
```

Combining results

```csharp
var value1 = Result.Success(1);
var value2 = Result.Success(2);

IResult<int> three = Result
    .Combine(value1, value2)
    .Map((one, two) => Calculator.Add(one, two));
```

Sequencing results

```csharp
var numbersToDivide = new [] {2, 1, 0};

IEnumerable<IResult<int>> results =
    numbersToDivide.Select(i => Calculator.TryDivide(10, i));

IResult<IEnumerable<int>> combined = results.Sequence();
```