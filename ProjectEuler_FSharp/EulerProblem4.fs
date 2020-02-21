module ProjectEuler_FSharp.EulerProblem4

open ProjectEuler_FSharp

let Calculate(maxVal) =
    seq {maxVal..(-1)..0}
    |> Seq.allPairs (seq {maxVal..(-1)..0})
    |> Seq.map(fun (i, j) -> i * j)
    |> Seq.sortDescending
    |> Seq.find Palindromes.IsPalindrome

