using Assignment01CSharp;

public static class Program
{
    public static void Main()
    {
        Expr e = new Add(new CstI(17), new Var("z"));
        Console.WriteLine(e);

        // 1.4.2

        Expr e1 = new Mul(new Var("x"), new Add(new CstI(7), new Var("y")));
        Console.WriteLine("Expression 1: {0}", e1);

        Expr e2 = new Sub(new CstI(9), new Sub(new Mul(new Var("z"), new CstI(69)), new CstI(7)));
        Console.WriteLine("Expression 2: {0}", e2);

        Expr e3 = new Add(new Var("u"), new Mul(new Add(new CstI(6), new CstI(3)), new Var("i")));
        Console.WriteLine("Expression 3: {0}", e3);

        // 1.4.4

        Expr expressionToBeSimplified = new Sub(new Mul(new Add(new CstI(30), new CstI(0)), new CstI(1)), new CstI(0));
        Console.WriteLine("Before: {0}", expressionToBeSimplified);
        Console.WriteLine("After: {0}", expressionToBeSimplified.Simplify());
    }
}
