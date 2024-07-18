namespace DeckItalianCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string namePlayer1="", namePlayer2="";

            bool retry = false;
            do
            {
                try
                {
                    Console.WriteLine("inserisci il nome del primo giocatore");
                    namePlayer1 = Console.ReadLine();

                    Console.WriteLine("inserisci il nome del secondo giocatore");
                    namePlayer2 = Console.ReadLine();

                    if(namePlayer1 == namePlayer2) throw new ArgumentException("the name of the players cannot be the same");
                    if(namePlayer1 == null || namePlayer2 == null) throw new ArgumentException("the name of the player cannot be null");
                    if(namePlayer1 == "" || namePlayer2 == "") throw new ArgumentException("the name of player cannot be empty");
                    retry=false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    retry = true;
                }
            } while (retry);

            Match match = new Match(namePlayer1,namePlayer2);

            Console.Clear();

            string handWinner = match.Player1.Name;
            do
            {
                Console.WriteLine($"-- Briscola:{match.Briscola} --\n" +
                    "Score: \n" +
                    $"{match.Player1.Name}: {match.Player1.Score}\n" +
                    $"{match.Player2.Name}: {match.Player2.Score}\n");

                Card cardPlayer1;
                int choiceCardPlayer1=0;

                

                Card cardPlayer2;
                int choiceCardPlayer2=0;

                

                if(handWinner==match.Player1.Name)
                {
                    retry=false;
                    do
                    {
                        try
                        {
                            Console.WriteLine($"Le carte di {namePlayer1} sono:");
                            for (int i = 0; i < 3; i++)
                            {
                                if (match.Player1.Hand[i] != null)
                                {
                                    Console.WriteLine($"Le carta {i+1}: {match.Player1.Hand[i]}");
                                }
                                else
                                {
                                    Console.WriteLine($"Le carta {i+1}: è gia usata");
                                }
                            }

                            Console.WriteLine("Scegli la carta da lanciare 1 o 2 o 3?");
                            choiceCardPlayer1 = int.Parse(Console.ReadLine()) - 1;

                            if(match.Player1.Hand[choiceCardPlayer1] == null) throw new ArgumentException("the choiced card is null");
                            retry=false;
                        }catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                            retry=true;
                        }
                    } while (retry);
                    cardPlayer1 = match.Player1.PlayerHandChoice(choiceCardPlayer1);

                    retry=false;
                    do
                    {
                        try
                        {
                            Console.WriteLine($"Le carte di {namePlayer2} sono:");
                            for (int i = 0; i < 3; i++)
                            {
                                if (match.Player2.Hand[i] != null)
                                {
                                    Console.WriteLine($"Le carta {i+1}: {match.Player2.Hand[i]}");
                                }
                                else
                                {
                                    Console.WriteLine($"Le carta {i+1}: è gia usata");
                                }
                            }

                            Console.WriteLine("Scegli la carta da lanciare 1 o 2 o 3?");
                            choiceCardPlayer2 = int.Parse(Console.ReadLine()) - 1;

                            if(match.Player2.Hand[choiceCardPlayer2] == null) throw new ArgumentException("the choiced card is null");
                            retry=false;
                        }catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                            retry=true;
                        }
                    } while (retry);

                    cardPlayer2 = match.Player2.PlayerHandChoice(choiceCardPlayer2);
                }else
                {
                    retry=false;
                    do
                    {
                        try
                        {
                            Console.WriteLine($"Le carte di {namePlayer2} sono:");
                            for (int i = 0; i < 3; i++)
                            {
                                if (match.Player2.Hand[i] != null)
                                {
                                    Console.WriteLine($"Le carta{ i+1}: {match.Player2.Hand[i]}");
                                }
                                else
                                {
                                    Console.WriteLine($"Le carta{ i+1}: è gia usata");
                                }
                            }

                            Console.WriteLine("Scegli la carta da lanciare 1 o 2 o 3?");
                            choiceCardPlayer2 = int.Parse(Console.ReadLine()) - 1;

                            if(match.Player2.Hand[choiceCardPlayer2] == null) throw new ArgumentException("the choiced card is null");
                            retry=false;
                        }catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                            retry=true;
                        }
                    } while (retry);

                    cardPlayer2 = match.Player2.PlayerHandChoice(choiceCardPlayer2);

                    retry=false;
                    do
                    {
                        try
                        {
                            Console.WriteLine($"Le carte di {namePlayer1} sono:");
                            for (int i = 0; i < 3; i++)
                            {
                                if (match.Player1.Hand[i] != null)
                                {
                                    Console.WriteLine($"Le carta {i+1}: {match.Player1.Hand[i]}");
                                }
                                else
                                {
                                    Console.WriteLine($"Le carta {i+1}: è gia usata");
                                }
                            }

                            Console.WriteLine("Scegli la carta da lanciare 1 o 2 o 3?");
                            choiceCardPlayer1 = int.Parse(Console.ReadLine()) - 1;

                            if(match.Player1.Hand[choiceCardPlayer1] == null) throw new ArgumentException("the choiced card is null");
                            retry=false;
                        }catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                            retry=true;
                        }
                    } while (retry);
                    cardPlayer1 = match.Player1.PlayerHandChoice(choiceCardPlayer1);

                }
                
                Console.Clear();

                handWinner = match.HandWinner(cardPlayer1, cardPlayer2);
                Console.WriteLine($"{handWinner}");

                if (match.Deck.Cards[match.Deck.Cards.Length - 1] != null && match.Deck.Cards[match.Deck.Cards.Length - 2] != null)
                {
                    
                    match.DrawCard(handWinner);
                }

                Console.ReadKey();
                Console.Clear();

            }while (!match.IsMatchOver);


            Console.WriteLine($"-- {match.MatchOutcome}!! --");
        }
    }
}