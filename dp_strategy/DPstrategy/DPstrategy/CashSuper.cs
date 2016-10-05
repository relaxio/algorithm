using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPstrategy
{
    //version 3
    abstract class CashSuper
    {
        public abstract double acceptCash(double money);
    }

    class CashNormal : CashSuper
    {
        public override double acceptCash(double money)
        {
            //throw new NotImplementedException();
            return money;
        }
    }

    class CashRebate : CashSuper
    {
        private double moneyRebate = 1d;
        public CashRebate(string moneyRebate)
        {
            this.moneyRebate = double.Parse(moneyRebate);
        }

        public override double acceptCash(double money)
        {
            //throw new NotImplementedException();
            return money * moneyRebate;
        }
    }

    class CashReturn : CashSuper
    {
        private double moneyCondition = 0.0d;
        private double moneyReturn = 0.0d;

        public CashReturn(string moneyCondition, string moneyReturn)
        {
            this.moneyCondition = double.Parse(moneyCondition);
            this.moneyReturn = double.Parse(moneyReturn);
        }
        public override double acceptCash(double money)
        {
            //throw new NotImplementedException();
            double result = money;
            if (money >= moneyCondition)
                result = money - Math.Floor(money / moneyCondition) * moneyReturn;

            return result;
        }
    }
}
