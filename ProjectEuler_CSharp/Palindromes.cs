namespace ProjectEuler_CSharp
{
    public static class Palindromes
    {
        public static bool IsPalindrome(int value) => value == reverse(value);

        private static int reverse(int x)
        {
            int remain = x, reversed = 0;
            while(remain > 0) {
                reversed = reversed * 10 + remain % 10;
                remain = remain / 10;
            }
            return reversed;
        }
    }
}
