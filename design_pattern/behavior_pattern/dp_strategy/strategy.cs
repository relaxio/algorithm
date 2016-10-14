//策略模式
abstract class Strategy
{
    //算法方法
    public abstract void AlgorithmInterface();
}

class ConcreteStrategyA : Strategy
{
    //算法A实现方法
    public override void AlgorithmInterface(){}
}

class ConcreteStrategyB : Strategy
{
    //算法B实现方法
    public override void AlgorithmInterface(){}
}

class ConcreteStrategyC : Strategy
{
    //算法C实现方法
    public override void AlgorithmInterface(){}
}

class Context
{
    Strategy strategy;
    public Context(Strategy strategy)
    {
        this.strategy = strategy;
    }

    //与简单工厂结合
    public Context(string type)
    {
        switch(type)
        {
            case "A":
                strategy = new ConcreteStrategyA();
                break;
            case "B":
                strategy = new ConcreteStrategyB();
                break;
            case "C":
                strategy = new ConcreteStrategyC();
                break;
        }
        
    }    

    //上下文接口
    public void ContextInterface()
    {
        strategy.AlgorithmInterface();
    }
}

class Client
{
    static void Main(string[] args)
    {
        Context context;
        context = new Context(new ConcreteStrategyA());
        context.ContextInterface();

        context = new Context(new ConcreteStrategyB());
        context.ContextInterface();

        context = new Context(new ConcreteStrategyC());
        context.ContextInterface();

        //简单工厂
        context = new Context("A" or "B" or "C");
        context.ContextInterface();
    }
}
