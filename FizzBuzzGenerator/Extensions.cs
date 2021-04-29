using System;

namespace FizzBuzzGenerator
{
    public static class Extensions
    {
        public static bool IsDivisibleBy(this Int16 i, short divisor)
        {
            return i % divisor == 0;
        }
    }
}