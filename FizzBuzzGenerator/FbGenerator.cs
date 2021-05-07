using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace FizzBuzzGenerator
{
    public static class FbGenerator
    {
        public static List<FbResponse> Generate(FbArgs args)
        {
            if (args == null)
            {
                throw new ArgumentException("FizzBuzzArgs cannot be null", nameof(args));
            }

            if (args.Options == null)
            {
                throw new ArgumentException("FizzBuzzArgs Options cannot be null", nameof(args.Options));
            }

            if (args.Max < args.Min)
            {
                throw new ArgumentException("FizzBuzzArgs Max must be greater than or equal to Min");
            }

            return Enumerable.Range(args.Min, args.Max - args.Min + 1)
                .Select(i => GetOutput((Int16) i, args.Options)).ToList();
        }

        private static FbResponse GetOutput(int i, List<FbOption> options)
        {
            var fizzBuzz = new StringBuilder();

            foreach (var option in options.Distinct())
            {
                if (i.IsDivisibleBy(option.Divisor))
                {
                    fizzBuzz.Append(option.Output ?? "N/A");
                }
            }

            return new FbResponse(i, fizzBuzz.ToString());
        }
    }

    public record FbResponse(int Index, string Output);

    public record FbOption(int Divisor, string Output);

    public record FbArgs(int Min, int Max, List<FbOption> Options);
}