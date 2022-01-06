package main

import (
	"fmt"
	"time"
)

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
func solveProblem0001() (result int) {
    result = 0
    for i := 1; i < 1000; i++ {
        if (i % 3 == 0 || i % 5 == 0) {
            result += i
        }
    }
    return result
}

/// -------------------------------------------------------------------
/// Helpers
/// -------------------------------------------------------------------
func writeResult(problem int, result int, duration time.Duration) {
    fmt.Printf("Problem %4d: %d. [in %s]\n",
		problem, result, duration)
}

/// -------------------------------------------------------------------
/// Main method
/// -------------------------------------------------------------------
func main() {

    fmt.Println("===================================")
    fmt.Println("Results for Euler Project problems:")
    fmt.Println("-----------------------------------")

    start := time.Now()
    writeResult(1, solveProblem0001(), time.Since(start))

	// Further problem solvers go here.

    fmt.Println("===================================")
}