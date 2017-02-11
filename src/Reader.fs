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

let parseGrupo (s:string) =
    let s' = s.ToLowerInvariant ()
    match s' with
    | "débito" | "debito" -> Some Debito
    | "mastercard" -> Some Mastercard
    | "visa" -> Some Visa
    | _ -> None

let rowToMov (row:NumbersMovs.Row) =
    let cat = parseCategoria row.Categoria
    let gru = parseGrupo row.Grupo
    let julia = defaultArg row.Julia 0m
    let valor = row.Valor - julia
    Option.Lift2 (fun c g -> Movimentacao.create c g row.Data row.Nome valor) cat gru