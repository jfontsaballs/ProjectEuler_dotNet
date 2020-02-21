module ProjectEuler_FSharp.Primes

open System
open System.Collections.Generic

let UpTo maxValue =
    let isComposite : bool array = Array.zeroCreate (maxValue + 1)
    seq {
        for i = 2 to maxValue do
        if not isComposite.[i] then
            yield i
            for j in (2 * i)..i..maxValue do
                isComposite.[j] <- true }

let UpToBig maxValue =
    let addNextPrime (previousPrimes: List<int64>, candidate) =
        let primeLimit = int64(Math.Sqrt(float(candidate))) + 1L;
        let candidateIsPrime =
            previousPrimes
            |> Seq.takeWhile (fun p -> p < primeLimit)
            |> Seq.exists (fun p -> candidate % p = 0L)
            |> not
        if candidateIsPrime then
            previousPrimes.Add(candidate)
        candidateIsPrime && candidate <= maxValue
    
    let primes = new List<int64>()
    seq {
        yield 2L
        yield 3L
        for i in 6L..6L..(maxValue + 10L) do
            if addNextPrime(primes, i - 1L) then
                yield i - 1L
            if addNextPrime(primes, i + 1L) then
                yield i + 1L
    }
