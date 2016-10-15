##设计模式design pattern
>好的设计应该做到如下四个方面：可维护、可复用、可扩展以及灵活性好。面向对象设计通过封装、继承、多态把程序的耦合度降低，设计模式的引入使得程序更加灵活，易修改，并且易于复用。

##根据模式的特点可分为三个类别

###创建型模式
>创建模式隐藏了这些类的实例是如何被创建和放在一起的，整个系统关于这些对象所知道的是由抽象类所定义的接口。创建型模式在创建、谁创建、如何被创建、以及何时创建提供了灵活性

* [工厂模式][M01]（包括简单工厂、工厂方法以及抽象工厂）
* [建造者模式][M02]
* [原型模式][M03]
* [单例模式][M04]

###结构型模式

* [适配器模式][M05]
* [桥接模式][M06]
* [组合模式][M07]
* [装饰模式][M08]
* [外观模式][M09]
* [享元模式][M10]
* [代理模式][M11]

###行为模式

* [观察者模式][M12]
* [模板方法模式][M13]
* [命令模式][M14]
* [状态模式][M15]
* [职责链模式][M16]
* [解释器模式][M17]
* [中介者模式][M18]
* [访问者模式][M19]
* [策略模式][M20]  `定义了算法家族，分别封装起来，让它们之间可以相互替换，此模式让算法的变化，不会影响到使用算法的客户。`

* [备忘录模式][M21]
* [迭代器模式][M22]

[M01]:establish_pattern/dp_factory/
[M02]:establish_pattern/dp_builder/
[M03]:establish_pattern/dp_prototype/
[M04]:establish_pattern/dp_singleton/

[M05]:structure_pattern/dp_adapter/
[M06]:structure_pattern/dp_bridge/
[M07]:structure_pattern/dp_composite/
[M08]:structure_pattern/dp_decorator/
[M09]:structure_pattern/dp_facade/
[M10]:structure_pattern/dp_flyweight/
[M11]:structure_pattern/dp_proxy/

[M12]:behavior_pattern/dp_observer/
[M13]:behavior_pattern/dp_templateMethod/
[M14]:behavior_pattern/dp_command/
[M15]:behavior_pattern/dp_state/
[M16]:behavior_pattern/dp_responsibility/
[M17]:behavior_pattern/dp_interpreter/
[M18]:behavior_pattern/dp_mediator/
[M19]:behavior_pattern/dp_visitor/
[M20]:behavior_pattern/dp_strategy/
[M21]:behavior_pattern/dp_memento/
[M22]:behavior_pattern/dp_iterator/
