module Intro2 

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
    | If(condition, e1, e2) ->
        if (eval condition env) <> 0 then
            (eval e1 env)
        else
            (eval e2 env)
    | Var x -> lookup env x
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("max", e1, e2) -> max (eval e1 env) (eval e2 env) // 1.1.1 and down
    | Prim("min", e1, e2) -> min (eval e1 env) (eval e2 env)
    | Prim("==", e1, e2) -> if (eval e1 env) = (eval e2 env) then 1 else 0
    | Prim _ -> failwith "unknown primitive"

let e1v = eval e1 env
let e2v1 = eval e2 env
let e2v2 = eval e2 [ ("a", 314) ]
let e3v = eval e3 env

//1.1.2
let maxTest = eval e4 env

let minTest = eval e5 env

let eqTestTrue = eval e6 env
let eqTestFalse = eval e7 env

// 1.1.3
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

// 1.2.1
type aexpr =
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Sub of aexpr * aexpr
    | Mul of aexpr * aexpr

// 1.2.2
let ae1 = Sub(Var "v",Add(Var "w", Var "z")) // v-(w+z)

let ae2 = Mul(CstI 2,Sub(Var "v",Add(Var "w",Var "z"))) // 2 * (v-(w+z))

let ae3 = Add(Var "x",Add(Var "y", Add(Var "z",Var "v"))) // x+y+z+v

// 1.2.3
let rec fmt =
    function
    | CstI e1 -> e1.ToString()
    | Var e -> e
    | Add (e1,e2) -> $"({fmt e1} + {fmt e2})"
    | Sub (e1,e2) -> $"({fmt e1} - {fmt e2})"
    | Mul (e1,e2) -> $"({fmt e1} * {fmt e2})"

let formatted = fmt ae3
    
let rec simplify =
    function
    | CstI e1 -> CstI e1
    | Var e -> Var e
    | Add (e1,e2) ->
        match (simplify e1 , simplify e2) with
        | e1, CstI 0 -> e1
        | CstI 0, e2 -> e2
        | e1, e2 -> Add (e1, e2)
    | Sub (e1,e2) ->
        match (simplify e1 , simplify e2) with
        | e1, CstI 0 -> e1
        | e1, e2 when e1 = e2 -> CstI 0
        | e1, e2 -> Sub (e1, e2)
    | Mul (e1,e2) ->
        match (simplify e1 , simplify e2) with
        | _, CstI 0 -> CstI 0
        | CstI 0, _ -> CstI 0
        | e1, CstI 1-> e1
        | CstI 1, e2 -> e2
        | e1, e2 -> Mul (e1, e2)  
 
 
let simplifytest = simplify (Mul( Add(CstI 1,CstI 0), Add(Var "x",CstI 0)))   