abstract class Prototype
{
    private string id;
    public Prototype(string id)
    {
        this.id = id;
    }

    public string ID
    {
        get { return ID; }
    }

    public abstract Prototype Clone();
}

class ConcretePrototype1 : Prototype
{
    public ConcretePrototype1(string id) : base(id)
    {

    }

    public override Prototype Clone()
    {
        //浅复制
        return (Prototype)this.MemberwiseClone();
    }
}

class ConcretePrototype2 : Prototype
{
    private ConcretePrototype1 mb;

    public ConcretePrototype2(string id) : base(id)
    {

    }

    private ConcretePrototype2(ConcretePrototype1 mb)
    {
        this.mb = (ConcretePrototype1)mb.Clone();
    }

    public override Prototype Clone()
    {
        //深复制
        ConcretePrototype2 obj = new ConcretePrototype2(this.mb);
        return obj;
    }
}

class Client
{
    static void Main(string[] args)
    {
        ConcretePrototype2 p2 = new ConcretePrototype2("I");
        ConcretePrototype2 c2 = (ConcretePrototype1)p2.Clone();
    }
}