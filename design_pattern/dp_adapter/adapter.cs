class Target
{
    public virtual void Request()
    {
        //普通请求
    }
}

class Adaptee
{
    public void SpecificRequest()
    {
        //特殊请求
    }
}

class Adapter : Target
{
    private Adaptee adaptee = new Adaptee();

    public override void Request()
    {
        adaptee.SpecificRequest();
    }
}

class Client
{
    static void Main(string[] args)
    {
        Target target = new Adapter();
        target.Request();
    }
}