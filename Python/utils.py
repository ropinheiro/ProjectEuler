import math;

def isPrime(number):
    if number <= 1:
        return False;
    if number == 2:
        return True;
    if number % 2 == 0:
        return False;

    boundary = math.floor(math.sqrt(number));

    i = 3;
    while i <= boundary:
        if number % i == 0:
            return False;
        i += 2;

    return True;

def writeResult(problem, result):
    paddedNumber = "{}".format(problem).rjust(4, ' ');
    print("Problem {}: {}.".format(paddedNumber, result));