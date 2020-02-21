module ProjectEuler_FSharp.Fibonacci

let UpTo maxValue =
    let rec recFibonnacci a b =
        let c = a + b
        if c <= maxValue then c :: (recFibonnacci b c)
        else []
    1 :: 2 :: (recFibonnacci 1 2)