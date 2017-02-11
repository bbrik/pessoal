module Pessoal.Nomes

open System.Text.RegularExpressions


let isMatch pat s =
    let m = Regex.Match(s, pat, RegexOptions.IgnoreCase)
    m.Success

let findSimpleMatch table nome =
    table
    |> Seq.tryFind (fun (pat, _) -> isMatch pat nome)
    |> Option.map (fun (_, out) -> out)

let simplifyNome table nome =
    match findSimpleMatch table nome with
    | Some n -> n
    | None -> nome