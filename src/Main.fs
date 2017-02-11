module Main

open System
open Expecto
open Pessoal


[<EntryPoint>]
let main argv =

    let movs = Reader.load argv.[0]
    let row = movs.Rows |> Seq.head

    runTestsInAssembly defaultConfig argv |> ignore

    printfn "%A" row
    0