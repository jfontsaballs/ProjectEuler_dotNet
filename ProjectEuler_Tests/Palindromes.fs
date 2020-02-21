module ProjectEuler_Tests.Palindromes

open NUnit.Framework

let Fibonacci100 = [1; 2; 3; 5; 8; 13; 21; 34; 55; 89]

[<Test>]
let Test_CSharp () =
    Assert.IsTrue(ProjectEuler_CSharp.Palindromes.IsPalindrome(9449));
    Assert.IsTrue(ProjectEuler_CSharp.Palindromes.IsPalindrome(70107));
    Assert.IsTrue(ProjectEuler_CSharp.Palindromes.IsPalindrome(5005));
    Assert.IsFalse(ProjectEuler_CSharp.Palindromes.IsPalindrome(1041));
    Assert.IsFalse(ProjectEuler_CSharp.Palindromes.IsPalindrome(350503));

[<Test>]
let Test_FSharp () =
    Assert.IsTrue(ProjectEuler_FSharp.Palindromes.IsPalindrome(9449));
    Assert.IsTrue(ProjectEuler_FSharp.Palindromes.IsPalindrome(70107));
    Assert.IsTrue(ProjectEuler_FSharp.Palindromes.IsPalindrome(5005));
    Assert.IsFalse(ProjectEuler_FSharp.Palindromes.IsPalindrome(1041));
    Assert.IsFalse(ProjectEuler_FSharp.Palindromes.IsPalindrome(350503));

