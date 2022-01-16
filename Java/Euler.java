/// -------------------------------------------------------------------
/// Main method executes all current solutions by calling each
/// solveProblem* method, one by one, outputting the result.
/// -------------------------------------------------------------------
class Euler {

    /// -------------------------------------------------------------------
    /// Problem 1
    /// Multiples of 3 or 5
    /// -------------------------------------------------------------------
    /// If we list all the natural numbers below 10 that are multiples of
    /// 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// -------------------------------------------------------------------
    /// Returns: Solution for Project Euler #1
    /// -------------------------------------------------------------------
    static int solveProblem0001()
    {
        int sum = 0;
        for (int i = 1; i < 1000; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum += i;
            }
        }
        return sum;
    }

    /// -------------------------------------------------------------------
    /// Helpers
    /// -------------------------------------------------------------------
    static void writeResult(int problem, int result)
    {
        System.out.println("Problem " + problem + ": " + result + ".");
    }

    /// -------------------------------------------------------------------
    /// Main method
    /// -------------------------------------------------------------------
    public static void main(String[] args) {

        System.out.println("===================================");
        System.out.println("Results for Euler Project problems:");
        System.out.println("-----------------------------------");

        // Uncomment when done...
        writeResult(1, solveProblem0001());

        // Further problem solvers go here.

        System.out.println("===================================");
    }
}