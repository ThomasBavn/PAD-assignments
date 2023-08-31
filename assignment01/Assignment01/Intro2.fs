module Assignment01.Intro2

(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)
(* Association lists map object language variables to their values *)

let env = [ ("a", 3); ("c", 78); ("baf", 666); ("b", 111) ]

let emptyenv = [] (* the empty environment *)

let rec lookup env x =
    match env with
    | [] -> failwith (x + " not found")
    | (y, v) :: r -> if x = y then v else lookup r x

let cvalue = lookup env "c"


(* Object language expressions with variables *)

type expr =
    | CstI of int
    | Var of string
    | Prim of string * expr * expr
    | If of expr * expr * expr


let e1 = CstI 17

let e2 = Prim("+", CstI 3, Var "a")

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a")

let e4 = Prim("max", CstI 3, CstI 6)

let e5 = Prim("min", CstI 67, CstI 42)

let e6 = Prim("==", CstI 23, CstI 23)
let e7 = Prim("==", CstI 23, CstI 26)





(* Evaluation within an environment *)

let rec eval e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("max", e1, e2) -> max (eval e1 env) (eval e2 env)
    | Prim("min", e1, e2) -> min (eval e1 env) (eval e2 env)
    | Prim("==", e1, e2) -> if (eval e1 env) = (eval e2 env) then 1 else 0
    | Prim _ -> failwith "unknown primitive"

let e1v = eval e1 env
let e2v1 = eval e2 env
let e2v2 = eval e2 [ ("a", 314) ]
let e3v = eval e3 env

let maxTest = eval e4 env

let minTest = eval e5 env

let eqTestTrue = eval e6 env
let eqTestFalse = eval e7 env

let rec evalPrim e (env: (string * int) list) : int =
    match e with
    | CstI i -> i
    | Var x -> lookup env x
    | If(condition, e1, e2) ->
        if (evalPrim condition env) <> 0 then
            (evalPrim e1 env)
        else
            (evalPrim e2 env)
    | Prim(ope, e1, e2) ->
        let i1 = evalPrim e1 env
        let i2 = evalPrim e2 env
        match ope with
        | "+" -> i1 + i2
        | "-" -> i1 - i2
        | "*" -> i1 * i2
        | "max" -> max i1 i2
        | "min" -> min i1 i2
        | "==" -> if i1 = i2 then 1 else 0
        | _ -> failwith "unknown primitive"
