using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPprototype
{
    class Resume : ICloneable
    {
        private string name;
        private string sex;
        private string age;
        //version 1
        //private string timeArea;
        //private string company;
        //version 2
        private WorkExperience work;
        public Resume(string name)
        {
            this.name = name;
            //version 2
            work = new WorkExperience();
        }

        //version 2
        private Resume(WorkExperience work)
        {
            this.work = (WorkExperience)work.Clone();
        }

        //设置个人信息
        public void SetPersonlInfo(string sex, string age)
        {
            this.sex = sex;
            this.age = age;
        }

        public void SetWorkExperience(string timeArea, string company)
        {
            work.WorkData = timeArea;
            work.Company = company;
        }

        public void Display()
        {
            Console.WriteLine("{0} {1} {2}", name, sex, age);
            Console.WriteLine("工作经历：{0} {1}", work.WorkData, work.Company);
        }
        public object Clone()
        {
            //version 1
            //return (object)this.MemberwiseClone();
            //version 2 在Resume内部可直接访问private成员
            Resume obj = new Resume(this.work);
            obj.name = this.name;
            obj.sex = this.sex;
            obj.age = this.age;
            return obj;
        }
    }

    //version 2
    class WorkExperience : ICloneable
    {
        private string workData;
        public string WorkData
        {
            get { return workData; }
            set { workData = value; }
        }

        private string company;
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
    }
}
