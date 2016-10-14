using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPfactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation oper = OperationFactory.createOperate("+");
            oper.NumberA = 1;
            oper.NumberB = 2;
            Console.WriteLine("1 + 2 = {0}", oper.GetResult());

            Console.Read();
        }
    }
}
