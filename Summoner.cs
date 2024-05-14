using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    internal class Summoner : Character
    {
        public int SummonedCreatures = 3;
        public int Morale = 70;
        public Summoner(int age, string name, Team team) : base(age, name, "spider staff", team) { }


        //Listing what actions are possible at the moment
        public override List<string> GetActions()
        {
            List<string> actions = base.GetActions();
            actions.Add("summon");
            if(Morale < 50)
                actions.Add("flee");
            if (SummonedCreatures > 0)
            {
                actions.Add("set the spiders on");
            }
            return actions;
        }
        protected override void Action(string t, Character target, int Dmg)
        {
            if (t == "summon")
            {
                SummonedCreatures++;
                Dmg = 0;
                Morale -= 5;
            }
            else if(t == "set the spiders on")
            {
                Morale -= 5;
                Dmg = 10;
                target.Hp -= Dmg;
                SummonedCreatures--;
            }
            else if(Morale < 50 && t == "flee")
            {
                this.Hp = 0;
            }
            base.Action(t, target, Dmg);
        }
    }
}
