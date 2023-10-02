// For more information see https://aka.ms/fsharp-console-apps

open Parse
open Absyn

let sum = Letfun("sum", ["x";"y";"z"], Prim("+",Var "z",Prim("+", Var "x", Var "y")),Call(Var "sum", [CstI 10; CstI 15;CstI -2]))


printf $@"
Exercise 4.1
5+7
{e1}

let f x = x + 7 in f 2 end
{e2}

let f x = x + 7 in f 2 end
{e3}
"
(*
Exercise 4.1
5+7
Prim ("+", CstI 5, CstI 7)

let f x = x + 7 in f 2 end
Letfun ("f", ["x"], Prim ("+", Var "x", CstI 7), Call (Var "f", [CstI 2]))

let f x = x + 7 in f 2 end
Letfun ("f", ["x"], Prim ("+", Var "x", CstI 7), Call (Var "f", [CstI 2]))
*)

printf $@"
Exercise 4.2:
3**8
{threePowerEight}

3**(0..11)
{threeRaisedToExpSum} 
    
(1..10)**8
{oneToTenExpEight}
"
(*
Exercise 4.2:
3**8
Let
  ("x", CstI 3,
   Letfun
     ("pow", ["n"],
      If
        (Prim ("=", Var "n", CstI 0), CstI 1,
         Prim ("*", Var "x", Call (Var "pow", [Prim ("-", Var "n", CstI 1)]))),
      Call (Var "pow", [CstI 8])))

3**(0..11)
Let
  ("x", CstI 3,
   Letfun
     ("pow", ["n"],
      If
        (Prim ("=", Var "n", CstI 0), CstI 1,
         Prim ("*", Var "x", Call (Var "pow", [Prim ("-", Var "n", CstI 1)]))),
      Letfun
        ("sum", ["m"],
         If
           (Prim ("=", Var "m", CstI 0), CstI 1,
            Prim
              ("+", Call (Var "pow", [Var "m"]),
               Call (Var "sum", [Prim ("-", Var "m", CstI 1)]))),
         Call (Var "sum", [CstI 11])))) 
    
(1..10)**8
Let
  ("exp", CstI 8,
   Letfun
     ("pow", ["x"],
      Letfun
        ("aux", ["n"],
         If
           (Prim ("=", Var "n", CstI 0), CstI 1,
            Prim ("*", Var "x", Call (Var "aux", [Prim ("-", Var "n", CstI 1)]))),
         Call (Var "aux", [Var "exp"])),
      Letfun
        ("sum", ["n"],
         If
           (Prim ("=", Var "n", CstI 1), CstI 1,
            Prim
              ("+", Call (Var "pow", [Var "n"]),
               Call (Var "sum", [Prim ("-", Var "n", CstI 1)]))),
         Call (Var "sum", [CstI 10]))))
*)

printfn $@"
Exercise 4.5 testing

let between min max x = x > min && x < max
    in between 3 6 7 end
{testAnd}

2 < 3 && 2 < 1
{testAndSimple}

let thisOrThat this that x = x=this || x=that
    in thisOrThat 3 6 6 end
{testOr}

false || false
{testOrSimple}
"

(*
Exercise 4.5 testing

let between min max x = x > min && x < max
    in between 3 6 7 end
Letfun
  ("between", ["x"; "max"; "min"],
   If
     (Prim (">", Var "x", Var "min"), Prim ("<", Var "x", Var "max"), CstB false),
   Call (Var "between", [CstI 7; CstI 6; CstI 3]))

2 < 3 && 2 < 1
If (Prim ("<", CstI 2, CstI 3), Prim ("<", CstI 2, CstI 1), CstB false)

let thisOrThat this that x = x=this || x=that
    in thisOrThat 3 6 6 end
Letfun
  ("thisOrThat", ["x"; "that"; "this"],
   If
     (Prim ("=", Var "x", Var "this"), CstB true,
      Prim ("=", Var "x", Var "that")),
   Call (Var "thisOrThat", [CstI 6; CstI 6; CstI 3]))

false || false
If (CstB false, CstB true, CstB false)
*)