open System.IO
open System.Text.RegularExpressions
type Command =
    | Forward of int
    | Down of int
    | Up of int

type Position = { X: int; Y: int; }

let apply position command = 
    match command with
        | Forward value -> { position with  X = position.X + value }
        | Down value -> { position with  Y = position.Y + value }
        | Up value -> { position with  Y = position.Y - value }

let getCommands filePath =
    let lineToCommand (line: string) =
        let pattern = "^(forward|up|down) (\\d+)$"
        let matched = Regex.Match(line, pattern)
        let command  = matched.Groups.[1].Value
        let value = int matched.Groups.[2].Value
        match command with
        | "forward" -> Forward value
        | "down" -> Down value
        | "up" -> Up value

    File.ReadAllLines(filePath) 
    |> Array.map lineToCommand

let position = 
    getCommands "day02/step1.values" 
    |> Array.fold apply { X = 0; Y = 0 } 

position.X * position.Y
    