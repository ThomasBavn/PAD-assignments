(* Lexing and parsing of micro-ML programs using fslex and fsyacc *)

module Parse

open System
open System.IO
open System.Text
open (*Microsoft.*)FSharp.Text.Lexing
open Absyn

(* Plain parsing from a string, with poor error reporting *)

let fromString (str : string) : expr =
    let lexbuf = (*Lexing. insert if using old PowerPack *)LexBuffer<char>.FromString(str)
    try
      FunPar.Main FunLex.Token lexbuf
    with
      | exn -> let pos = lexbuf.EndPos
               failwithf "%s near line %d, column %d\n"
                  (exn.Message) (pos.Line+1) pos.Column

(* Parsing from a file *)

let fromFile (filename : string) =
    use reader = new StreamReader(filename)
    let lexbuf = (* Lexing. insert if using old PowerPack *) LexBuffer<char>.FromTextReader reader
    try
      FunPar.Main FunLex.Token lexbuf
    with
      | exn -> let pos = lexbuf.EndPos
               failwithf "%s in file %s near line %d, column %d\n"
                  (exn.Message) filename (pos.Line+1) pos.Column

(* Exercise it *)

let e1 = fromString "5+7";;
let e2 = fromString "let f x = x + 7 in f 2 end";;

(* Examples in concrete syntax *)

let ex1 = fromString
            @"let f1 x = x + 1 in f1 12 end";;

(* Example: factorial *)

let ex2 = fromString
            @"let fac x = if x=0 then 1 else x * fac(x - 1)
              in fac n end";;

(* Example: deep recursion to check for constant-space tail recursion *)

let ex3 = fromString
            @"let deep x = if x=0 then 1 else deep(x-1)
              in deep count end";;

(* Example: static scope (result 14) or dynamic scope (result 25) *)

let ex4 = fromString
            @"let y = 11
              in let f x = x + y
                 in let y = 22 in f 3 end
                 end
              end";;

(* Example: two function definitions: a comparison and Fibonacci *)

let ex5 = fromString
            @"let ge2 x = 1 < x
              in let fib n = if ge2(n) then fib(n-1) + fib(n-2) else 1
                 in fib 25
                 end
              end";;

// Exercise 4.2

let sumThousandToOne = fromString "let sum n = if n = 1 then 1 else n + sum(n - 1) in sum 1000 end";;

let threePowerEight = fromString "let x = 3 in let pow n = if n = 0 then 1 else x * pow(n - 1) in pow 8 end end";;

let threeRaisedToExpSum = fromString "let x = 3
                                          in let pow n = if n = 0 then 1 else x * pow(n - 1)
                                              in let sum m = if m = 0 then 1 else pow(m) + sum(m - 1)
                                                  in sum 11
                                              end
                                          end
                                      end";;

let oneToTenExpEight = fromString "let exp = 8 
                                     in let pow x =
                                       let aux n = if n = 0 then 1 else x * aux(n - 1)
                                         in aux exp
                                       end
                                     in let sum n = if n= 1 then 1 else pow n + sum (n-1)
                                       in sum 10                                                                       
                                         end
                                     end
                                   end";;

let sumTwoArguments = fromString "let sum x y = x + y
                                    in sum 3 4 end"
                                    
let powTwoArguments = fromString "let pow x n =
                                    if n = 0 then 1 else x * pow x (n-1)
                                    in pow 3 (4+1) end"
                                    
let sumThreeArguments = fromString "let sum x y z = x + y + z
                                    in sum 3 4 3 end"


let testAnd =fromString "let between min max x = x > min && x < max
                           in between 3 6 7 end"
                           
                           
let testAndSimple =fromString "2 < 3 && 2 < 1"


let testOr =fromString "let thisOrThat this that x = x=this || x=that
                           in thisOrThat 3 6 6 end" 
                           
let testOrSimple = fromString "false || false"                           
                                                                                            