using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPobserver
{
    class Program
    {
        static void Main(string[] args)
        {
            Notifier boss = new Notifier();

            StockObserver ts1 = new StockObserver("wgc", boss);
            NBAObserver ts2 = new NBAObserver("ygc", boss);

            //version 1
            //boss.Attach(ts1);
            //boss.Attach(ts2);

            //version 2
            boss.Update += new EventHandler(ts1.CloseStockMarket);
            boss.Update += new EventHandler(ts2.CloseNBADirectSeeding);

            boss.SubjectState = "boss is coming!";
            boss.Notify();

            Console.Read();
        }
    }
}
