namespace Assignment01CSharp;

public class Var : Expr
{
    public Var(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public override string ToString()
    {
        return Name;
    }

    public override int Eval(Dictionary<string, int> env)
    {
        return env[Name];
    }
}
