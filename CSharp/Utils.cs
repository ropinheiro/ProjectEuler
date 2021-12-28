using System;

namespace ProjectEuler
{
    /// <summary>
    /// Dumping here general purpose auxiliary methods that don't fit elsewhere.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Get the maximum number of parts we can divide a big number, given a part size.
        /// </summary>
        /// <param name="number">A positive integer number inside a string.</param>
        /// <param name="partSize">The number of digits of each part (starting to count from the least significat digits).</param>
        /// <returns>The maximum number of the parts the given number can be divided.</returns>
        public static int GetMaxPartsOfNumber(string number, int partSize)
        {
            return (int)Math.Ceiling((decimal)number.Length / (decimal)partSize);
        }


        /// <summary>
        /// Gets a part of a (typically big) positive integer given the part
        /// and a part size. Parts start counting from the least significant
        /// digits. If we split "12345678" in parts of partSize = 3, we get:
        /// Part 1 = 678, Part 2 = 345 and Part 3 = 12.
        /// </summary>
        /// <param name="number">A positive integer number inside a string.</param>
        /// <param name="part">The part we want to extract.</param>
        /// <param name="partSize">The number of digits of each part (starting to count from the least significat digits).</param>
        /// <returns>The part we want to extract (must fit in a long).</returns>
        public static long GetPartOfNumber(string number, int part, int partSize)
        {
            int maxParts = GetMaxPartsOfNumber(number, partSize);

            // We assume that if we ask for parts too much to the "left", then
            // we can imagine an endless number of parts all zero after the
            // most significant digit, so all those parts would return zero.
            if (part > maxParts)
            {
                return 0;
            }

            // Guarantee that we have all parts with exact number of partSize
            // digits, by putting "missing" zeros at the right.
            string auxNumber = number.PadLeft(maxParts * partSize, '0');

            // At this point we have a perfect math to extract a part.
            return long.Parse(auxNumber.Substring(auxNumber.Length - (part * partSize), partSize));
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