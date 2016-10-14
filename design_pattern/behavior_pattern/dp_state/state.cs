abstract class State
{
    public abstract void Handle(Context context);
}

class ConcreteStateA : State
{
    public override void Handle(Context context)
    {
        context.State = new ConcreteStateB();
    }
}

class ConcreteStateB : State
{
    public override void Handle(Context context)
    {
        context.State = new ConcreteStateA();
    }
}

class Context
{
    private State state;
    public Context(State state)
    {
        this.state = state;
    }

    public State State
    {
        get { return state; }
        set { state = value; }
    }

    public void Request()
    {
        state.Handle(this);
    }
}

class Client
{
    static void Main(string[] args)
    {
        Context c = new Context(new ConcreteStateA());

        c.Request();
        c.Request();
        c.Request();
        c.Request();
    }
}