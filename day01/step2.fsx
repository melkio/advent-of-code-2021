open System
open System.IO

let getValues filePath = 
    File.ReadAllLines(filePath) 
    |> Array.toList
    |> List.map Convert.ToInt32

let countIncrease lst = 
    let rotateList lst =
        match lst with
        | hd::tl -> tl @ [ hd ]
        | hd -> hd 

    let lst2 = rotateList lst
    let lst3 = rotateList lst2

    let compare (count, previous) current =
        if (current > previous) then (count + 1, current)
        else (count, current)

    List.zip3 lst lst2 lst3
    |> List.map (fun (fst, snd, trd) -> fst + snd + trd)
    |> List.fold compare (0, Int32.MaxValue) 
    |> fst

getValues "day01/step2.values" |> countIncrease 