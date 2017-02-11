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

    type Grupo =
    | Debito
    | Mastercard
    | Visa

    type Movimentacao = {
        Data:DateTime
        Nome:string
        Valor:decimal
        Grupo:Grupo
        Categoria:Categoria
    }