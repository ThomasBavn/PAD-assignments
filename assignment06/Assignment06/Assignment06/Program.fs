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
void main(int n){
    int arr[20];
    
    squares(n,arr);
    
    int sump;
    sump = 0;
    
    arrsum(n,arr,&sump);
    
    print sump;   
}

void histogram(int n, int ns[], int max, int freq[]){

    

}

void squares(int n, int arr[]){ 
    int count;
    count=0;
    while (count<n){
       arr[count] = count*count;
       count=count+1;
    }
}

void arrsum(int n, int arr[], int *sump){ 
    int count;
    count=0;
    while (count<n){
        *sump = (*sump)+arr[count];
        count=count+1;
    }
}
"

run (fromFile "excersize7.c") []
