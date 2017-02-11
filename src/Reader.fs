module Pessoal.Reader

open FSharp.Data
open Util


type NumbersMovs = CsvProvider<"NumbersMovSample.csv", ";", 
                                Schema="date,,decimal,,,,decimal option", 
                                Culture="pt-BR">

let parseString s = NumbersMovs.Parse s

let load (uri:string) = NumbersMovs.Load uri

let parseCategoria (s:string) =
    let s' = s.ToLowerInvariant ()
    match s' with
    | "conta" -> Some Conta
    | "mercado" -> Some Mercado
    | "restaurante" -> Some Restaurante
    | "transporte" -> Some Transporte
    | "outros" -> Some Outros
    | _ -> None

let rowToMov (row:NumbersMovs.Row) =
    let categoria = parseCategoria row.Categoria
    let julia = defaultArg row.Julia 0m
    let valor = row.Valor - julia
    categoria
    |> Option.map (fun c -> Movimentacao.create c row.Data row.Nome valor)