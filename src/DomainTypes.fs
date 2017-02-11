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
        Data:DateTime
        Nome:string
        Valor:decimal
        Categoria:Categoria
    }