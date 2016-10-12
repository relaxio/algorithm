using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPmemento
{
    class Program
    {
        static void Main(string[] args)
        {
            GameRole lixiaoyao = new GameRole();
            lixiaoyao.GetInitState();
            lixiaoyao.StateDisplay();

            RoleStateCaretaker stateAdmin = new RoleStateCaretaker();
            stateAdmin.Memento = lixiaoyao.SaveState();

            lixiaoyao.Fight();
            lixiaoyao.StateDisplay();

            lixiaoyao.RecoveryState(stateAdmin.Memento);
            lixiaoyao.StateDisplay();

            Console.Read();
        }
    }
}
