using System;
using System.Collections.Generic;

namespace ProjectEuler_CSharp
{
    public static class Primes
    {
        public static IEnumerable<int> UpTo(int maxValue)
        {
            var isComposite = new bool[maxValue + 1];
            for (int i = 2; i <= maxValue; i++) {
                if (!isComposite[i]) {
                    yield return i;
                    for (int j = 2 * i; j <= maxValue; j += i)
                        isComposite[j] = true;
                }
            }
        }

        public static IEnumerable<long> UpTo(long maxValue)
        {
            var primes = new List<long> { 5, 7 };
            yield return 2;
            yield return 3;
            foreach (var p in primes) yield return p;

            bool testCandidate(long candidate)
            {
                long squareRoot = (long)Math.Sqrt(candidate) + 1;
                foreach (var prime in primes) {
                    if (candidate % prime == 0)
                        return false;
                    else if (prime > squareRoot)
                        return true;
                }
                return true;
            }

            long nextCandidate;
            for (long candidate = 12; candidate <= maxValue + 10; candidate += 6) {
                nextCandidate = candidate - 1;
                if (nextCandidate > maxValue)
                    break;
                if (testCandidate(nextCandidate)) {
                    primes.Add(nextCandidate);
                    yield return nextCandidate;
                }

                nextCandidate = candidate + 1;
                if (nextCandidate > maxValue)
                    break;
                if (testCandidate(nextCandidate)) {
                    primes.Add(nextCandidate);
                    yield return nextCandidate;
                }
            }
        }

    }
}
