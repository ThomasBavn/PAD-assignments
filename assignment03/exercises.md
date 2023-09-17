# Exercises

## Exercise 3.3

Assuming things should be calculated according to the mathematical hierachy:

Given the string `let z = (17) in z + 2 * 3 end EOF`, its derivative is

Sequence of rules:  
`A->F->H->G->C->C->B->E->C`

```
Main => Expr EOF
=> LET NAME EQ Expr IN Expr END EOF
=> LET NAME EQ Expr IN Expr PLUS Expr END EOF
=> LET NAME EQ Expr IN Expr PLUS Expr TIMES Expr END EOF
=> LET NAME EQ Expr IN Expr PLUS Expr TIMES CSTINT END EOF
=> LET NAME EQ Expr IN Expr PLUS CSTINT TIMES CSTINT END EOF
=> LET NAME EQ Expr IN NAME PLUS CSTINT TIMES CSTINT END EOF
=> LET NAME EQ LPAR Expr RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF
=> LET NAME EQ LPAR CSTINT RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF
```

## Exercise 3.7

Test input to ensure correctness.

```
>fromString "let x = 34 in let y = 36 in y ? let z= 70 in z+x ? y+54 : 65 end : 34 end end";;
val it: Absyn.expr =
  Let
    ("x", CstI 34,
     Let
       ("y", CstI 36,
        If
          (Var "y",
           Let
             ("z", CstI 70,
              If
                (Prim ("+", Var "z", Var "x"), Prim ("+", Var "y", CstI 54),
                 CstI 65)), CstI 34)))
```
