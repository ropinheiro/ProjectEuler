namespace ProjectEuler
{
    /// <summary>
    /// Define a Problem
    /// </summary>
    public class ProblemInfo
    {
        /// <summary>
        /// The number of the Problem according to its order in Project Euler.
        /// </summary>
        public int Number;

        /// <summary>
        /// The title of the Problem (copied from the site).
        /// </summary>
        public string Title;

        /// <summary>
        /// Set it to true of current solution takes too much time to run.
        /// Let's consider that more than 10 seconds is too much time.
        /// </summary>
        public bool HasSlowResolution;

        /// <summary>
        /// Once a solution is achieved, put here the result. Could be used
        /// in the future for unit tests.
        /// </summary>
        public long ExpectedSolution;

        public static ProblemInfo GetUndocumentedProblem(int problemNumber)
        {
            return new ProblemInfo()
            {
                Number = problemNumber,
                Title = "MISSING DOCUMENTATION",
                HasSlowResolution = false,
                ExpectedSolution = -1
            };
        }
    }
}