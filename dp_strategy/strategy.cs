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

    //与工厂方法结合
    public Context(string type)
    {
        switch(type)
        {
            case A:
                strategy = new ConcreteStrategyA();
                break;
            case B:
                strategy = new ConcreteStrategyB();
                break;
            case C:
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