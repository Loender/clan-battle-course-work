using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    internal class Archer : Character
    {
        public int ArrowQuantity;
        public Archer(int age, string name, Team team) : base(age, name, "hunter bow", team) 
        {
            ArrowQuantity = 25;
        }
        //Listing what actions are possible at the moment
        public override List<string> GetActions()
        {
            List<string> actions = base.GetActions();
            actions.Add("bow strike");
            if (ArrowQuantity > 0)
            {
                actions.Add("charged shot");
                if (ArrowQuantity > 4)
                {
                    actions.Add("arrow shower");
                }
            }
            return actions;
        }
        protected override void Action(string t, Character target, int Dmg)
        {
            if (t == "arrow shower")
            {
                ArrowQuantity -= 5;
                Dmg = 15;
                target.Hp -= Dmg;
            }
            else if (t == "charged shot")
            {
                ArrowQuantity --;
                Dmg = 9;
                target.Hp -= Dmg;
            }
            else if (t == "bow strike")
            {
                Dmg = 7;
                target.Hp -= Dmg;
            }
            base.Action(t, target, Dmg);
        }
    }
}
