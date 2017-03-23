
[返回所有模式的导航页](/design_pattern/)

## 策略模式 Strategy
>定义了算法家族，分别封装起来，让它们之间可以相互替换，此模式让算法的变化，不会影响到使用算法的客户。所有算法完成的都是相同的工作，只是实现不同，调用方式相同，因此减少了各种算法与使用算法之间的耦合。

### Note
>Strategy类层次为Context定义了一系列可重用的算法或行为，继承有助于析取这些算法中的公共功能
>简化单元测试，每个算法都有自己的类，可以通过自己的接口单独测试
>通过多态消除了选择合适行为时的条件语句
>不一定只用来封装算法，可以用来封装几乎任何类型的规则，遇到不同时间应用不同业务规则的场景时考虑使用策略模式的可能性
>不使用简单工厂，选择具体实现的职责由客户端承担，使用简单工厂后，可由客户端转给Context，简单工厂的switch语句后续可使用反射技术消除

### 结构图
![strategy](/design_pattern/_img/strategy_vsd.jpg)

### 伪代码(C#)
```c#
//策略模式
abstract class Strategy{
    //算法方法
    public abstract void AlgorithmInterface();
}
class ConcreteStrategyA : Strategy{
    //算法A实现方法
    public override void AlgorithmInterface(){}
}
class ConcreteStrategyB : Strategy{
    //算法B实现方法
    public override void AlgorithmInterface(){}
}
class ConcreteStrategyC : Strategy{
    //算法C实现方法
    public override void AlgorithmInterface(){}
}
class Context{
    Strategy strategy;
    public Context(Strategy strategy){
        this.strategy = strategy;
    }
    //与简单工厂结合
    public Context(string type){
        switch(type){
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
    public void ContextInterface(){
        strategy.AlgorithmInterface();
    }
}
class Client{
    static void Main(string[] args){
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
```

### 可运行实例

