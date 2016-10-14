using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPtemplateMethod
{
    class TestPaper
    {
        public void TestQuestion1()
        {
            Console.WriteLine("题目1，题目内容，选项：A.选项 B.选项 C.选项 D.选项");
            Console.WriteLine("答案：" + Answer1());
        }
        public void TestQuestion2()
        {
            Console.WriteLine("题目2，题目内容，选项：A.选项 B.选项 C.选项 D.选项");
            Console.WriteLine("答案：" + Answer2());
        }
        public void TestQuestion3()
        {
            Console.WriteLine("题目3，题目内容，选项：A.选项 B.选项 C.选项 D.选项");
            Console.WriteLine("答案：" + Answer3());
        }

        protected virtual string Answer1()
        {
            return "";
        }
        protected virtual string Answer2()
        {
            return "";
        }
        protected virtual string Answer3()
        {
            return "";
        }
    }

    class TestPaperA : TestPaper
    {
        protected override string Answer1()
        {
            return "b";
        }

        protected override string Answer2()
        {
            return "c";
        }

        protected override string Answer3()
        {
            return "a";
        }
    }

    class TestPaperB : TestPaper
    {
        protected override string Answer1()
        {
            return "c";
        }
        protected override string Answer2()
        {
            return "a";
        }
        protected override string Answer3()
        {
            return "a";
        }
    }
}
