using System.Linq;

namespace ProjectEuler_CSharp
{
    public static class EulerProblem4
    {
        public static long Calculate(int maxValue)
            => Enumerable.Range(0, maxValue)
                .SelectMany(i => Enumerable.Range(0, maxValue).Select(j => (i, j)))
                .Select(x => x.i * x.j)
                .OrderByDescending(x => x)
                .First(Palindromes.IsPalindrome);
    }
}
