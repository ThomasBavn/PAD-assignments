## Excercise 10.1

### Excercise 10.1.1
ADD: this pops the top 2 values on stack, and pushes the sum to the stack

CSTI i: This takes an integer as an argument, and pushes it to the stack.

NIL: Pushes a nil value to the stack. It is difference from CSTI 0, since nil is not tagged as an integer, but represents a reference to nothing.


IFZERO: This takes an instruction address as an argument.
It pops the the top element of the stack. It checks if it is nil or the integer 0. If it is, it jumps to the given instruction, else it continues execution normally. It is used for comparison checks.

CONS: pops the top 2 elements of the stack, and creates a pointer to a cons cell with these elements( effectively tuple ). It pushes this pointer to the stack.

CAR: Pops the top element of the stack, which should be a pointer to a cons cell. It pushes the first value of the cell to the stack.


SETCAR: Pops the top 2 elements of the stack. The first being a value, the second being a pointer to a cons cell. It sets the first element of the cons cell to the popped value.

### Excercise 10.1.2