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

type gcList<'T> = System.Collections.Generic.List<'T>

// EULER PROBLEM 1
let EulerProblem1() =
    seq {1..999}
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
assert (Fibonnacci 100 = [1; 2; 3; 5; 8; 13; 21; 34; 55; 89])

let EulerProblem2() =
    Fibonnacci 4_000_000
    |> Seq.filter (fun n -> n % 2 = 0)
    |> Seq.sum
Print EulerProblem2 4613732

// EULER PROBLEM 3
let Primes maxValue =
    let isComposite : bool array = Array.zeroCreate (maxValue + 1)
    seq {
        for i = 2 to maxValue do
        if not isComposite.[i] then
            yield i
            for j in (2 * i)..i..maxValue do
                isComposite.[j] <- true }
assert (Primes 17 |> Seq.toList = [2; 3; 5; 7; 11; 13; 17])
assert (Primes 108801 |> Seq.max = 108799)

let PrimesBig maxValue =
    let addNextPrime previousPrimes candidate =
        let candidateIsNotPrime =
            previousPrimes |> Seq.exists (fun p -> candidate % p = 0L)
        if candidateIsNotPrime then
            previousPrimes
        else
            previousPrimes @ [candidate]
    seq {
        yield 2L
        yield 3L
        yield! seq {12L..6L..(maxValue + 10L)}
        |> Seq.collect (fun v -> [v - 1L; v + 1L])
        |> Seq.filter (fun v -> v <= maxValue)
        |> Seq.fold addNextPrime [5L; 7L] }
assert (PrimesBig 17L |> Seq.toList = [2L; 3L; 5L; 7L; 11L; 13L; 17L])
Print (fun () -> PrimesBig 1000L |> Seq.max |> int) 17
assert (PrimesBig 108801L |> Seq.max = 108799L)

let EulerProblem3() =
    let VALUE = 600851475143L
    let valRoot = int64 (Math.Sqrt(float VALUE)) + 10L
    PrimesBig valRoot |> Seq.rev |> Seq.pick (fun p -> if VALUE % p = 0L then Some(p) else None)

let main() =
    Console.ReadLine() |> ignore
