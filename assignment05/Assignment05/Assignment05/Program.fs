
let rec merge =
    function
    | xs, [] -> xs
    | [], ys -> ys
    | x::xs, y::ys when x < y -> x::(merge (xs,y::ys))
    | x::xs, y::ys when y < x -> y::(merge ((x::xs), ys))
    | x::xs, y::ys -> x::y::(merge (xs,ys))

let x = merge ([3;5;12], [2;3;4;7])

open ParseAndRun

// Exercise 6.1

let program1 = "
let add x = let f y = x+y in f end
in add 2 5 end
"

let program2 = "
let add x = let f y = x+y in f end
in let addtwo = add 2
    in addtwo 5 end
end
"

let program3 = "
let add x = let f y = x+y in f end
in let addtwo = add 2
    in let x = 77 in addtwo 5 end
    end
end
"

let program4 = "
let add x = let f y = x+y in f end
in add 2 end
"

printfn "Program 1: %d" (run (fromString program1))
printfn "Program 2: %d" (run (fromString program2))
printfn "Program 3: %d" (run (fromString program3))
printfn "Program 4: %d" (run (fromString program4))
