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

            // Further problem solvers go here.

            Console.WriteLine("===================================");
        }

        static void WriteResult(int problem, int result)
        {
            string paddedNumber = problem.ToString().PadLeft(4, ' ');
            Console.WriteLine($"Problem {paddedNumber}: {result}.");
        }
    }
}