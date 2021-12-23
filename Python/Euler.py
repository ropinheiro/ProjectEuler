# -------------------------------------------------------------------
# Problem Solvers
# -------------------------------------------------------------------

# -------------------------------------------------------------------
# Problem 1
# Multiples of 3 or 5
# -------------------------------------------------------------------
# If we list all the natural numbers below 10 that are multiples of
# 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
# Find the sum of all the multiples of 3 or 5 below 1000.
# -------------------------------------------------------------------
# Returns: Solution for Project Euler #1
# -------------------------------------------------------------------
def solveProblem0001():
    sum = 0;
    for i in range(1000):
        if i % 3 == 0 or i % 5 == 0:
            sum += i;
    return sum;

# -------------------------------------------------------------------
# Helpers
# -------------------------------------------------------------------
def writeResult(problem, result):
    paddedNumber = "{}".format(problem).rjust(4, ' ');
    print("Problem {}: {}.".format(paddedNumber, result));

# -------------------------------------------------------------------
# Main
# -------------------------------------------------------------------
print("===================================");
print("Results for Euler Project problems:");
print("-----------------------------------");

writeResult(1, solveProblem0001());
# Further problem solvers go here.

print("===================================");
