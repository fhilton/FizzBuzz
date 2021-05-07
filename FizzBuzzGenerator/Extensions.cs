using System;

namespace FizzBuzzGenerator
{
    public static class Extensions
    {
        public static bool IsDivisibleBy(this int i, int divisor)
        {
            return i % divisor == 0;
        }
    }
}