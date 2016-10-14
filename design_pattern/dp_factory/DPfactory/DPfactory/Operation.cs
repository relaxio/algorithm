using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPfactory
{
    public class Operation
    {
        private double _numberA = 0;
        private double _numberB = 0;
        public double NumberA
        {
            get
            {
                return _numberA;
            }

            set
            {
                _numberA = value;
            }
        }

        public double NumberB
        {
            get
            {
                return _numberB;
            }

            set
            {
                _numberB = value;
            }
        }

        public virtual double GetResult()
        {
            return 0;
        }        
    }

    class OperationAdd : Operation
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
    class OperationSub : Operation
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
    class OperationMul : Operation
    {
        public override double GetResult()
        {
            return NumberA * NumberB;
        }
    }
    class OperationDiv : Operation
    {
        public override double GetResult()
        {
            if (0 == NumberB)
                throw new Exception("除数不能为0");
            return NumberA / NumberB;
        }
    }

    public class OperationFactory
    {
        public static Operation createOperate(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                case "*":
                    oper = new OperationMul();
                    break;
                case "/":
                    oper = new OperationDiv();
                    break;
            }
            return oper;
        }
    }
}
