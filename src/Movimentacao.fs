module Pessoal.Movimentacao


let create categoria grupo data nome valor = {
    Data=data 
    Nome=nome 
    Valor=valor
    Grupo=grupo
    Categoria=categoria
}

let sumByValor movs =
    movs
    |> Seq.sumBy (fun m -> m.Valor)
