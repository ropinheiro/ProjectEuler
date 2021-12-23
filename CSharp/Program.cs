using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            ProblemSolver solver = new ProblemSolver();
            int problemsSolved = solver.GetNumberOfProblemsSolved();

            Console.WriteLine("===================================");
            Console.WriteLine("Results for Euler Project problems:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Found {problemsSolved} problems solved.");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Problem |  Solution  | Elapsed Time");
            Console.WriteLine("-----------------------------------");

            for (int problem = 1; problem <= problemsSolved; problem++)
            {
                WriteResult(solver.Solve(problem));
            }
            Console.WriteLine("===================================");
        }

        static void WriteResult(SolutionInfo solution)
        {
            string problemNumber =
                solution.ProblemNumber.ToString().PadLeft(5, ' ');
            string problemSolution =
                solution.ProblemSolution.ToString().PadLeft(10, ' ');
            string executionTimeInMs =
                solution.ExecutionTimeInMs.ToString().PadLeft(9, ' ');

            Console.WriteLine($"{problemNumber}   | {problemSolution} | {executionTimeInMs} ms");
        }
    }
}