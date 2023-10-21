open ParseAndRun

// let ex1 = fromFile "ex1.c"
// let ex5 = fromFile "ex5.c"
// let ex11 = fromFile "ex11.c"
// let ex1Res = run (fromFile "ex1.c") [17]
// let ex5Res = run (fromFile "ex5.c")
// let ex11Res = run (fromFile "ex11.c") [8]

// printfn "Ex1:"
// printfn "%A" ex1
// printfn "Ex5:"
// printfn "%A" ex5
// printfn "Ex11:"
// printfn "%A" ex11

let ex ="
void main(){
    int x;
    x = 2;
    int y;
    y = 3 * ++x;
    print y;
    print x;
}
"

run (fromString ex) []

(*
printf "%A" (fromString "
void main(){

int i;
i=0;
while (i<3) {
    print i;
    i = i+1;
}
}
")
*)