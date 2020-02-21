module ProjectEuler_Tests.EulerProblem2

open NUnit.Framework

[<Test>]
let Test_CSharp () =
    Assert.AreEqual(4613732, ProjectEuler_CSharp.EulerProblem2.Calculate(4_000_000))

[<Test>]
let Test_FSharp () =
    Assert.AreEqual(4613732, ProjectEuler_FSharp.EulerProblem2.Calculate(4_000_000))
