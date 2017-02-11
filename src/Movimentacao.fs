module Pessoal.Movimentacao


let create categoria nome valor = {
    Nome=nome
    Valor=valor
    Categoria=categoria
}

let sumByValor movs =
    movs
    |> Seq.sumBy (fun m -> m.Valor)

let sumValoresByCategoria movs =
    movs
    |> Seq.groupBy (fun m -> m.Categoria)
    |> Seq.map (fun (cat, innerMovs) -> (cat, sumByValor innerMovs))
