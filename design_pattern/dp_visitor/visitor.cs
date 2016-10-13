abstract class Visitor
{
    public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
    public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
}

class ConcreteVisitor1 : Visitor
{
    public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA)
    {
        //ElementA 被 Visitor1 访问
    }
    public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB)
    {
        //ElementB 被 Visitor1 访问
    }
}

class ConcreteVisitor2 : Visitor
{
    public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA)
    {
        //ElementA 被 Visitor2 访问
    }
    public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB)
    {
        //ElementB 被 Visitor2 访问
    }
}

abstract class Element
{
    public abstract void Accept(Visitor visitor);    
}

class ConcreteElementA : Element
{
    public abstract void Accept(Visitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public void OperationA(){}  //其他相关方法
}

class ConcreteElementB : Element
{
    public abstract void Accept(Visitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public void OperationB(){}  //其他相关方法
}

class ObjectStructure
{
    private IList<Element> elements = new List<Element>();

    public void Attach(Element element)
    {
        elements.Add(element);
    }

    public void Detach(Element element)
    {
        elements.Remove(element);
    }

    public void Accept(Visitor visitor)
    {
        foreach (Element e in elements)
        {
            e.Accept(visitor);
        }
    }
}

class Client
{
    static void Main(string[] args)
    {
        ObjectStructure o = new ObjectStructure();
        o.Attach(new ConcreteElementA());
        o.Attach(new ConcreteElementB());

        o.Accept(new ConcreteVisitor1());
        o.Accept(new ConcreteVisitor2());
    }
}