module Pessoal.Util


type Option<'a> with
    static member Lift2 f x y =
        match x, y with
        | None, None | None, _ | _, None -> None
        | Some x', Some y' -> Some <| f x' y'

let truncate (maxLen:int) (s:string) =
    if s.Length <= maxLen
    then s
    else s.Substring (0, maxLen)
