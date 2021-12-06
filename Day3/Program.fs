
// iterate through 12 digits, +1 when 1 encountered, -1 when 0 encountered

// in the end, for each column, 1 if > 0, 0 if < 0

// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let rev xs = Seq.fold (fun acc x -> x::acc) [] xs

let fromBinary b =
    let mutable digits = Seq.toList b
    digits <- rev digits
    let mutable result = 0
    let mutable pow = 0
    for d in digits do
        result <- result + (int d - int '0') * pown 2 pow
        pow <- pow + 1
    printfn "result is %A" result
    result

// Define a function to construct a message to print
let part1 () =
    let mutable lastel = System.Int32.MaxValue
    let mutable digit_counts : int array = Array.zeroCreate 12
    System.IO.File.ReadLines("test.txt")
    |> Seq.iter (fun s1 ->
        let digits = Seq.toList s1

        let mutable i = 0
        for d in digits do
            digit_counts.[i] <- digit_counts.[i] + (if int d - int '0' = 0 then -1 else 1)
            i <- i + 1
    )

    printfn "DONE"
    let mutable result = ""
    let mutable result_complement = ""
    for dc in digit_counts do
        result <- result + (if dc > 0 then "1" else "0")
        result_complement <- result_complement + (if dc < 0 then "1" else "0")
    printfn "result is %A" result
    printfn "result_complement is %A" result_complement
    let full_result = fromBinary result
    let full_result_complement = fromBinary result_complement
    printfn "full result is %A" (full_result * full_result_complement)

[<EntryPoint>]
let main argv =
    part1 ()
    //let d = Seq.toList "00101"
    //let r = fromBinary d
    0 // return an integer exit code