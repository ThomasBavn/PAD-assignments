# Exercises

## Exercise 3.3

Assuming things should be calculated according to the mathematical hierachy:

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

asdfhaslijdfhsdaf
