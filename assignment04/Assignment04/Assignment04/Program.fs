// For more information see https://aka.ms/fsharp-console-apps

open Parse
open ParseAndRun
open Absyn

let sum = Letfun("sum", ["x";"y";"z"], Prim("+",Var "z",Prim("+", Var "x", Var "y")),Call(Var "sum", [CstI 10; CstI 15;CstI -2]))



printf "%d" (run testOr)
