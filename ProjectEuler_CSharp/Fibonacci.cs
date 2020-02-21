using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler_CSharp
{
    public static class Fibonacci
    {
        public static IEnumerable<long> UpTo(long maxValue)
        {
            long i = 1, j = 2;
            while (i <= maxValue) {
                yield return i;
                (i, j) = (j, i + j);
            }
        }

    }
}
