module ProjectEuler_FSharp.EulerProblem3

open System

let Calculate(maxValue : int64) =
    let valRoot = int64 (Math.Sqrt(float maxValue)) + 10L
    Primes.UpToBig valRoot |> Seq.rev |> Seq.pick (fun p -> if maxValue % p = 0L then Some(p) else None)
