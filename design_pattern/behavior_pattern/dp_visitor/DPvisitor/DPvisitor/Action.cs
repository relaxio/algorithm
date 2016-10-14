using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPvisitor
{
    abstract class Action
    {
        public abstract void GetManConclusion(Man concreteElementA);
        public abstract void GetWomanConclusion(Woman concreteElementB);
    }

    class Success : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine("{0}{1}时，背后多半有一个伟大的女人。",
                concreteElementA.GetType().Name, this.GetType().Name);
        }
        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine("{0}{1}时，背后多半有一个不成功的男人。",
                concreteElementB.GetType().Name, this.GetType().Name);
        }
    }
    class Failing : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine("{0}{1}时，闷头喝酒，谁也不用劝。",
                concreteElementA.GetType().Name, this.GetType().Name);
        }
        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine("{0}{1}时，眼泪汪汪，谁也劝不了。",
                concreteElementB.GetType().Name, this.GetType().Name);
        }
    }
    class Amativeness : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine("{0}{1}时，凡事不懂也要装懂。",
                concreteElementA.GetType().Name, this.GetType().Name);
        }
        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine("{0}{1}时，遇事懂也装作不懂。",
                concreteElementB.GetType().Name, this.GetType().Name);
        }
    }
    class Marriage : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine("{0}{1}时，感慨。",
                concreteElementA.GetType().Name, this.GetType().Name);
        }
        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine("{0}{1}时，欣慰。",
                concreteElementB.GetType().Name, this.GetType().Name);
        }
    }
}
