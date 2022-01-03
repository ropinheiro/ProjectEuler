using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace ProjectEuler
{
    /// <summary>
    /// Used to work with integers so big that they don't fit a long.
    /// </summary>
    public class BigInteger
    {
        /// <summary>
        /// We convention here 10 digits per part.
        /// </summary>
        const int numberOfDigitsPerPart = 10;

        /// <summary>
        /// Will store an array of parts of the (big) integer number.
        /// </summary>
        long[] bigNumberParts;

        /// <summary>
        /// Constructor that initializes the (big) integer number with all zeros,
        /// and a maximum size of 100 digits.
        /// </summary>
        public BigInteger() : this(10, "0") { }

        /// <summary>
        /// Constructor that initializes the (big) integer number with all zeros,
        /// but restricted to a given number N of 10xN digits.
        /// </summary>
        /// <param name="maxSizeInTenthsOfDigits">The expected number of parts of 10 digits.</param>
        public BigInteger(int maxSizeInTenthsOfDigits) : this(maxSizeInTenthsOfDigits, "0") { }

        /// <summary>
        /// Constructor that initializes the (big) integer providing both the
        /// maximum number of parts, and a default value.
        /// </summary>
        /// <param name="maxSizeInTenthsOfDigits">The expected number of parts of 10 digits.</param>
        /// <param name="initNumber">A default value to initialize the (big) number. Must have less than 10 x maxSizeInTenthsOfDigits digits.</param>
        public BigInteger(int maxSizeInTenthsOfDigits, string initNumber)
        {
            bigNumberParts = new long[maxSizeInTenthsOfDigits];
            for (int i = 0; i < bigNumberParts.Length; i++)
            {
                bigNumberParts[i] = 0;
            }
            Sum(initNumber);
        }

        /// <summary>
        /// Sums a given (integer) number to the current stored (big) integer.
        /// </summary>
        /// <param name="number">A given integer number inside a string</param>
        public void Sum(string number)
        {
            int maxParts = GetMaxPartsOfNumber(number, numberOfDigitsPerPart);

            for (int part = 1; part <= maxParts; part++)
            {
                long numberPart = GetPartOfNumber(number, part, numberOfDigitsPerPart);
                long auxSum = bigNumberParts[part - 1] + numberPart;
                string auxSumString = auxSum.ToString();
                long auxMostSignificantDigit = 0;

                // If our auxiliar sum got bigger than partSize, then we need
                // to split the most significat digit from the remaining number.
                if (auxSumString.Length > numberOfDigitsPerPart)
                {
                    auxMostSignificantDigit = long.Parse(auxSumString.Substring(0, 1));
                    auxSum = long.Parse(auxSumString.Substring(1));
                }

                int currentPartPosition = part - 1;
                int nextPartPosition = part;
                bigNumberParts[currentPartPosition] = auxSum;
                bigNumberParts[nextPartPosition] += auxMostSignificantDigit;
            }
        }

        /// <summary>
        /// Multiply a given (integer) number with the current stored (big) integer,
        /// and then store the result.
        /// </summary>
        /// <param name="number">A given integer number</param>
        public void Multiply(int number)
        {
            long remainingPart = 0;
            for (int part = 1; part <= bigNumberParts.Length; part++)
            {
                int currentPartPosition = part - 1;

                // We are multiplying a 10-digit long by a int, so we can be sure
                // that the result will always fit a long.
                long auxMultiplication = (number * bigNumberParts[currentPartPosition]) + remainingPart;

                // Now we extract the part that stays (the right part) and the
                // remaining "rest" that will be summed to the next calculation.
                long rightPart = GetPartOfNumber(auxMultiplication.ToString(), 1, numberOfDigitsPerPart);
                remainingPart = (auxMultiplication - rightPart) / (long)Math.Pow(10, numberOfDigitsPerPart);
                bigNumberParts[currentPartPosition] = rightPart;
            }
        }

        /// <summary>
        /// Gets the complete (big) integer. 
        /// </summary>
        /// <returns>The (big) integer as a string.</returns>
        public string GetNumber()
        {
            StringBuilder builder = new StringBuilder();

            for (int partPosition = bigNumberParts.Length - 1; partPosition >= 0; partPosition--)
            {
                string part = bigNumberParts[partPosition].ToString()
                    .PadLeft(numberOfDigitsPerPart, '0'); // This is needed so that parts
                                                          // with zeros located in the most
                                                          // significant positions also count.

                builder.Append(part);
            }

            return builder.ToString().TrimStart('0');
        }

        /// <summary>
        /// Get the maximum number of parts we can divide a big number, given a part size.
        /// </summary>
        /// <param name="number">A positive integer number inside a string.</param>
        /// <param name="partSize">The number of digits of each part (starting to count from the least significat digits).</param>
        /// <returns>The maximum number of the parts the given number can be divided.</returns>
        private static int GetMaxPartsOfNumber(string number, int partSize)
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
        private static long GetPartOfNumber(string number, int part, int partSize)
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
    }
}
