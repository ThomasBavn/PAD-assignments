namespace Assignment01CSharp;

public class Sub : Binop
{
    public Sub(Expr left, Expr right) : base(left, right)
    {
    }

    protected override char Symbol => '-';

    public override int Eval(Dictionary<string, int> env)
    {
        return Left.Eval(env) - Right.Eval(env);
    }

    public override Expr Simplify()
    {
        var left = Left.Simplify();
        var right = Right.Simplify();

        if (right is CstI { Value: 0 })
        {
            return left;
        }

        // To avoid implementing value equality we abuse ToString(). Sorry :(
        if (left.ToString() == right.ToString())
        {
            return new CstI(0);
        }

        return new Sub(left, right);
    }
}
