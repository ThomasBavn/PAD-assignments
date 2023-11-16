

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
