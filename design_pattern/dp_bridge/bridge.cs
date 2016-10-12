abstract class Implementor
{
    public abstract void Operation();
}

class ConcreteImplementorA : Implementor
{
    public override void Operation() {}
}

class ConcreteImplementorB : Implementor
{
    public override void Operation() {}
}

class Abstaction
{
    protected Implementor implementor;

    public void SetImplementor(Implementor implementor)
    {
        this.implementor = implementor;
    }

    public virtual void Operation();
    {
        implementor.Operation();
    }
}

class RefinedAbstraction : Abstaction
{
    public override void Operation()
    {
        implementor.Operation();
    }
}

class Client
{
    static void Main(string[] args)
    {
        Abstaction ab = new RefinedAbstraction();

        ab.SetImplementor(new ConcreteImplementorA());
        ab.Operation();

        ab.SetImplementor(new ConcreteImplementorB());
        ab.Operation();
    }
}