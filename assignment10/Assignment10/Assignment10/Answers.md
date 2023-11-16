# Assignment 10

## 11.1


### 11.1.i

Implementation can be found in `Program.fs`.

When run, it gives the result `3`.

### 11.1.ii

If we run with `lenc xs (fun v -> 2 *v)`, the result is 6 instead of 3

### 11.1.iii

Implementation can be found in `Program.fs`.
When run, it gives the result `3`.

The relationship between `lenc` and `leni` is that they are both tail recursive to make sure that the stack depth 
is not unnecessarily increased.

## 11.2

Implementation can be found in `Program.fs`.

When run, it gives the result `[7; 5; 2]`.

When run with `(fun v -> v @ v)` it gives the result `[7; 5; 2; 7; 5; 2]`

## 11.3

Implementation can be found in `Program.fs`.

## 11.4

Implementation can be found in `Program.fs`.

## 11.8

### 11.8.i

Implementation can be found in `Program.fs` at line 88.

### 11.8.ii

Implementation can be found in `Icon.fs` at line 94.



