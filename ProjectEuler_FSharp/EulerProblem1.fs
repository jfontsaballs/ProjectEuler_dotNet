module ProjectEuler_FSharp.EulerProblem1

let Calculate(maxValue : int32) =
    seq {1..maxValue - 1}
    |> Seq.filter (fun n -> n % 3 = 0 || n % 5 = 0)
    |> Seq.sum