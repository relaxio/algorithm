abstract class AbstractClass
{
    public abstract void PrimitiveOperation1();
    public abstract void PrimitiveOperation2();

    public void TemplateMethod()
    {
        PrimitiveOperation1();
        PrimitiveOperation2();
    }
}

class ConcreteClassA : AbstractClass
{
    public override void PrimitiveOperation1(){}
    public override void PrimitiveOperation2(){}
}

class ConcreteClassB : AbstractClass
{
    public override void PrimitiveOperation1(){}
    public override void PrimitiveOperation2(){}
}

class Client
{
    static void Main(string[] args)
    {
        AbstractClass c;
        c = new ConcreteClassA();
        c.TemplateMethod();

        c = new ConcreteClassB();
        c.TemplateMethod();
    }
}