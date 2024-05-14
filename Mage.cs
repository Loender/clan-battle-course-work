using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    internal class Mage : Character
    {
        public int Mana;
        public Mage(int age, string name, Team team) : base(age, name, "orbital staff", team) 
        {
            Mana = age;
        }
        public override List<string> GetActions()
        {
            List<string> actions = base.GetActions();
            if (Mana > 7)
            {
                actions.Add("lightning strike");
                if (Mana > 9)
                {
                    actions.Add("meteorite");
                }
            }
            return actions;
        }
        protected override void Action(string t, Character target, int Dmg)
        {
            if (t == "meteorite")
            {
                Mana -= 10;
                Dmg = 20;
                target.Hp -= Dmg;
            }
            if (t == "lightning strike")
            {
                Mana -= 8;
                Dmg = 16;
                target.Hp -= Dmg;
            }
            base.Action(t, target, Dmg);
        }
    }
}
