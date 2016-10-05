abstract class Component
{
    public abstract void Operation();
}

class ConcreteComponent : Component
{
    public override void Operation(){}
}

abstract class Decorator : Component
{
    protected Component component;

    public void SetComponent(Component component)
    {
        this.component = component;
    }

    public override void Operation()
    {
        if(component != null)
        {
            component.Operation();
        }
    }
}

class ConcreteDecoratorA : Decorator
{
    private string addedState;
    public override void Operation()
    {
        base.Operation();
        addedState = "New State";
    }
}

class ConcreteDecoratorB : Decorator
{
    public override void Operation()
    {
        base.Operation();
        AddedBehavior();
    }

    private void AddedBehavior(){}
}

class Client
{
    static void Main(string[] args)
    {
        ConcreteComponent c = new ConcreteComponent();
        ConcreteDecoratorA a = new ConcreteDecoratorA();
        ConcreteDecoratorB b = new ConcreteDecoratorB();

        a.SetComponent(c);
        b.SetComponent(a);
        b.Operation();
        //执行顺序：c.Operation() -> a.Operation() -> b.Operation()
    }
}