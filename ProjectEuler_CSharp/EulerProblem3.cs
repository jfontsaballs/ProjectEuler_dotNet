using System;
using System.Linq;

namespace ProjectEuler_CSharp
{
    public static class EulerProblem3
    {
        public static long Calculate(long value)
        {
            foreach (var i in Primes.UpTo((int)Math.Sqrt(value) + 10).Reverse())
                if (value % i == 0)
                    return i;
            throw new Exception($"{value} is prime");
        }
    }
}
