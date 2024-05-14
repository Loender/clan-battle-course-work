using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    internal class Rogue : Character
    {
        public int QuantityOfDaggers = 2;
        private int stamina = 100;
        public Rogue(int age, string name, Team team) : base(age, name, "daggers", team) { }

        //Listing what actions are possible at the moment
        public override List<string> GetActions()
        {
            List<string> actions = base.GetActions();
            if (QuantityOfDaggers > 0)
            {
                actions.Add("throw");
                actions.Add("stab");
            }
            return actions;
        }
        protected override void Action(string t, Character target, int Dmg)
        {
            if (QuantityOfDaggers > 0 && t == "throw")
            {
                QuantityOfDaggers--;
                Dmg = 30;
                target.Hp -= Dmg;
            }
            if (QuantityOfDaggers == 1 && t == "stab")
            {
                Dmg = 10;
                target.Hp -= Dmg;
                stamina -= 10;
            }
            if (QuantityOfDaggers == 2 && t == "stab")
            {
                Dmg = 13;
                target.Hp -= Dmg;
                stamina -= 13;
            }
            else
            {
                stamina -= 5;
            }
            base.Action(t, target, Dmg);
        }
    }
}
