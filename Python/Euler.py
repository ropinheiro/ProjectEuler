# -------------------------------------------------------------------
# Problem Solvers
# -------------------------------------------------------------------

def solveProblem0001():
    return -1

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
