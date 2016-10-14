abstract class Subject
{
    public abstract void Request();
}

class RealSubject : Subject
{
    public override void Request(){}
}

class Proxy : Subject
{
    RealSubject realSubject;
    public override void Request()
    {
        if(realSubject == null)
        {
            realSubject = new RealSubject();
        }
        realSubject.Request();
    }
}

class Client
{
    static void Main(string[] args)
    {
        Proxy proxy = new Proxy();
        proxy.Request();
    }
}