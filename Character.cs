namespace coursework
{
    internal abstract class Character
    {
        public bool alive = true;
        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                alive = value > 0;
            }
        }
        private int _hp;
        public int Age
        { get; set; }
        public string Name
        { get; set; }
        public string Weapon
        { get; set; }
        public Team Team { get; }
        public Character(int age, string name, string weapon, Team team)
        {
            Hp = 100;
            this.Age = age; this.Name = name; this.Weapon = weapon;
            Team = team;
        }
        public virtual List<string> GetActions()
        {
            return new List<string>() { string.Empty };
        }
        public void Action(string typeofattack, Character target)
        {
            this.Action(typeofattack, target, 0);
        }
        protected virtual void Action(string typeofattack, Character target, int Dmg)
        {
            string action;
            if (typeofattack == string.Empty)
            {
                Dmg = 5;
                target.Hp -= Dmg;
                action = "simple attack";
            }
            else
            {
                action = typeofattack;
            }
            Console.ForegroundColor = this.Team.Color;
            Console.Write($"{this.Name}");
            Console.ResetColor();
            Console.Write($" aged {this.Age} used {action} on ");
            Console.ForegroundColor = target.Team.Color;
            Console.Write(target.Name);
            Console.ResetColor();
            Console.WriteLine($", dealing {Dmg} damage");
            Console.WriteLine($"({target.Hp + Dmg}->{target.Hp} hp)");
        }
        public override string ToString()
        {
            return $"{Name} the {GetType().Name}: {Age} years of age, {Hp} health points, {Weapon}.";
        }
    }
}
