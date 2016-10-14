using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPmediator
{
    abstract class UnitedNations
    {
        public abstract void Declare(string message, Country colleague);
    }

    abstract class Country
    {
        protected UnitedNations mediator;
        public Country(UnitedNations mediator)
        {
            this.mediator = mediator;
        }
    }

    class USA : Country
    {
        public USA(UnitedNations mediator) : base(mediator) { }
        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }
        public void GetMessage(string message)
        {
            Console.WriteLine("美国获得对方信息：" + message);
        }
    }

    class Iraq : Country
    {
        public Iraq(UnitedNations mediator) : base(mediator) { }

        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }
        public void GetMessage(string message)
        {
            Console.WriteLine("伊拉克获得对方信息：" + message);
        }
    }

    class UnitedNationsSecurityCouncil : UnitedNations
    {
        private USA colleague1;
        private Iraq colleague2;

        public USA Colleague1
        {
            set { colleague1 = value; }
        }
        public Iraq Colleague2
        {
            set { colleague2 = value; }
        }
        public override void Declare(string message, Country colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.GetMessage(message);
            }
            else
            {
                colleague1.GetMessage(message);
            }
        }
    }
}
