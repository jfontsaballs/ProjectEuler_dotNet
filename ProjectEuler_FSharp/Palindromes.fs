module ProjectEuler_FSharp.Palindromes

open System

let private reverse value =
    let rec reverse_iter(reversed: int, remain: int) =
        if remain > 0 then
            reverse_iter(reversed * 10 + remain % 10, remain / 10)
        else
            reversed
    reverse_iter(0, value)

let IsPalindrome value = 
    value = reverse value
