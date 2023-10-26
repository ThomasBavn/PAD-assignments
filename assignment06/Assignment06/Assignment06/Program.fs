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
    int ns[7];
    ns[0]=1;
    ns[1]=2;
    ns[2]=1;
    ns[3]=1;
    ns[4]=1;
    ns[5]=2;
    ns[6]=0;

    int freq[4];


    histogram(7,ns,3,freq);

    printArray(freq,4);
  
}

void histogram(int n, int ns[], int max, int freq[]){

    while (max>=0)
    {
        freq[max]=0;
        max = max-1;
    }
    
    int i;
    for (i=0;i<n;++i){
        freq[ns[i]]=freq[ns[i]]+1;
    }
}

void printArray(int arr[], int len){
    int i;
    for (i=0;i<len;++i){
        print arr[i];
    }
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