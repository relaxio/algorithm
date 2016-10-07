using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPfacade
{
    class Program
    {
        static void Main(string[] args)
        {
            Fund jijin = new Fund();

            jijin.BuyFund();
            jijin.SellFund();

            Console.Read();
        }
    }
}
