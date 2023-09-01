namespace Assignment01CSharp;

public abstract class Binop : Expr
{
    protected Binop(Expr left, Expr right)
    {
        Left = left;
        Right = right;
    }

    public Expr Left { get; }

    public Expr Right { get; }

    protected abstract char Symbol { get; }

    public override string ToString()
    {
        return $"({Left} {Symbol} {Right})";
    }
}
