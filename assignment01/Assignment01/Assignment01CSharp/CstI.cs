namespace Assignment01CSharp;

public class CstI : Expr
{
    public CstI(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public override string ToString()
    {
        return Value.ToString();
    }
}
