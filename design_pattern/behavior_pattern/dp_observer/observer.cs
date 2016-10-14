abstract class Subject
{
    private IList<Observer> observers new List<Observer>();

    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }

    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach(Observer o in observers)
        {
            o.Update();
        }
    }
}

abstract class Observer
{
    public abstract void Update();
}

class ConcreteSubject : Subject
{
    private string subjectState;

    public string SubjectState
    {
        get { return subjectState; }
        set { subjectState = value; }
    }
}

class ConcreteObserver : Observer
{
    private string name;
    private string observerState;
    private ConcreteSubject subject;

    public ConcreteObserver(ConcreteSubject subject, string name)
    {
        this.subject = subject;
        this.name = name;
    }

    public override void Update()
    {
        observerState = subject.SubjectState;
    }
}

class Client
{
    static void Main(string[] args)
    {
        ConcreteSubject s = new ConcreteSubject();

        s.Attach(new ConcreteObserver(s, "X"));
        s.Attach(new ConcreteObserver(s, "Y"));
        s.Attach(new ConcreteObserver(s, "Z"));

        s.SubjectState = "ABC";
        s.Notify();
    }
}