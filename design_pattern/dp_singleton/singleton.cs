class Singleton
{
    private static Singleton instance;

    private Singleton()
    {

    }

    public static Singleton GetInstance()
    {
        if(null == instance)
        {
            instance = new Singleton();
        }
        return instance;
    }
}

class Client
{
    static void Main(string[] args)
    {
        Singleton s1 = Singleton.GetInstance();
        Singleton s2 = Singleton.GetInstance();
        //s1 == s2
    }
}

//多线程加锁
class Singleton
{
    private static Singleton instance;
    private static readonly object syncRoot = new object();

    private Singleton() {}

    public static Singleton GetInstance()
    {
        lock (syncRoot)  //缺点：每次都加锁
        {
            if(null == instance)
            {
                instance = new Singleton();
            }
        }
        return instance;
    }
}

//双重锁定
class Singleton
{
    private static Singleton instance;
    private static readonly object syncRoot = new object();

    private Singleton() {}

    public static Singleton GetInstance()
    {
        if(null == instance)
        {
            lock (syncRoot)
            {
                if(null == instance)
                {
                    instance = new Singleton();
                }
            }
        }
        return instance;
    }
}

//静态初始化（饿汉方式）
public sealed class Singleton
{
    private static readonly Singleton instance = new Singleton();

    private Singleton() {}

    public static Singleton GetInstance()
    {
        return instance;
    }
}