using System;

namespace ProjectEuler
{
    /// <summary>
    /// Dumping here general purpose auxiliary methods that don't fit elsewhere.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Calculates the factorial of a given number n.
        /// F(n) = n * (n-1) * (n-2) * ... * 1
        /// </summary>
        /// <param name="n">A given number n.</param>
        /// <returns>The factorial of n.</returns>
        public static double Factorial(double n)
        {
            if (n <= 1)
                return 1;

            return n * Factorial(n - 1);
        }

        /// <summary>
        /// Checks if a given number is palindrome.
        /// Thanks to: CodeVsColor
        /// Source: https://www.codevscolor.com/c-sharp-check-palindrome-number
        /// </summary>
        /// <param name="number">A given number.</param>
        /// <returns>True if the given number is palindrome, false otherwise.</returns>
        public static bool IsPalindrome(long number)
        {
            long tempValue = number;
            long reverse = 0;
            while (tempValue > 0)
            {
                reverse = reverse * 10 + tempValue % 10;
                tempValue = tempValue / 10;
            }
            return reverse == number;
        }

        /// <summary>
        /// Checks if a given number is prime.
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