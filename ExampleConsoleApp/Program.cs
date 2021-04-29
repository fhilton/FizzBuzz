using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzzGenerator;

namespace ExampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = FbGenerator.Generate(new FbArgs(1, 100,
                new List<FbOption>()
                {
                    new(3, "Fizz"),
                    new(5, "Buzz")
                }));

            foreach (var fizzBuzzResponse in results)
            {
                Console.WriteLine(
                    $"{fizzBuzzResponse.Index}: {fizzBuzzResponse.Output}");
            }
        }
    }
}