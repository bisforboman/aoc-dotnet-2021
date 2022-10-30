open System.IO

let parsedInput = 
    Seq.ofArray (File.ReadAllLines("../largeinput.txt"))
    |> Seq.map System.Int32.Parse
    |> Seq.toList

let increasedMeasurements m = 
    Seq.zip (0 :: m) m
    |> Seq.skip 1
    |> Seq.countBy (fun (x, y) -> x < y)
    |> Seq.toList

printfn "Part1 results: %A" (increasedMeasurements parsedInput)

let slidingWindow =
    Seq.zip3 (0 :: 0 :: parsedInput) (0 :: parsedInput) parsedInput
    |> Seq.skip 2
    |> Seq.map (fun (x, y, z) -> x + y + z)
    |> Seq.toList

printfn "Part2 results: %A" (increasedMeasurements slidingWindow)