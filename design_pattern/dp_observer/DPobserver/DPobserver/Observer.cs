using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPobserver
{
    abstract class Observer
    {
        protected string name;
        protected Subject sub;
        public Observer(string name, Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        //version 1
        //public abstract void Update();
    }

    class StockObserver : Observer
    {
        public StockObserver(string name, Subject sub)
            :base(name, sub)
        {
        }

        //version 1
        //public void Update()
        //{
        //    Console.WriteLine("{0} {1} 关闭股票行情，继续工作", sub.SubjectState, name);
        //}

        //version 2
        public void CloseStockMarket()
        {
            Console.WriteLine("{0} {1} 关闭股票行情，继续工作", sub.SubjectState, name);
        }
    }

    class NBAObserver : Observer
    {
        public NBAObserver(string name, Subject sub)
            : base(name, sub)
        {
        }
        //version 1
        //public override void Update()
        //{
        //    Console.WriteLine("{0} {1} 关闭 NBA 直播，继续工作", sub.SubjectState, name);
        //}

        //version 2
        public void CloseNBADirectSeeding()
        {
            Console.WriteLine("{0} {1} 关闭 NBA 直播，继续工作", sub.SubjectState, name);
        }
    }
}
