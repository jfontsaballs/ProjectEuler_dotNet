module ProjectEuler_Tests.EulerProblem1

open NUnit.Framework

[<Test>]
let Test_CSharp () =
    Assert.AreEqual(233168, ProjectEuler_CSharp.EulerProblem1.Calculate(1000))

[<Test>]
let Test_FSharp () =
    Assert.AreEqual(233168, ProjectEuler_FSharp.EulerProblem1.Calculate(1000))
