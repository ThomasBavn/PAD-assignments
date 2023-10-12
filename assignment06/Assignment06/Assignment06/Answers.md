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
