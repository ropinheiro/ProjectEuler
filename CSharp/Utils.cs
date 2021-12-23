using System;

namespace ProjectEuler
{
    /// <summary>
    /// Dumping here general purpose auxiliary methods that don't fit elsewhere.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Checks if a given number is Prime.
        /// Thanks to: Soner Gönül
        /// Source: https://stackoverflow.com/a/15743238/1520915
        /// </summary>
        /// <param name="number">A given number.</param>
        /// <returns>True if the given number is prime, false otherwise.</returns>
        public static bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (long)Math.Floor(Math.Sqrt(number));

            for (long i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}