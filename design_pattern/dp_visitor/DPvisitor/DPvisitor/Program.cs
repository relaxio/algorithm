using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPvisitor
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure o = new ObjectStructure();
            o.Attach(new Man());
            o.Attach(new Woman());

            o.Display(new Success());
            o.Display(new Failing());
            o.Display(new Amativeness());
            o.Display(new Marriage());

            Console.Read();
        }
    }
}
