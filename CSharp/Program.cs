using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        /// <summary>
        /// Document your Problems here.
        /// </summary>
        static List<ProblemInfo> ProblemDefinitions = new List<ProblemInfo>()
        {
            new ProblemInfo() { Number = 1, Title = "Multiples of 3 or 5", HasSlowResolution = false, ExpectedSolution = 233168 },
            new ProblemInfo() { Number = 2, Title = "Even Fibonacci numbers", HasSlowResolution = false, ExpectedSolution = 4613732 },
            new ProblemInfo() { Number = 3, Title = "Largest prime factor", HasSlowResolution = true, ExpectedSolution = 6857 },
            new ProblemInfo() { Number = 4, Title = "Largest palindrome product", HasSlowResolution = false, ExpectedSolution = 906609 },
            new ProblemInfo() { Number = 5, Title = "Smallest multiple", HasSlowResolution = false, ExpectedSolution = 232792560 },
            new ProblemInfo() { Number = 6, Title = "Sum square difference", HasSlowResolution = false, ExpectedSolution = 25164150 },
            new ProblemInfo() { Number = 7, Title = "10001st prime", HasSlowResolution = false, ExpectedSolution = 104743 },
            new ProblemInfo() { Number = 8, Title = "Largest product in a series", HasSlowResolution = false, ExpectedSolution = 23514624000 },
            new ProblemInfo() { Number = 9, Title = "Special Pythagorean triplet", HasSlowResolution = false, ExpectedSolution = 31875000 },
        };

        const int SeparatorNumberOfChars = 80;

        static void Main(string[] args)
        {
            ProblemSolver solver = new ProblemSolver();
            WriteHeader(solver);
            SolveProblems(solver);
            WriteHeavySeparator();
        }

        static void WriteHeader(ProblemSolver solver)
        {
            WriteHeavySeparator();
            Console.WriteLine("Results for Euler Project problems:");
            WriteLightSeparator();
            Console.WriteLine($"Found {solver.NumberOfProblemsSolved} problems solved.");
            WriteLightSeparator();
            Console.WriteLine("  ID  |   Solution   | OK? |   Time   |  Title");
            WriteLightSeparator();
        }

        static void WriteSeparator(string character)
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat(character, SeparatorNumberOfChars)));
        }

        static void WriteHeavySeparator()
        {
            WriteSeparator("=");
        }

        static void WriteLightSeparator()
        {
            WriteSeparator("-");
        }

        static void SolveProblems(ProblemSolver solver)
        {
            for (int problemNumber = 1;
                 problemNumber <= solver.NumberOfProblemsSolved;
                 problemNumber++)
            {
                ProblemInfo problem = GetProblemInfo(problemNumber);
                SolutionInfo solution = solver.Solve(problem);
                WriteResult(problem, solution);
            }
        }

        static ProblemInfo GetProblemInfo(int problemNumber)
        {
            return ProblemDefinitions
                .Where(p => p.Number == problemNumber)
                .SingleOrDefault(ProblemInfo.GetUndocumentedProblem(problemNumber));
        }

        static void WriteResult(ProblemInfo problem, SolutionInfo solution)
        {
            string problemNumber = solution.ProblemNumber.ToString().PadLeft(4, ' ');
            string problemSolution = GetProblemSolutionText(solution);
            string correctness = GetCorrectnessText(solution);
            string executionTime = GetExecutionTimeText(solution);

            Console.WriteLine($"{problemNumber}  | {problemSolution}  | {correctness}  | {executionTime} | {problem.Title}");
        }

        static string GetProblemSolutionText(SolutionInfo solution)
        {
            string problemSolutionText;

            if (solution.Skipped)
            {
                problemSolutionText = "- SKIP -";
            }
            else
            {
                problemSolutionText = solution.ProblemSolution.ToString();
            }

            return problemSolutionText.PadLeft(11, ' ');
        }

        static string GetCorrectnessText(SolutionInfo solution)
        {
            string correctnessText;

            if (solution.Skipped)
            {
                correctnessText = "-";
            }
            else
            {
                correctnessText = solution.SolutionIsCorrect ? "V" : "X";
            }

            return correctnessText.PadLeft(2, ' ');
        }

        static string GetExecutionTimeText(SolutionInfo solution)
        {
            string executionTimeText;

            if (solution.Skipped)
            {
                executionTimeText = "--- ms";
            }
            else
            {
                bool useSecondsInstead = solution.ExecutionTimeInMs > 1000;

                if (useSecondsInstead)
                {
                    executionTimeText = (solution.ExecutionTimeInMs / 1000).ToString() + " s ";
                }
                else
                {
                    executionTimeText = solution.ExecutionTimeInMs.ToString() + " ms";
                }
            }

            return executionTimeText.PadLeft(8, ' ');
        }
    }
}