namespace Assignment01CSharp;

public class Add : Binop
{
    public Add(Expr left, Expr right) : base(left, right)
    {
    }

    protected override char Symbol => '+';
}
