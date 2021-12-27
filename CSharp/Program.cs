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
            new ProblemInfo() { Number = 10, Title = "Summation of primes", HasSlowResolution = false, ExpectedSolution = 142913828922 },
            new ProblemInfo() { Number = 11, Title = "Largest product in a grid", HasSlowResolution = false, ExpectedSolution = 70600674 },
            new ProblemInfo() { Number = 12, Title = "Highly divisible triangular number", HasSlowResolution = false, ExpectedSolution = 76576500 },
        };

        const int SeparatorNumberOfChars = 80;
        const string LotsOfSpaces = "                                                    ";
        const int CharsCountForID = 6;
        const int CharsCountForSolution = 16;
        const int CharsCountForStatus = 5;
        const int CharsCountForTime = 10;

        /// <summary>
        /// The -1 is to account for the separator pipe between columns.
        /// </summary>
        const int CharsCountForTitle = SeparatorNumberOfChars
                    - CharsCountForID - 1 - CharsCountForSolution - 1
                    - CharsCountForStatus - 1 - CharsCountForTime - 1;

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
            WriteTableHeader();
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

        static void WriteTableHeader()
        {
            string headerID = GetCenteredText("ID", CharsCountForID);
            string headerSolution = GetCenteredText("Solution", CharsCountForSolution);
            string headerStatus = GetCenteredText("OK?", CharsCountForStatus);
            string headerTime = GetCenteredText("Time", CharsCountForTime);
            string headerTitle = GetCenteredText("Title", CharsCountForTitle);
            Console.WriteLine($"{headerID}|{headerSolution}|{headerStatus}|{headerTime}|{headerTitle}");
        }

        static string GetCenteredText(string text, int size)
        {
            string auxHeader = $"{LotsOfSpaces}{text}{LotsOfSpaces}";
            int spacesToRemove = auxHeader.Length - size;
            return auxHeader.Substring((spacesToRemove / 2), size);
        }

        static string GetRightAlignedText(string text, int size)
        {
            string auxHeader = $"{LotsOfSpaces}{text} ";
            int spacesToRemove = auxHeader.Length - size;
            return auxHeader.Substring(spacesToRemove);
        }

        static string GetLeftAlignedText(string text, int size)
        {
            return $" {text}{LotsOfSpaces}".Substring(0, size);
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
            string problemNumber = GetRightAlignedText(solution.ProblemNumber.ToString(), CharsCountForID);
            string problemSolution = GetProblemSolutionText(solution);
            string correctness = GetCorrectnessText(solution);
            string executionTime = GetExecutionTimeText(solution);
            string problemTitle = GetLeftAlignedText(problem.Title, CharsCountForTitle);

            Console.WriteLine($"{problemNumber}|{problemSolution}|{correctness}|{executionTime}|{problemTitle}");
        }

        static string GetProblemSolutionText(SolutionInfo solution)
        {
            if (solution.Skipped)
            {
                return GetCenteredText(
                    "- SKIP - ", CharsCountForSolution);
            }
            else
            {
                return GetRightAlignedText(
                    solution.ProblemSolution.ToString(), CharsCountForSolution);
            }
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

            return GetCenteredText(correctnessText, CharsCountForStatus);
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

            return GetRightAlignedText(executionTimeText, CharsCountForTime);
        }
    }
}