
namespace ProjectEuler
{
    public static class ProblemSolver
    {
        /// <summary>
        /// -------------------------------------------------------------------
        /// Problem 1
        /// Multiples of 3 or 5
        /// -------------------------------------------------------------------
        /// If we list all the natural numbers below 10 that are multiples of
        /// 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        /// Find the sum of all the multiples of 3 or 5 below 1000.
        /// -------------------------------------------------------------------
        /// </summary>
        /// <returns>Solution for Project Euler #1</returns>
        public static int SolveProblem0001()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}