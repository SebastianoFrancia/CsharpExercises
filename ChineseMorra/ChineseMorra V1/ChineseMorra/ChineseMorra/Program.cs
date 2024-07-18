namespace ChineseMorra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("insert the number of rounds");
            int roundsNumber = int.Parse(Console.ReadLine());

            
            bool[] matchWins = new bool[roundsNumber]; 

            for (int i = 0; i < matchWins.Length; i++)
            {
                Match partita = new Match();
                string temp;
                do
                {
                    Console.WriteLine("insert action(rock, paper, scissors)");
                    temp = Console.ReadLine();
                    if (temp == "rock")
                    {
                        partita._player.Action = (TypeAction)0;
                    }
                    else
                    {
                        if (temp == "paper")
                        {
                            partita._player.Action = (TypeAction)1;
                        }
                        else
                        {
                            if (temp == "scissors")
                            {
                                partita._player.Action = (TypeAction)2;
                            }
                            else
                            {
                                throw new ArgumentException("the input is not corect");
                            }
                        }
                    }

                    TypeAction pcAction = partita.PcRound();
                    Console.WriteLine($"Pc:{pcAction} \n" );
                    Console.WriteLine($" --{partita.Winner()}!--");

                    Console.WriteLine($"\n┌─RoundPoint:──────────────┐  \n" +
                                        $"│Player:{partita._player.CounterWins}                  │ \n" +
                                        $"│Pc:{partita._pc.CounterWins}                      │ \n" +
                                         "└──────────────────────────┘ \n");
                    

                } while (partita._player.CounterWins < 3 && partita._pc.CounterWins < 3);

                Console.ReadKey();
                Console.Clear();
                
                if (partita._pc.CounterWins < partita._player.CounterWins) matchWins[i] = true;
                
            }

            string roundWiner;
            for(int i=0; i<matchWins.Length; i++)
            {
                if(matchWins[i] == true) roundWiner = "You";
                else roundWiner = "Pc ";
                Console.WriteLine("┌──────────────────────────┐ \n" +
                                 $"│ Round:{i}     {roundWiner} has won  │ \n" +
                                 $"└──────────────────────────┘");
            }
        }
    }
    
}