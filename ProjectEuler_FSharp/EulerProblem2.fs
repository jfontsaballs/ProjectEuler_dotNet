module ProjectEuler_FSharp.EulerProblem2

let Calculate(maxValue : int32) =
    Fibonacci.UpTo maxValue
    |> Seq.filter (fun n -> n % 2 = 0)
    |> Seq.sum
