namespace coursework
{
    internal class Team
    {
        string Name;
        public ConsoleColor Color { get; set; }
        Random rand;
        List<Character> team;

        /// <summary>
        /// Creates a team
        /// </summary>
        /// <param name="name">The name of the team</param>
        /// <param name="color">Color of the team</param>
        /// <param name="num">Size of the team</param>
        public Team(string name, ConsoleColor color, int num)
        {
            Name = name;
            Color = color;
            rand = new Random();
            team = new List<Character>();
            for (int i = 0; i < num; i++)
            {
                switch (rand.Next() % 5)
                {
                    case 0:
                        team.Add(new Archer(rand.Next(82) + 18, name + " Archer " + (i + 1), this));
                        break;
                    case 1:
                        team.Add(new Mage(rand.Next(82) + 18, name + " Mage " + (i + 1), this));
                        break;
                    case 2:
                        team.Add(new Rogue(rand.Next(82) + 18, name + " Rogue " + (i + 1), this));
                        break;
                    case 3:
                        team.Add(new Summoner(rand.Next(82) + 18, name + " Summoner " + (i + 1), this));
                        break;
                    case 4:
                        team.Add(new Warrior(rand.Next(82) + 18, name + " Warrior " + (i + 1), this));
                        break;
                }
            }
        }
        /// <summary>
        /// Battle between the teams
        /// </summary>
        /// <param name="opponent">The enemy team</param>
        /// <returns>Victory</returns>
        public bool Attack(Team opponent)
        {
            List<string> actions;
            List<Character> targets;
            foreach (Character c in team.Where(c => c.alive))
            {
                actions = c.GetActions();
                targets = opponent.team.Where(c => c.alive).ToList();
                Thread.Sleep(150);
                if (targets.Count == 0) break;
                c.Action(actions[rand.Next(actions.Count)], targets[rand.Next(targets.Count)]);
            }
            if (opponent.team.All(c => !c.alive))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\n"+ Name + " win!\n");
                Console.ResetColor();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Outputs the status of a team at the end of the battle
        /// </summary>
        public void Status()
        {
            Console.WriteLine(Name + " team:");
            Console.ForegroundColor = Color;
            foreach (Character c in team)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}