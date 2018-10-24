open System
open System.Diagnostics

let measureExecutionTime calculation repetitions =
    let stopwatch = Stopwatch.StartNew()
    for i = 1 to repetitions do
        calculation() |> ignore
    stopwatch.ElapsedTicks / (int64 repetitions)

let Print calculation expectedResult =
    printfn "%b :: %i (%i ticks)" (expectedResult = calculation()) 
        (calculation()) (measureExecutionTime calculation 1000)

// EULER PROBLEM 1
let EulerProblem1() =
    seq { 1..999 }
    |> Seq.filter (fun n -> n % 3 = 0 || n % 5 = 0)
    |> Seq.sum

Print EulerProblem1 233168

// EULER PROBLEM 2
let Fibonnacci maxValue =
    let rec recFibonnacci a b =
        let c = a + b
        if c <= maxValue then c :: (recFibonnacci b c)
        else []
    1 :: 2 :: (recFibonnacci 1 2)

assert (Fibonnacci 100 = [ 1; 2; 3; 5; 8; 13; 21; 34; 55; 89 ])

let EulerProblem2() =
    Fibonnacci 4_000_000
    |> Seq.filter (fun n -> n % 2 = 0)
    |> Seq.sum

Print EulerProblem2 4613732

// EULER PROBLEM 3
let Primes maxValue =
    let isComposite : bool array = Array.zeroCreate (maxValue + 1)
    10

Console.ReadLine() |> ignore
