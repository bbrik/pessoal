module Pessoal.Movimentacao


let create categoria data nome valor = {
    Data=data 
    Nome=nome 
    Valor=valor
    Categoria=categoria
}

let sumByValor movs =
    movs
    |> Seq.sumBy (fun m -> m.Valor)
