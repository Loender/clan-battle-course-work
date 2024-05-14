using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    internal class Warrior : Character
    {
        private int rage = 50;
        public Warrior(int age, string name, Team team) : base(age, name, "claymore", team) { }


        //Listing what actions are possible at the moment
        public override List<string> GetActions()
        {
            List<string> actions = base.GetActions();
            if (rage > 8)
            {
                actions.Add("slash");
                if (rage > 14)
                {
                    actions.Add("whirlwind");
                }
            }
            return actions;
        }
        protected override void Action(string t, Character target, int Dmg)
        {
            if (t == "whirlwind")
            {
                rage -= 15;
                Dmg = 15;
                target.Hp -= Dmg;
            }
            if (t == "slash")
            {
                rage -= 9;
                Dmg = 9;
                target.Hp -= Dmg;
            }
            base.Action(t, target, Dmg);
        }
    }
}
