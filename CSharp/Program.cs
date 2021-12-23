using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Results for Euler Project problems:");
            Console.WriteLine("-----------------------------------");

            SolveProblem(1);
            SolveProblem(2);
            // Further problem solvers go here.

            Console.WriteLine("===================================");
        }

        static void SolveProblem(int problem)
        {
            int result = new ProblemSolver().RunSolver(problem);
            string paddedNumber = problem.ToString().PadLeft(4, ' ');
            Console.WriteLine($"Problem {paddedNumber}: {result}.");
        }
    }
}