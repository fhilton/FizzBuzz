# Fizz Buzz

![Build Status](https://github.com/fhilton/FizzBuzz/actions/workflows/dotnet.yml/badge.svg)

## Overview 

Fizz buzz Is a [children's game to teach division](https://en.wikipedia.org/wiki/Fizz_buzz).

Fizz buzz is also used as a [programming test](https://blog.codinghorror.com/why-cant-programmers-program/).

This repository contains an example Fizz Buzz implementation in C#.

## Usage

  Call FbGenerator.Generate with a range of numbers and a list of divisors and their resulting outputs.

``` csharp
  var results = FbGenerator.Generate(new FbArgs(1, 100,
      new List<FbOption>()
      {
          new(3, "Fizz"),
          new(5, "Buzz")
      }));

  foreach (var fizzBuzzResponse in results)
  {
      Console.WriteLine(
          $"{fizzBuzzResponse.Index}: {fizzBuzzResponse.FizzBuzz}");
  }
```
  See [ExampleConsoleApp/Program.cs]('./ExampleConsoleApp/Program.cs)) for an example.


## Running Tests

Run the command "dotnet test" in the repository root.