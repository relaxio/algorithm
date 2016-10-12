using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPcomposite
{
    abstract class Company
    {
        protected string name;
        public Company(string name)
        {
            this.name = name;
        }
        public abstract void Add(Company c);
        public abstract void Remove(Company c);
        public abstract void Display(int depth);
        public abstract void LineOfDuty();
    }

    class ConcreteCompany : Company
    {
        private List<Company> children = new List<Company>();
        public ConcreteCompany(string name) : base(name)
        { }
        public override void Add(Company c)
        {
            children.Add(c);
        }
        public override void Remove(Company c)
        {
            children.Remove(c);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            foreach (Company component in children)
            {
                component.Display(depth + 2);
            }
        }
        public override void LineOfDuty()
        {
            foreach (Company component in children)
            {
                component.LineOfDuty();
            }
        }
    }
    class HRDepartment : Company
    {
        public HRDepartment(string name) : base(name)
        { }
        public override void Add(Company c)
        { }
        public override void Remove(Company c)
        { }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 员工招聘培训管理", name);
        }
    }
    class FinanceDepartment : Company
    {
        public FinanceDepartment(string name) : base(name)
        { }
        public override void Add(Company c)
        { }
        public override void Remove(Company c)
        { }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 公司财务收支管理", name);
        }
    }
}
