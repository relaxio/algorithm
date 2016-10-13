using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPresponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonManager jinli = new CommonManager("jl");
            Majordomo zongjian = new Majordomo("zj");
            GeneralManager zongjingli = new GeneralManager("zjl");
            jinli.SetSuperior(zongjian);
            zongjian.SetSuperior(zongjingli);

            Request request = new Request();
            request.RequestType = "请假";
            request.RequestContent = "xx请假";
            request.Number = 1;
            jinli.RequestApplication(request);

            Request request2 = new Request();
            request2.RequestType = "请假";
            request2.RequestContent = "yy请假";
            request2.Number = 4;
            jinli.RequestApplication(request2);

            Request request3 = new Request();
            request3.RequestType = "加薪";
            request3.RequestContent = "yy请求加薪";
            request3.Number = 500;
            jinli.RequestApplication(request3);

            Request request4 = new Request();
            request4.RequestType = "加薪";
            request4.RequestContent = "xx请求加薪";
            request4.Number = 1000;
            jinli.RequestApplication(request4);

            Console.Read();
        }
    }
}
