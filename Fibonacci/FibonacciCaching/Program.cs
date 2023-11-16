using BenchmarkDotNet.Running;
using FibonacciCaching;

BenchmarkRunner.Run<Benchmark>();

/* 

Fibonacci sequence is a sequence of positive natural numbers that starts with 0 and 1 for first two elements,
 and then for all other elements we can define each of them as fibonnaci(x) = fibonacci(x - 1) + fibonacci(x - 2).

Fibonacci numbers:

F0 - 0
F1 - 1
F2 - 1
F3 - 2
F4 - 3
F5 - 5
F6 - 8
F7 - 13
F8 - 21
F9 - 34
F10 - 55
F11 - 89
F12 - 144

...

1. Write missing tests for FibonacciRecursive class.
2. Write recursive Fibonnaci calculation algorithm. Base it on Fibonacci Memoization algorithm. Just remove part that memoizes.
3. Make sure all tests are passing.
4. Write benchmark code that compares three implementations with each other.

*/