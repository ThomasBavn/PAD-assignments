namespace Assignment01CSharp;

public class Mul : Binop
{
    public Mul(Expr left, Expr right) : base(left, right)
    {
    }

    protected override char Symbol => '*';
}
