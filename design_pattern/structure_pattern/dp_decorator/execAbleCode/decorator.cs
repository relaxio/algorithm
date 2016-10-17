using System;
class Person
{
    public Person() { }

    private string name;
    public Person(string name)
    {
        this.name = name;
    }
    public virtual void Show()
    {
        Console.WriteLine("装扮的{0}", name);
    }
}
class Finery : Person
{
    protected Person component;

    public void Decorate(Person component)
    {
        this.component = component;
    }

    public override void Show()
    {
        //base.Show();
        if (component != null)
        {
            component.Show();
        }
    }
}

class TShirts : Finery
{
    public override void Show()
    {
        Console.Write("大T恤 ");
        base.Show();
    }
}

class BigTrouser : Finery
{
    public override void Show()
    {
        Console.Write("垮裤 ");
        base.Show();
    }
}

class Sneakers : Finery
{
    public override void Show()
    {
        Console.Write("破球鞋 ");
        base.Show();
    }
}

class Suit : Finery
{
    public override void Show()
    {
        Console.Write("西装 ");
        base.Show();
    }
}
class Tie : Finery
{
    public override void Show()
    {
        Console.Write("领带 ");
        base.Show();
    }
}

class LeatherShoes : Finery
{
    public override void Show()
    {
        Console.Write("皮鞋 ");
        base.Show();
    }
}
class Client
{
    static void Main(string[] args)
    {
          Person xc = new Person("小菜");

          Console.WriteLine("\n第一种装扮：");

          Sneakers pqx = new Sneakers();
          BigTrouser kk = new BigTrouser();
          TShirts dtx = new TShirts();

          pqx.Decorate(xc);
          kk.Decorate(pqx);
          dtx.Decorate(kk);
          dtx.Show();

          Console.WriteLine("\n第二种装扮：");
          LeatherShoes px = new LeatherShoes();
          Tie ld = new Tie();
          Suit xz = new Suit();

          px.Decorate(xc);
          ld.Decorate(px);
          xz.Decorate(ld);
          xz.Show();

          Console.Read();
    }
}