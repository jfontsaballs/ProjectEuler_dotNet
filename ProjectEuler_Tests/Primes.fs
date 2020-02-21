module ProjectEuler_Tests.Primes

open NUnit.Framework
open System.Linq

let Fibonacci100 = [1; 2; 3; 5; 8; 13; 21; 34; 55; 89]

[<Test>]
let Test_CSharp () =
    Assert.AreEqual([| 2; 3; 5; 7; 11; 13; 17 |], ProjectEuler_CSharp.Primes.UpTo(17));
    Assert.AreEqual(108799, ProjectEuler_CSharp.Primes.UpTo(108801).Max());

    Assert.AreEqual([| 2; 3; 5; 7; 11; 13; 17 |], ProjectEuler_CSharp.Primes.UpTo(17L));
    Assert.AreEqual(108799, ProjectEuler_CSharp.Primes.UpTo(108801L).Max());

[<Test>]
let Test_FSharp () =
    Assert.AreEqual([| 2; 3; 5; 7; 11; 13; 17 |], ProjectEuler_FSharp.Primes.UpTo(17));
    Assert.AreEqual(108799, ProjectEuler_FSharp.Primes.UpTo(108801).Max());

    Assert.AreEqual([| 2; 3; 5; 7; 11; 13; 17 |], ProjectEuler_FSharp.Primes.UpToBig(17L));
    Assert.AreEqual(108799, ProjectEuler_FSharp.Primes.UpToBig(108801L) |> Seq.max);