// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Define a function to construct a message to print
let part1 () =
    let mutable lastel = System.Int32.MaxValue
    let mutable down_val = 0
    let mutable forward_val = 0
    System.IO.File.ReadLines("test.txt")
    |> Seq.iter (fun s1 ->
        let line = s1.Split ' '
        let op = line.[0]
        let v = line.[1] |> int

        match op with
        | "forward" -> forward_val <- forward_val + v
        | "up" -> down_val <- down_val - v
        | "down" -> down_val <- down_val + v
        | _ -> ()

        printfn "forward is now %d" (forward_val)
        printfn "down is now %d" (down_val)
    )
    printfn "total is %d" (forward_val * down_val)

// Define a function to construct a message to print
let part2 () =
    let mutable lastel = System.Int32.MaxValue
    let mutable down_val = 0
    let mutable forward_val = 0
    let mutable depth = 0
    let mutable aim = 0

    System.IO.File.ReadLines("test.txt")
    |> Seq.iter (fun s1 ->
        let line = s1.Split ' '
        let op = line.[0]
        let v = line.[1] |> int

        match op with
        | "forward" -> 
            forward_val <- forward_val + v
            depth <- depth + aim * v
        | "up" -> 
            down_val <- down_val - v
            aim <- aim - v
        | "down" -> 
            down_val <- down_val + v
            aim <- aim + v
        | _ -> ()

        printfn "forward is now %d" (forward_val)
        printfn "down is now %d" (down_val)
        printfn "aim is now %d" (aim)
    )
    printfn "total is %d" (depth * forward_val)


[<EntryPoint>]
let main argv =
    part2 ()
    0 // return an integer exit code