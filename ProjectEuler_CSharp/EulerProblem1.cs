using System.Linq;

namespace ProjectEuler_CSharp
{
    public static class EulerProblem1
    {
        public static long Calculate(int maxValue)
            => Enumerable.Range(0, maxValue).Where(n => n % 3 == 0 || n % 5 == 0).Sum();
    }
}
