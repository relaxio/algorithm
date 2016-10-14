abstract class Flyweight
{
    public abstract void Operation(int extrinsicstate);
}

class ConcreteFlyweight : Flyweight
{
    public override void Operation(int extrinsicstate)
    {
        //由外部状态extrinsicstate控制的具体Flyweight
    }
}

class UnsharedConcreteFlyweight : Flyweight
{
    public override void Operation(int extrinsicstate)
    {
        //由外部状态extrinsicstate控制的具体Flyweight(不共享)
    }
}

class FlyweightFactory
{
    private Hashtable flyweights = new Hashtable();

    public FlyweightFactory()
    {
        /*
        ** flyweights.Add("X", new ConcreteFlyweight());
        ** flyweights.Add("Y", new ConcreteFlyweight());
        ** flyweights.Add("Z", new ConcreteFlyweight());
        */
        // or       

    }

    public Flyweight GetFlyweight(string key)
    {
        // or
        // return ((Flyweight)flyweights[key]);
        // or
        if(!flyweights.ContainsKey(key)){
            flyweights.Add(key, new ConcreteFlyweight());
        }
        return ((Flyweight)flyweights[key]);
    }
}

class Client
{
    static void Main(string[] args)
    {
        int extrinsicstate = 22;

        FlyweightFactory f = new FlyweightFactory();

        Flyweight fx = f.GetFlyweight("X");
        fx.Operation(--extrinsicstate);

        Flyweight fx = f.GetFlyweight("Y");
        fx.Operation(--extrinsicstate);

        Flyweight fx = f.GetFlyweight("Z");
        fx.Operation(--extrinsicstate);

        UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();
        uf.Operation(--extrinsicstate);
    }
}