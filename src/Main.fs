module Main

open System
open Expecto
open Pessoal
open Pessoal.Util


let readFile filename =
    let provider = Reader.load filename
    provider.Rows

let rowsToMovs rows =
    rows
    |> Seq.map Reader.rowToMov
    |> Seq.choose id

let printCoisaValor (coisa, valor) =
    let s = truncate 30 coisa
    printfn "%30s %8.2M" s valor

let printByCategoria movs =
    movs
    |> Movimentacao.sumValoresByCategoria
    |> Seq.map (fun (cat, valor) -> (sprintf "%A" cat, valor))
    |> Seq.iter printCoisaValor

let printByNome movs =
    movs
    |> Movimentacao.sumValoresByNome
    |> Seq.sortByDescending (fun (nome, valor) -> valor)
    |> Seq.iter printCoisaValor


[<EntryPoint>]
let main argv =
    let rows = readFile argv.[0]
    let movs = rowsToMovs rows
    printByCategoria movs
    let total = movs |> Movimentacao.sumByValor
    printfn "----------------------------------------------------------"
    printCoisaValor ("Total", total)
    printfn ""
    printByNome movs

    runTestsInAssembly defaultConfig argv |> ignore
    0
