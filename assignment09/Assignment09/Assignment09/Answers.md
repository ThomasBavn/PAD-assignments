# Assignment 9

## Exercise 10.1

### Exercise 10.1.1
ADD: this pops the top 2 values on stack, and pushes the sum to the stack

CSTI i: This takes an integer as an argument, and pushes it to the stack.

NIL: Pushes a nil value to the stack. It is difference from CSTI 0, since nil is not tagged as an integer, but represents a reference to nothing.


IFZERO: This takes an instruction address as an argument.
It pops the the top element of the stack. It checks if it is nil or the integer 0. If it is, it jumps to the given instruction, else it continues execution normally. It is used for comparison checks.

CONS: pops the top 2 elements of the stack, and creates a pointer to a cons cell with these elements( effectively tuple ). It pushes this pointer to the stack.

CAR: Pops the top element of the stack, which should be a pointer to a cons cell. It pushes the first value of the cell to the stack.


SETCAR: Pops the top 2 elements of the stack. The first being a value, the second being a pointer to a cons cell. It sets the first element of the cons cell to the popped value.

### Exercise 10.1.2
Length: Gets the length the data that the header is attached to.
Color: Gets the color of the header.
Paint: Takes a header and a color as an argument, 
and returns a copy of the header, but with the color set to the color argument.

### Exercise 10.1.3
The allocate() function is called when a new cons cell is created.

### Exercise 10.1.4
The collect() function is called if allocate() is called, and there can't be 
found any space for the cons cell that is to be allocated.


## 10.2

We implemented the garbage collector. The solution can be found in `listmachine.c` using the functions `mark()`, `mark_phase()`.

```
ListVM git:(main) ./listmachine ../../ex35.out
33 33 Heap: 333 blocks (666 words); of which 0 free (0 words, largest 0 words); 1 orphans
Heap: 168 blocks (831 words); of which 165 free (825 words, largest 5 words); 1 orphans
44 44
Used 0 cpu milli-seconds

ListVM git:(main) ./listmachine ../../ex36.out
1 Heap: 333 blocks (666 words); of which 0 free (0 words, largest 0 words); 1 orphans
Heap: 168 blocks (831 words); of which 166 free (827 words, largest 5 words); 1 orphans
1
Used 0 cpu milli-seconds
```

## 10.3

We implemented the optimizations in the `sweepPhase()` at line 650. 
We actually a slowdown reaching 1ms instead of 0ms on `ex35` and `ex36`, however when we ran `ex30 10000`, we reached a speedup from 7ms down to 5ms


