using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPcommand
{
    public abstract class Command
    {
        protected Barbecuer receiver;
        public Command(Barbecuer receiver)
        {
            this.receiver = receiver;
        }

        abstract public void ExcuteCommand();
    }

    class BakeMuttonCommand : Command
    {
        public BakeMuttonCommand(Barbecuer receiver)
            :base(receiver)
        { }
        public override void ExcuteCommand()
        {
            receiver.BakeMutton();
        }
    }

    class BakeChickenWingCommand : Command
    {
        public BakeChickenWingCommand(Barbecuer receiver)
            : base(receiver)
        { }
        public override void ExcuteCommand()
        {
            receiver.BakeChickenWing();
        }
    }

    public class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤羊肉串！");
        }
        public void BakeChickenWing()
        {
            Console.WriteLine("烤鸡翅！");
        }
    }
}
