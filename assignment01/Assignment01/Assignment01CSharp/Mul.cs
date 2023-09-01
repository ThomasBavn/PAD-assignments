namespace Assignment01CSharp;

public class Mul : Binop
{
    public Mul(Expr left, Expr right) : base(left, right)
    {
    }

    protected override char Symbol => '*';

    public override int Eval(Dictionary<string,int> env)
    {
        return Left.Eval(env) * Right.Eval(env);
    }

    public override Expr Simplify()
    {
        var left = Left.Simplify();
        var right = Right.Simplify();

        if (right is CstI { Value: 0 })
        {
            return new CstI(0);
        }

        if (left is CstI { Value: 0 })
        {
            return new CstI(0);
        }

        if (right is CstI { Value: 1 })
        {
            return left;
        }

        if (left is CstI { Value: 1 })
        {
            return right;
        }

        return new Mul(left, right);
    }
}
