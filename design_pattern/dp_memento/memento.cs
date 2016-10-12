class Originator
{
    private string state;
    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public Memento CreateMemento()
    {
        return (new Memento(state));
    }

    public void SetMemento(Memento memento)
    {
        state = memento.State;
    }

    public void Show()
    {}
}

class Memento
{
    private string state;

    public Memento(string state)
    {
        this.state = state;
    }

    public string State
    {
        get { return state;}
    }
}

class Caretaker
{
    private Memento memento;

    public Memento Memento
    {
        get { return memento; }
        set { memento = value; }
    }
}

class Client
{
    static void Main(string[] args)
    {
        Originator o = new Originator();
        o.State = "On";
        o.Show();

        Caretaker c = new Caretaker();
        c.Memento = o.CreateMemento();

        o.State = "off";
        o.Show();

        o.SetMemento(c.Memento);
        o.Show();        
    }
}