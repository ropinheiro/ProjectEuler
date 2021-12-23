namespace ProjectEuler
{
    /// <summary>
    /// Stores the Problem's Solution information
    /// </summary>
    public class SolutionInfo
    {
        /// <summary>
        /// The number (unique identifier) of the problem solved.
        /// </summary>
        public int ProblemNumber;

        /// <summary>
        /// The calculated solution for the problem.
        /// </summary>
        public long ProblemSolution;

        /// <summary>
        /// Check if the calculated solution is correct.
        /// Expected value must be documented in the associated ProblemInfo.
        /// </summary>
        public bool SolutionIsCorrect;

        /// <summary>
        /// The execution time in milliseconds.
        /// </summary>
        public long ExecutionTimeInMs;

        /// <summary>
        /// Tells if the calculation was skipped for any reason.
        /// </summary>
        public bool Skipped;

        public SolutionInfo(int problemNumber)
        {
            ProblemNumber = problemNumber;
        }

        public static SolutionInfo GetSkippedSolution(int problemNumber)
        {
            return new SolutionInfo(problemNumber)
            {
                ProblemSolution = -1,
                SolutionIsCorrect = false,
                ExecutionTimeInMs = 0,
                Skipped = true
            };
        }
    }
}