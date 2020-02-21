module ProjectEuler_Tests.EulerProblem3

open NUnit.Framework

[<Test>]
let Test_CSharp () =
    Assert.AreEqual(6857, ProjectEuler_CSharp.EulerProblem3.Calculate(600851475143L))

[<Test>]
let Test_FSharp () =
    Assert.AreEqual(6857, ProjectEuler_FSharp.EulerProblem3.Calculate(600851475143L))
