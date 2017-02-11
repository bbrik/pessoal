namespace Pessoal

open System


[<AutoOpen>]
module DomainTypes =
    type Categoria =
    | Conta
    | Mercado
    | Restaurante
    | Transporte
    | Outros

    type Movimentacao = {
        Nome:string
        Valor:decimal
        Categoria:Categoria
    }
