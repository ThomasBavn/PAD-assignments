namespace Assignment01CSharp;

public class Add : Binop
{
    public Add(Expr left, Expr right) : base(left, right)
    {
    }

    protected override char Symbol => '+';

    public override int Eval(Dictionary<string, int> env)
    {
        return Left.Eval(env) + Right.Eval(env);
    }

    public override Expr Simplify()
    {
        var left = Left.Simplify();
        var right = Right.Simplify();

        if (right is CstI { Value: 0 })
        {
            return left;
        }

        if (left is CstI { Value: 0 })
        {
            return right;
        }

        return new Add(left, right);
    }
}
