module Main

open System
open Expecto
open Pessoal


[<EntryPoint>]
let main argv =
    // runTestsInAssembly defaultConfig argv
    let movs = Reader.load argv.[0]
    let row = movs.Rows |> Seq.head
    printfn "%A" row
    0