using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ComparativaC
{
    class Program
    {
        static void Main(string[] args)
        {
            long measureExecutionTime(Func<long> result, long repetitions = 1000)
            {
                var stopwatch = Stopwatch.StartNew();
                for (long i = 0; i < repetitions; i++)
                    result();
                return stopwatch.ElapsedTicks / repetitions;
            }
            void Print(Func<long> result, long expectedResult, long repetitions = 1000)
                => Console.WriteLine($"{result() == expectedResult} :: {result()} ({measureExecutionTime(result, repetitions):#,##0} ticks)");

            // EULER PROBLEM 1
            long EulerProblem1()
                => Enumerable.Range(0, 1000).Where(n => n % 3 == 0 || n % 5 == 0).Sum();
            Print(EulerProblem1, 233168);

            // EULER PROBLEM 2
            IEnumerable<long> Fibonacci(long maxValue)
            {
                long i = 1, j = 2;
                while (i <= maxValue)
                {
                    yield return i;
                    (i, j) = (j, i + j);
                }
            }
            Debug.Assert(new long[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 }.SequenceEqual(Fibonacci(100)));

            long EulerProblem2()
                => Fibonacci(4_000_000).Where(n => n % 2 == 0).Sum();
            Print(EulerProblem2, 4613732);

            // EULER PROBLEM 3
            IEnumerable<int> Primes(int maxValue)
            {
                var isComposite = new bool[maxValue + 1];
                for (int i = 2; i <= maxValue; i++)
                {
                    if (!isComposite[i])
                    {
                        yield return i;
                        for (int j = 2 * i; j <= maxValue; j += i)
                            isComposite[j] = true;
                    }
                }
            }
            Debug.Assert(new[] { 2, 3, 5, 7, 11, 13, 17 }.SequenceEqual(Primes(17)));
            Debug.Assert(Primes(108801).Max() == 108799);

            IEnumerable<long> PrimesBig(long maxValue)
            {
                var primes = new List<long> { 5, 7 };
                yield return 2;
                yield return 3;
                foreach (var p in primes) yield return p;

                bool testCandidate(long candidate)
                {
                    long squareRoot = (long)Math.Sqrt(candidate) + 1;
                    foreach (var prime in primes)
                    {
                        if (candidate % prime == 0)
                            return false;
                        else if (prime > squareRoot)
                            return true;
                    }
                    return true;
                }

                long nextCandidate;
                for (long candidate = 12; candidate <= maxValue + 10; candidate += 6)
                {
                    nextCandidate = candidate - 1;
                    if (nextCandidate > maxValue)
                        break;
                    if (testCandidate(nextCandidate))
                    {
                        primes.Add(nextCandidate);
                        yield return nextCandidate;
                    }

                    nextCandidate = candidate + 1;
                    if (nextCandidate > maxValue)
                        break;
                    if (testCandidate(nextCandidate))
                    {
                        primes.Add(nextCandidate);
                        yield return nextCandidate;
                    }
                }
            }
            Debug.Assert(new long[] { 2, 3, 5, 7, 11, 13, 17 }.SequenceEqual(PrimesBig(17)));
            Print(() => PrimesBig(1000).Max(), 17);
            Debug.Assert(Primes(108801).Max() == 108799);

            long EulerProblem3()
            {
                const long VALUE = 600851475143;
                foreach (var i in PrimesBig((int)Math.Sqrt(VALUE) + 10).Reverse())
                    if (VALUE % i == 0)
                        return i;
                throw new Exception($"{VALUE} is prime");
            }
            Print(EulerProblem3, 6857, repetitions: 10);

            Console.ReadLine();
        }
    }
}
