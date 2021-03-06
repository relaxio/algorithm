abstract class Handler
{
    protected Handler successor;

    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(int request);
}

class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if(request >=0 && request < 10)
        {
            //处理请求
        }
        else if(successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if(request >=10 && request < 20)
        {
            //处理请求
        }
        else if(successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

class ConcreteHandler3 : Handler
{
    public override void HandleRequest(int request)
    {
        if(request >=20 && request < 30)
        {
            //处理请求
        }
        else if(successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

class Client
{
    static void Main(string[] args)
    {
        Handler h1 = new ConcreteHandler1();
        Handler h2 = new ConcreteHandler2();
        Handler h3 = new ConcreteHandler3();
        h1.SetSuccessor(h2);        //职责链的后继
        h2.SetSuccessor(h3);        //职责链的后继

        int[] requests = {2, 5, 14, 22, 18, 3, 27, 20};

        foreach (int request in requests)
        {
            h1.HandleRequest(request);
        }
    }
}