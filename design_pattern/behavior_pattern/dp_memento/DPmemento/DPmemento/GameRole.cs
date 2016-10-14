using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPmemento
{
    class GameRole
    {
        private int atk;
        private int def;
        private int vit;

        public void StateDisplay()
        {
            Console.WriteLine("角色当前状态：");
            Console.WriteLine("体力：{0}", vit);
            Console.WriteLine("攻击力：{0}", atk);
            Console.WriteLine("防御力：{0}", def);
            Console.WriteLine("");
        }
        public void GetInitState()
        {
            vit = 100; atk = 100; def = 100;
        }
        public void Fight()
        {
            vit = 0; atk = 0; def = 0;
        }
        public RoleStaeMemento SaveState()
        {
            return (new RoleStaeMemento(vit, atk, def));
        }
        public void RecoveryState(RoleStaeMemento memento)
        {
            vit = memento.Vitality;
            atk = memento.Attack;
            def = memento.Defense;
        }

    }

    class RoleStaeMemento
    {
        private int vit;
        private int atk;
        private int def;

        public RoleStaeMemento(int vit, int atk, int def)
        {
            this.vit = vit;
            this.atk = atk;
            this.def = def;
        }

        public int Vitality
        {
            get { return vit; }
            set { vit = value; }
        }
        public int Attack
        {
            get { return atk; }
            set { atk = value; }
        }
        public int Defense
        {
            get { return def; }
            set { def = value; }
        }
    }

    class RoleStateCaretaker
    {
        private RoleStaeMemento memento;
        public RoleStaeMemento Memento
        {
            get { return memento; }
            set { memento = value; }
        }
    }
}
