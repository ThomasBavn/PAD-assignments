# Exercise 7.1

Here is the abstract syntax tree for ex1.c with comments explaining the parts:

```fs
Prog
  [Fundec // Here we declare a function called main taking an argument n (specified next line).
     (None, "main", [(TypI, "n")],
      Block // The function has a code block.
        [Stmt // Here we declare a statement and below we specify that it's a while loop.
           (While
              (Prim2 (">", Access (AccVar "n"), CstI 0), // The condition for the while loop is that n must be greater than the constant 0.
               Block // A code block for the while-loop.
                 [Stmt (Expr (Prim1 ("printi", Access (AccVar "n")))); // Here we make a statement that prints n.
                  Stmt // We wrap the expression below in a statement, because the expression is used as a statement.
                    (Expr
                       (Assign // The expression is an assignment that subtracts the constant 1 from the variable n and assigns the result to n.
                          (AccVar "n", Prim2 ("-", Access (AccVar "n"), CstI 1))))]));
         Stmt (Expr (Prim1 ("printc", CstI 10)))])] // Here we print a newline character. The value 10 is a line feed in ASCII.
```

We run ex9.c with 8 as the argument and get the following output:

```
40320
```

Seems like it calculates factorial.

We then run ex4.c with 10 as the argument and get an array of factorials:

```
1 1 2 6 24 120 720 5040 40320 362880
```
# Exercise 7.2

We write a program that takes two arguments, x and n, and prints the result of x^n
```c
void main(int x, int n){
    pow(x,n);
}

void pow(int x, int n){
    
    int result;
    result=1;
    while (n>0){
        result= result*x;
        n=n-1;
    }
    print result;
}
```
When run with the arguments 3,4 it correctly prints 81.

We write a program that calculates the difference between each adjacent value in an int array. It store these numbers in a new array, and then prints the content of this array.
For this implementation the array that is used is hard coded.
```c
void main(){
    int arr[4];
    *arr=1;
    *(arr+1)=4;
    *(arr+2)=6;
    *(arr+3)=14;
    
    diff(arr, 4);   
}

void diff(int arr[], int len){
    int result[3];
    int count;
    count=0;
    
    while (count<len-1){
        int address1;
        int address2;
        address1= arr + count;
        address2=address1+1;
        
        int diff;
        diff = *address2 - *address1; 
        *(result+count)=diff;
        
        count = count+1;
    }
    printArray(result, len-1);   
}

void printArray(int arr[], int len){
    int count;
    count=0;
    while(count<len){
        print *(arr+count);
        count=count+1;
    }
}
```
When run, it correctly prints "3 2 8"

### Exercise 7.2.1
We write this program for arrsum.
```
void main(){
    int arr[4];
    *arr=7;
    *(arr+1)=13;
    *(arr+2)=9;
    *(arr+3)=8;
   
    int sump;
    sump=0;
    
    arrsum(4,arr,&sump);
    
    print sump;
}

void arrsum(int n, int arr[], int *sump){ 
    int count;
    count=0;
    while (count<n){
        *sump = (*sump)+arr[count];
        count=count+1;
    }
}
```
It correctly prints 37.

### Exercise 7.2.2
We write this program for squares.
```
void main(int n){
    int arr[20];
    
    squares(n,arr);
    
    int sump;
    sump = 0;
    
    arrsum(n,arr,&sump);
    
    print sump;   
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
```
When run with the parameter 5, it correctly prints 30.

### Exercise 7.2.3
We write this program for histogram.
```
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
    
    int count;
    count=0;
    while (count<n){
        freq[ns[count]]=freq[ns[count]]+1;
        count=count+1;
    }
}

void printArray(int arr[], int len){
    int count;
    count=0;
    while(count<len){
        print arr[count];
        count=count+1;
    }
}
```
When running the program using the array from the example in the book ( the array [1, 2, 1, 1, 1, 2, 0]), it correctly prints "1 4 2 0".



# 7.4
We implemented the solution in absyn.fs at line 26 and 27, aswell as in interp.fs at line 197-206.

# 7.5
We implemented the solution in CPar.fsy at line 140 and 141, and in CLex.fsl line 59 and 60.

