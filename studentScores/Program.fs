// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.IO

let printMeanScore (row: string) =
    let elements = row.Split('\t')
    let name = elements.[0]
    let id = elements.[1]

    let meanScore =
        elements
        |> Array.skip 2
        //|> Array.map float
        |> Array.averageBy float
    //calculate the min and max scores for each student

    printfn "%s	%s	%0.1f" name id meanScore


let getFileCount filePath =
    let rows = File.ReadAllLines filePath
    let studentCount = (rows |> Array.length) - 1 //rows.Length will also work here
    printfn "Total Number of Students is %i" studentCount
    rows |> Array.skip 1 |> Array.iter printMeanScore

[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let filePath = argv.[0]

        if File.Exists filePath then
            printfn "Processing %s " filePath
            getFileCount filePath
            0
        else
            printfn "Invalid file path %s" filePath
            1
    else
        printfn "Please specify a file path"
        1
