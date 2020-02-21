using System.Linq;

namespace ProjectEuler_CSharp
{
    public static class EulerProblem2
    {
        public static long Calculate(int maxValue)
            => Fibonacci.UpTo(maxValue).Where(n => n % 2 == 0).Sum();
    }
}
