class SubSystemOne
{
    public void MethodOne(){}
}

class SubSystemTwo
{
    public void MethodTwo(){}
}

class SubSystemThree
{
    public void MethodThree(){}
}

class SubSystemFour
{
    public void MethodFour(){}
}

class Facade
{
    SubSystemOne one;
    SubSystemTwo two;
    SubSystemThree three;
    SubSystemFour four;

    public Facade()
    {
        one = new SubSystemOne();
        two = new SubSystemTwo();
        three = new SubSystemThree();
        four = new SubSystemFour();
    }

    public void MethodA()
    {
        one.MethodOne();
        two.MethodTwo();
        four.MethodFour();
    }

    public void MethodB()
    {
        two.MethodTwo();
        three.MethodThree();
    }
}

class Client
{
    static void Main(string[] args)
    {
        Facade facade = new Facade();

        facade.MethodA();
        facade.MethodB();
    }
}