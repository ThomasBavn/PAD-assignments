
let rec merge =
    function
    | xs, [] -> xs
    | [], ys -> ys
    | x::xs, y::ys when x < y -> x::(merge (xs,y::ys)) 
    | x::xs, y::ys when y < x -> y::(merge ((x::xs), ys))
    | x::xs, y::ys -> x::y::(merge (xs,ys))
 
let x = merge ([3;5;12], [2;3;4;7])

