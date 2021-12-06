// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

let part1 () =
    let mutable lastel = System.Int32.MaxValue
    let mutable cnt = 0
    System.IO.File.ReadLines("test.txt")
    |> Seq.iter (fun s1 ->
        let i = s1 |> int
        if i > lastel then
            printfn "%d" i
            cnt <- cnt + 1
        lastel <- i
    )
    printfn "total is %d" cnt

let part2 () =
    let mutable lastel = System.Int32.MaxValue
    let mutable windowList = []

    let mutable cnt = 0
    // General idea:
    // - count first 3
    // - iterate through, subtracting first window element and adding next in list
    // - eg.
    // -           2 3 5 8 7 1 9 19 4
    // - start:    s s s
    // - next:       s s s
    //   [ so drop 2, and add 8 in second iteration
    //     since x - 2 + 8 yields a net increase, we add 1 to total
    //     thus algorithm simply needs to
    //     i. compare next in list (n) to first in window (f)
    //     ii. if n > f, add one
    //     iii. slide window ]
    System.IO.File.ReadLines("test.txt")
    |> Seq.iter (fun s1 ->
        windowList <- windowList @ [s1 |> int]
        if windowList.Length > 3 then
            // if last > first, add 1 to total
            if windowList.Item(3) > windowList.Item(0) then
                printfn "%A" windowList
                cnt <- cnt + 1
            windowList <- windowList.Tail
    )
    printfn "btotal is %d" cnt


[<EntryPoint>]
let main argv =
    part2 ()
    0 // return an integer exit code