namespace coursework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creation of teams
            Team _blu = new Team("Blu", ConsoleColor.Blue, 5);
            Team _red = new Team("Red", ConsoleColor.Red, 5);
            
            int roundLimit = 250, round = 1;
            // Battle
            while (true)
            {
                if (--roundLimit < 0) break;
                Console.WriteLine("\n\n\n\nRound {0}!\n", round++);
                if (_blu.Attack(_red)) break;
                if (_red.Attack(_blu)) break;
            }
            // Results
            _blu.Status();
            _red.Status();
        }
    }
}