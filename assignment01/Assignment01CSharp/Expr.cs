namespace Assignment01CSharp;

public abstract class Expr
{
    public abstract override string ToString();

    public abstract int Eval(Dictionary<string,int> env);

    public abstract Expr Simplify();
}
