abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
}

class Leaf : Component
{
    public Leaf(string name) : base(name) {}

    public override void Add(Component c) { return; }

    public override void Remove(Component c) { return; }

    public override void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + name);
    }
}

class Composite : Component
{
    private List<Component> children = new List<Component>();

    public Composite(string name) : base(name) {}

    public override void Add(Component c)
    {
        children.Add(c);
    }

    public override void Remove(Component c)
    {
        children.Remove(c);
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + name);

        foreach (Component component in children)
        {
            component.Display(depth + 2);
        }
    }
}

class Client
{
    static void Main(string[] args)
    {
        Composite root = new Composite("root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        Composite comp = new Composite("Composite X");
        comp.Add(new Leaf("Leaf XA"));
        comp.Add(new Leaf("Leaf XB"));

        root.Add(comp);

        Composite comp2 = new Composite("Composite XY")
        comp2.Add(new Leaf("Leaf XYA"));
        comp2.Add(new Leaf("Leaf XYB"));

        comp.Add(comp2);

        root.Add(new Leaf("Leaf C"));
        Leaf leaf = new Leaf("Leaf C");
        root.Add(leaf);
        root.Remove(leaf);

        root.Display(1);
    }
}
/*
** -root
** ---Leaf A
** ---Leaf B
** ---Composite X
** -----Leaf XA
** -----Leaf XB
** -------Composite XY
** ---------Leaf XYA
** ---------Leaf XYB
** ---Leaf C
*/