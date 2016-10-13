using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPresponsibility
{
    abstract class Manager
    {
        protected string name;
        protected Manager superior;
        public Manager(string name)
        {
            this.name = name;
        }
        public void SetSuperior(Manager superior)
        {
            this.superior = superior;
        }
        abstract public void RequestApplication(Request request);
    }

    class CommonManager : Manager
    {
        public CommonManager(string name)
            : base(name)
        { }
        public override void RequestApplication(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 2)
            {
                Console.WriteLine("{0}:{1} 数量{2} 被批准",
                    name, request.RequestContent, request.Number);
            }
            else
            {
                if (superior != null)
                {
                    superior.RequestApplication(request);
                }
            }
        }
    }

    class Majordomo : Manager
    {
        public Majordomo(string name)
            : base(name)
        { }
        public override void RequestApplication(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 5)
            {
                Console.WriteLine("{0}:{1} 数量{2} 被批准",
                    name, request.RequestContent, request.Number);
            }
            else
            {
                if (superior != null)
                {
                    superior.RequestApplication(request);
                }
            }
        }
    }
    class GeneralManager : Manager
    {
        public GeneralManager(string name)
            : base(name)
        { }
        public override void RequestApplication(Request request)
        {
            if (request.RequestType == "请假")
            {
                Console.WriteLine("{0}:{1} 数量{2} 被批准",
                    name, request.RequestContent, request.Number);
            }
            else if (request.RequestType == "加薪" && request.Number <= 500)            
            {
                Console.WriteLine("{0}:{1} 数量{2} 被批准",
                    name, request.RequestContent, request.Number);
            }
            else if (request.RequestType == "加薪" && request.Number > 5000)
            {
                Console.WriteLine("{0}:{1} 数量{2} 在说吧",
                    name, request.RequestContent, request.Number);
            }
        }
    }
    class Request
    {
        private string requestType;
        public string RequestType
        {
            get { return requestType; }
            set { requestType = value;}
        }

        private string requestContent;
        public string RequestContent
        {
            get
            {
                return requestContent;
            }

            set
            {
                requestContent = value;
            }
        }
        //ctrl+R -> ctrl+E 快速生成属性
        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        private int number;
    }
}
