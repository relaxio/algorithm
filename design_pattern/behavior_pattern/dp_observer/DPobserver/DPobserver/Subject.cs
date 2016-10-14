using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPobserver
{
    interface Subject
    {
        //version 1
        //void Attach(Observer observer);
        //void Detach(Observer observer);
        void Notify();
        string SubjectState
        {
            get;
            set;
        }
    }
    //version 2
    delegate void EventHandler();
    class Notifier : Subject
    {
        //version 1
        //private IList<Observer> observers = new List<Observer>();
        //private string action;

        //version 2
        public event EventHandler Update;
        private string action;

        public string SubjectState
        {
            get { return action; }

            set { action = value; }
        }
        ////version 1
        //public void Attach(Observer observer)
        //{            
        //    observers.Add(observer);
        //}
        //public void Detach(Observer observer)
        //{
        //    observers.Remove(observer);
        //}

        public void Notify()
        {
            //version 1
            //foreach (Observer o in observers)
            //{
            //    o.Update();
            //}

            //version 2
            Update();
        }
    }
}
