using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPprototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Resume a = new Resume("A");
            a.SetPersonlInfo("男", "29");
            a.SetWorkExperience("1998-2000", "xx公司");

            Resume b = (Resume)a.Clone();
            b.SetWorkExperience("1998-2006", "YY企业");

            Resume c = (Resume)a.Clone();
            c.SetPersonlInfo("男", "24");

            a.Display();
            b.Display();
            c.Display();

            Console.Read();
        }
    }
}
