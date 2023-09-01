namespace Assignment01CSharp;

public class Sub : Binop
{
    public Sub(Expr left, Expr right) : base(left, right)
    {
    }

    protected override char Symbol => '-';
}
