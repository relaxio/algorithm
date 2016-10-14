abstract class AbstractExpression
{
    public abstract void Interpret(Context context);
}

class TerminalExpression : AbstractExpression
{
    public override void Interpret(Context context)
    {
        //终端解释器
    }
}

class NonterminalExpression : AbstractExpression
{
    public override void Interpret(Context context)
    {
        //非终端解释器
    }
}

class Context
{
    private string input;
    public string input
    {
        get { return input; }
        set { input = value; }
    }

    private string output;
    public string output
    {
        get { return output; }
        set { output = value; }
    }
}

class Client
{
    static void Main(string[] args)
    {
        Context context = new Context();
        IList<AbstractExpression> list = new List<AbstractExpression>();
        list.Add(new TerminalExpression());
        list.Add(new NonterminalExpression());
        list.Add(new TerminalExpression());
        list.Add(new TerminalExpression());

        foreach (AbstractExpression exp in list)
        {
            exp.Interpret(context);
        }
    }
}