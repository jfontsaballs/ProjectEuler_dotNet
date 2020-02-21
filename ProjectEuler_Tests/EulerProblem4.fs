module ProjectEuler_Tests.EulerProblem4

open NUnit.Framework

[<Test>]
let Test_CSharp () =
    Assert.AreEqual(9009, ProjectEuler_CSharp.EulerProblem4.Calculate(100))
    Assert.AreEqual(906609, ProjectEuler_CSharp.EulerProblem4.Calculate(1000))

[<Test>]
let Test_FSharp () =
    Assert.AreEqual(9009, ProjectEuler_FSharp.EulerProblem4.Calculate(100))
    Assert.AreEqual(906609, ProjectEuler_FSharp.EulerProblem4.Calculate(1000))
