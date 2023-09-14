open System
open Intcomp1

let sinstrToInt sinstr =
    match sinstr with
    | SCstI x -> [0;x]
    | SVar x -> [1;x]
    | SAdd -> [2]
    | SSub -> [3]
    | SMul -> [4]
    | SPop -> [5]
    | SSwap -> [6]

let rec assemble lst =
    match lst with
    | []->[]
    | x::xs -> (sinstrToInt x) @ (assemble xs)


let test = assemble (scomp e1 [])    
List.map (fun x-> printfn "%i" x) test

intsToFile (assemble (scomp e1 [])) "is1.txt";