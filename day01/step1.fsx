open System
open System.IO

let getValues filePath = 
    File.ReadAllLines(filePath) 
    |> Array.toList
    |> List.map Convert.ToInt32

let countIncrease lst = 
    let compare (count, previous) current =
        if (current > previous) then (count + 1, current)
        else (count, current)

    lst
    |> List.fold compare (0, Int32.MaxValue)
    |> fst

getValues "day01/step1.values" |> countIncrease