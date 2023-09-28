# Exercises 

## Exercise 6.1

``` fsharp
// example
run (fromString @"let twice f = let g x = f(f(x)) in g end
    in let mul3 z = z*3 in twice mul3 2 end end");;
val it : HigherFun.value = Int 18

// 1
let add x = let f y = in add 2 5 end
val it : HigherFun.value = Int 7

// 2
let add x = 
    let f y = in 
        let addtwo = add 2 in addtwo 5 
            end
        end
    end
    
val it : HigherFun.value = Int 7

// 3
let add x = 
    let f y = x+y in f end 
    in let addtwo = add 2 
        in let x= 77 in addtwo 5 end 
        end 
    end
        
val it : HigherFun.value = Int 7
(* Yes it terminates as expected since x has been binded to 2 within the add function at the addtwo definition *)

// 4

let add x = 
    let f y = x+y in f end 
    in add 2 end

val it : HigherFun.value =
  Closure
    ("f", "y", Prim ("+", Var "x", Var "y"),
     [("x", Int 2);
      ("add",
       Closure
         ("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"),
          []))])
(* This is expected since since add x returns a function and the function is not caled, 
  This means the function is the result, since functions are first-class citizens. *)
```

run (fromString "let add x = let f y = x+y in f end in let addtwo = add 2 in addtwo 5 end end")

run (fromString "let add x = let f y = x+y in f end in let addtwo = add 2 in let x= 77 in addtwo 5 end end end");;

run (fromString "let add x = let f y = x+y in f end in add 2 end");;

## Exercise 6.4

1. The type of `f` is polymorphic because `x` is never used.
2. The type of `f` is not polymorphic because of the `if then else`, because `e2` and `e3` must be the same type.

