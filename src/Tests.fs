module Pessoal.Tests

open System
open Expecto


[<Tests>]
let readerTests =
    testList "Testes de leitura de csv" [
        testCase "Ler row csv" <| fun () ->
            let source = "Data;Nome;Valor;Pago;Categoria;Grupo;Julia"
                        + "\n30/12/17;curiosa idade;2.203,00;TRUE;conta;débito;1.101,50"
            let prov = Reader.parseString source
            let actual = prov.Rows |> Seq.head
            Expect.equal actual.Data (new DateTime(2017,12,30)) "Data equals"
            Expect.equal actual.Nome "curiosa idade" "Nome equals"
            Expect.equal actual.Valor 2203m "Valor equals"
            Expect.equal actual.Categoria "conta" "Conta equals"
            Expect.equal actual.Grupo "débito" "Grupo equals"
            Expect.equal actual.Julia (Some 1101.5m) "Grupo equals"

        testCase "Converter row csv em Movimentacao" <| fun () -> 
            let source = "Data;Nome;Valor;Pago;Categoria;Grupo;Julia"
                        + "\n30/12/17;foo;500,00;TRUE;conta;débito;10,00"
            let prov = Reader.parseString source
            let actual = prov.Rows |> Seq.head |> Reader.rowToMov
            let expected = Some <| Movimentacao.create Conta Debito (new DateTime(2017,12,30)) "foo" 490m
            Expect.equal actual expected "row to mov"

        testCase "Converter string em Categoria" <| fun () ->
            let data = [
                "conta", Some Conta
                "mercado", Some Mercado
                "restaurante", Some Restaurante
                "transporte", Some Transporte
                "outros", Some Outros
                "qualquer outra coisa", None
            ]
            for (s, expected) in data do
                let actual = Reader.parseCategoria s
                let format = sprintf "%s = %A" s expected
                Expect.equal actual expected format

        testCase "Converter string em Grupo" <| fun () ->
            let data = [
                "débito", Some Debito
                "debito", Some Debito
                "mastercard", Some Mastercard
                "visa", Some Visa
                "qualquer outra coisa", None
            ]
            for (s, expected) in data do
                let actual = Reader.parseGrupo s
                let format = sprintf "%s = %A" s expected
                Expect.equal actual expected format
    ]

[<Tests>]
let movimentacaoTests =
    testCase "Somar valores de seq de movimentacao" <| fun () ->
        let createDummy = Movimentacao.create Conta Debito DateTime.Now "foo"
        let movs = [
            createDummy 1m
            createDummy 10m
            createDummy 100m
        ]
        let expected = 111m
        let actual = Movimentacao.sumByValor movs
        Expect.equal actual expected "soma igual"

[<Tests>]
let nomesTests = 
    let table = Fixtures.simplifyNomeTable
    let findSimpleMatch = Nomes.findSimpleMatch table
    let simplifyNome = Nomes.simplifyNome table
    testList "Testes de nome" [
        testCase "Achar nome simplificado" <| fun () ->
            let nome = "super zona sul lj 11"
            let expected = Some "zona sul"
            let actual = findSimpleMatch nome
            Expect.equal actual expected "super zona sul lj 11 -> Some zona sul"
        testCase "Não achar nome simplificado" <| fun () ->
            let nome = "fuck"
            let expected = None
            let actual = findSimpleMatch nome
            Expect.equal actual expected "fuck -> None"

        testCase "Simplificar nome" <| fun () ->
            let nome = "super zona sul lj 11"
            let expected = "zona sul"
            let actual = simplifyNome nome
            Expect.equal actual expected "super zona sul lj 11 -> zona sul"
    ]