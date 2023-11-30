

let rec len xs =
    match xs with
    | [] -> 0
    | x::xr -> 1 + len xr;;
    
let rec lenc xs c =
   match xs with
   | [] -> c 0
   | _::xr -> lenc xr (fun res -> c (1 + res))

let exArr = [2;5;7]

let normalLen = len exArr
let cLen = lenc exArr (fun v -> 2 * v)

printf "%d " cLen 
printf "%d " normalLen

let rec leni xs acc =
    match xs with
    | [] -> acc
    | _::xs -> leni xs (acc+1)

printf "%d \n" (leni exArr 0)

let rec rev xs =
    match xs with
    | [] -> []
    | x::xr -> rev xr @ [x]
    
let rec revc xs c =
    match xs with
    | [] -> c []
    | x::xs -> revc xs (fun res -> c (res @ [x]))
    
    
let cRev = revc exArr id
let normalRev = rev exArr

printf "%A " cRev
printf "%A " normalRev
printf "%A " (revc exArr (fun v -> v @ v))

let rec revi xs acc =
    match xs with
    | [] -> acc
    | x::xs -> revi xs (x::acc)


let accRev = revi exArr []

printf "%A " accRev


let rec prodc xs c =
    match xs with
    | [] -> c 1
    | x::xs -> prodc xs (fun res -> c(res * x))
    
let cProd = prodc exArr id

printfn "%d " cProd

// 11.4: not really optimized
let rec prodcOptimized xs c =
    match xs with
    | [] -> c 1
    | x::_ when x=0 -> 0
    | x::xs -> prodcOptimized xs (fun res ->  c(res * x))

// 11.4: actually optimized
let rec prodi xs acc= 
    match xs with
    | [] -> acc
    | x::_ when x=0 -> 0
    | x::xr -> prodi xr (acc*x)
  
  
printfn " %d " (prodcOptimized exArr id)
printfn "%d " (prodi exArr 1)


open Icon;;

// odd 3 to 9
run (Every(Write(Prim("+",Prim("*",CstI 2,FromTo(1,4)),(CstI 1)))))

// 21 22 31 32 41 42
// 2..4 *10 + 1..2
printfn ""
run (Every(Write(Prim("+",Prim("*",FromTo(2,4),(CstI 10)),FromTo(1,2)))))

printfn ""

// 11.8.ii
run (Write(Prim("<",CstI 50,Prim("*",FromTo(0,50),CstI 7))))

printfn ""

// testing sqr 
run (Every(Write(Prim1("sqr",FromTo(3,6)))))


printfn ""

// testing even
run (Every(Write(Prim1("even",FromTo(1,7)))))

// testing multiples

printfn ""

run (Every(Write(Prim1("multiples",(CstI 3)))))
