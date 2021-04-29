using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using JetBrains.dotMemoryUnit;
using Xunit;
using Xunit.Abstractions;

namespace FizzBuzzGenerator.Tests.Unit
{
    public class FizzBuzzGeneratorTests
    {
        [Fact]
        public void Allows_Min_Max_Input()
        {
            var results = FbGenerator.Generate(new FbArgs(0, Int16.MaxValue, new List<FbOption>()
            {
                new(3, "Fizz"),
                new(5, "Buzz")
            }));

            Assert.NotEmpty(results);

            Assert.Equal(Int16.MaxValue + 1, results.Count);
        }

        [Fact]
        public void Allows_0_Input()
        {
            var results = FbGenerator.Generate(new FbArgs(0, 0, new List<FbOption>()
            {
                new(3, "Fizz"),
                new(5, "Buzz")
            }));

            Assert.Equal("FizzBuzz", results.Where(r => r.Index == 0).First().Output);
        }

        [Fact]
        public void Allows_Single_Input()
        {
            var results = FbGenerator.Generate(new FbArgs(15, 15, new List<FbOption>()
            {
                new(3, "Fizz"),
                new(5, "Buzz")
            }));

            Assert.Single(results);

            Assert.Equal("FizzBuzz", results.Where(r => r.Index == 15).First().Output);
        }

        [Fact]
        public void Works_For_Input_3_And_5()
        {
            var results = FbGenerator.Generate(new FbArgs(1, 20, new List<FbOption>()
            {
                new(3, "Fizz"),
                new(5, "Buzz")
            }));

            Assert.NotEmpty(results);

            Assert.Equal("Fizz", results.Where(r => r.Index == 3).First().Output);
            Assert.Equal("Buzz", results.Where(r => r.Index == 5).First().Output);
            Assert.Equal("FizzBuzz", results.Where(r => r.Index == 15).First().Output);
        }

        [Fact]
        public void Works_For_Input_2_3_And_5()
        {
            var results = FbGenerator.Generate(new FbArgs(1, 20, new List<FbOption>()
            {
                new(2, "Pfft"),
                new(3, "Fizz"),
                new(5, "Buzz")
            }));

            Assert.NotEmpty(results);

            Assert.Equal("Fizz", results.Where(r => r.Index == 3).First().Output);
            Assert.Equal("Buzz", results.Where(r => r.Index == 5).First().Output);
            Assert.Equal("PfftFizz", results.Where(r => r.Index == 6).First().Output);
            Assert.Equal("PfftBuzz", results.Where(r => r.Index == 10).First().Output);
            Assert.Equal("FizzBuzz", results.Where(r => r.Index == 15).First().Output);
        }

        [Fact]
        public void Works_For_Empty_Options()
        {
            var results = FbGenerator.Generate(new FbArgs(1, 20, new List<FbOption>()));

            Assert.NotEmpty(results);

            foreach (var fizzBuzzResponse in results)
            {
                Assert.Equal("", fizzBuzzResponse.Output);
            }
        }

        [Fact]
        public void Removes_Duplicate_Output()
        {
            var results = FbGenerator.Generate(new FbArgs(1, 20, new List<FbOption>()
            {
                new(3, "Fizz"),
                new(3, "Fizz"),
                new(5, "Buzz")
            }));

            Assert.NotEmpty(results);

            Assert.Equal("Fizz", results.Where(r => r.Index == 3).First().Output);
            Assert.Equal("Buzz", results.Where(r => r.Index == 5).First().Output);
            Assert.Equal("FizzBuzz", results.Where(r => r.Index == 15).First().Output);
        }

        [Fact]
        public void Min_Greater_Max_is_Handled()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => FbGenerator.Generate(new FbArgs(15, 14,
                new List<FbOption>()
                {
                    new(3, "Fizz"),
                    new(5, "Buzz")
                })));

            Assert.Equal("FizzBuzzArgs Max must be greater than or equal to Min", ex.Message);
        }

        [Fact]
        public void Null_Args_Are_Handled()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => FbGenerator.Generate(null));

            Assert.Equal("FizzBuzzArgs cannot be null (Parameter 'args')", ex.Message);
        }

        [Fact]
        public void Null_Options_Are_Handled()
        {
            Exception ex =
                Assert.Throws<ArgumentException>(() => FbGenerator.Generate(new FbArgs(0, Int16.MaxValue, null)));

            Assert.Equal("FizzBuzzArgs Options cannot be null (Parameter 'Options')", ex.Message);
        }


        [Fact]
        public void Null_Outputs_Are_Handled()
        {
            var results = FbGenerator.Generate(new FbArgs(1, 20, new List<FbOption>()
            {
                new(3, null),
                new(5, "Buzz")
            }));

            Assert.NotEmpty(results);

            Assert.Equal("N/A", results.Where(r => r.Index == 3).First().Output);
            Assert.Equal("Buzz", results.Where(r => r.Index == 5).First().Output);
            Assert.Equal("N/ABuzz", results.Where(r => r.Index == 15).First().Output);
        }
    }
}