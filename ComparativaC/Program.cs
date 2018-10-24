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
            long measureExecutionTime(Func<int> result, int repetitions = 1000)
            {
                var stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < repetitions; i++)
                    result();
                return stopwatch.ElapsedTicks / repetitions;
            }
            //double measureMemoryConsumption(Func<int> result, int repetitions = 10)
            //{
            //    var results = new List<long>();
            //    for (int i = 0; i < repetitions; i++)
            //    {
            //        GC.Collect();
            //        GC.WaitForPendingFinalizers();
            //        GC.Collect();
            //        var before = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
            //        result();
            //        var after = System.Diagnostics.Process.GetCurrentProcess().VirtualMemorySize64;
            //        results.Add(after - before);
            //    }
            //    return results.Average();
            //}
            void Print(Func<int> result, int expectedResult, int repetitions = 1000)
                => Console.WriteLine($"{result() == expectedResult} :: {result()} ({measureExecutionTime(result, repetitions)} ticks)");

            // EULER PROBLEM 1
            int EulerProblem1()
                => Enumerable.Range(0, 1000).Where(n => n % 3 == 0 || n % 5 == 0).Sum();
            Print(EulerProblem1, 233168);

            // EULER PROBLEM 2
            IEnumerable<int> Fibonacci(int maxValue)
            {
                int i = 1, j = 2;
                while (i <= maxValue)
                {
                    yield return i;
                    (i, j) = (j, i + j);
                }
            }
            Debug.Assert(new[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 }.SequenceEqual(Fibonacci(100)));

            int EulerProblem2()
                => Fibonacci(4_000_000).Where(n => n % 2 == 0).Sum();
            Print(EulerProblem2, 4613732);

            // EULER PROBLEM 3
            IEnumerable<int> Primes2(int maxValue)
            {
                var isComposite = new bool[maxValue + 1];
                for (int i = 2; i <= maxValue; i++)
                {
                    if (isComposite[i])
                        continue;
                    else
                        yield return i;
                    for (int j = 2 * i; j <= maxValue; j += i)
                        isComposite[j] = true;
                }

            }
            Debug.Assert(new[] { 2, 3, 5, 7, 11, 13, 17 }.SequenceEqual(Primes2(17)));
            Print(() => Primes2(108801).Max(), 108799, 10);

            Console.ReadLine();
        }
    }
}
