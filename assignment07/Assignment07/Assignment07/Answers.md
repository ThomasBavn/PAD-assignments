## Exercise 8.1

### Exercise 8.1.2
The output of running ex11 8 can be found in file ex11output.txt

### Exercise 8.1.2
The instructions and explanation can be found in ex3.decoded and ex5.decoded.
In ex5.decoded it can be seen that there is a nested scope at the line 43, because the stack pointer is decremented to get rid of the inner r variable, when the inner scoped is exited.

The output of running ex3 10 is "0 1 2 3 4 5 6 7 8 9"

## 8.3

We used file `exercise_83.c` to test our PreInc. Changes were also made on line 210 in comp.fs to implement 
the PreInc and PreDec

## 8.4

### Why
`prog1` is very fast since it does not need to store anything in a variable, but can just use the elements directly 
on the stack, meaning the current value is always at the top of the stack, so you don't have to go look through the 
entire stack.

In `ex8` you constantly need to access `bp+1` to get the value of `i` to decrease.

### Ex13 Observations

- When we enter the while loop we first jump to the loop condition at instruction 95.
- If the first part of the `&&` is false, jump to instruction 77 which is past the print statement
- If the first part of the `||` is true, jump to instructino 73, which is the print statement
- If the second part of the `||` is false, jump to instruction 77, which is past the print statement
  - If this is true, continue, hitting the print statement

If the loop condition is true, then jump to the while loop's body at 18.

Description of our observations with more context can be found in `ex13.decoded`

