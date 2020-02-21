module ProjectEuler_Tests.Fibonacci

open NUnit.Framework

let Fibonacci100 = [1; 2; 3; 5; 8; 13; 21; 34; 55; 89]

[<Test>]
let Test_CSharp () =
    Assert.AreEqual(Fibonacci100, ProjectEuler_CSharp.Fibonacci.UpTo(100L))

[<Test>]
let Test_FSharp () =
    Assert.AreEqual(Fibonacci100, ProjectEuler_FSharp.Fibonacci.UpTo(100))
