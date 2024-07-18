using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gioco_di_carte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("inserisci il nome del primo giocatore");
            string nomeGiocatore1= Console.ReadLine();

            Console.WriteLine("inserisci il nome del secondo giocatore");
            string nomeGiocatore2 = Console.ReadLine();

            Partita partita = new Partita(nomeGiocatore1,nomeGiocatore2);
            
            Console.Clear();

            string vincitore = partita.Giocatore1.Nome;
            do
            {
                Console.WriteLine($"-- Briscola:{partita.Briscola} --\n" +
                    $"point {partita.Giocatore1.Nome}: {partita.Giocatore1.PunteggioGiocatore}\n" +
                    $"point {partita.Giocatore1.Nome}: {partita.Giocatore1.PunteggioGiocatore}\n");

                Carta cartaG1;
                int cartaSceltaG1;

                Carta cartaG2;
                int cartaSceltaG2;

                if (vincitore == partita.Giocatore1.Nome)
                {
                    
                    do
                    {
                        Console.WriteLine($"Le carte di {nomeGiocatore1} sono:");
                        for (int i = 0; i < 3; i++)
                        {
                            if (partita.Giocatore1.CarteGiocatore[i] != null)
                            {
                                Console.WriteLine($"Le carta{i}: {partita.Giocatore1.CarteGiocatore[i]}");
                            }
                            else
                            {
                                Console.WriteLine($"Le carta{i}: è gia usata");
                            }
                        }

                        Console.WriteLine("Scegli la carta da lanciare 1 o 2 o 3?");
                        cartaSceltaG1 = int.Parse(Console.ReadLine()) - 1;

                    } while (partita.Giocatore1.CarteGiocatore[cartaSceltaG1] == null);

                    cartaG1 = partita.Giocatore1.SceltaManoGiocatore(cartaSceltaG1);

                    
                    do
                    {
                        Console.WriteLine("Le carte del giocatore 2 sono:");
                        for (int i = 0; i < 3; i++)
                        {
                            if (partita.Giocatore2.CarteGiocatore[i] != null)
                            {
                                Console.WriteLine($"Le carta{i}: {partita.Giocatore2.CarteGiocatore[i]}");
                            }
                            else
                            {
                                Console.WriteLine($"Le carta{i}: è gia usata");
                            }
                        }

                        Console.WriteLine("Scegli la carta da lanciare 1 o 2 o 3?");
                        cartaSceltaG2 = int.Parse(Console.ReadLine()) - 1;

                    } while (partita.Giocatore2.CarteGiocatore[cartaSceltaG2] == null);

                    cartaG2 = partita.Giocatore2.SceltaManoGiocatore(cartaSceltaG2);
                }else
                {
                    do
                    {
                        Console.WriteLine("Le carte del giocatore 2 sono:");
                        for (int i = 0; i < 3; i++)
                        {
                            if (partita.Giocatore2.CarteGiocatore[i] != null)
                            {
                                Console.WriteLine($"Le carta{i}: {partita.Giocatore2.CarteGiocatore[i]}");
                            }
                            else
                            {
                                Console.WriteLine($"Le carta{i}: è gia usata");
                            }
                        }

                        Console.WriteLine("Scegli la carta da lanciare 1 o 2 o 3?");
                        cartaSceltaG2 = int.Parse(Console.ReadLine()) - 1;

                    } while (partita.Giocatore2.CarteGiocatore[cartaSceltaG2] == null);

                    cartaG2 = partita.Giocatore2.SceltaManoGiocatore(cartaSceltaG2);

                    do
                    {
                        Console.WriteLine($"Le carte di {nomeGiocatore1} sono:");
                        for (int i = 0; i < 3; i++)
                        {
                            if (partita.Giocatore1.CarteGiocatore[i] != null)
                            {
                                Console.WriteLine($"Le carta{i}: {partita.Giocatore1.CarteGiocatore[i]}");
                            }
                            else
                            {
                                Console.WriteLine($"Le carta{i}: è gia usata");
                            }
                        }
                        Console.WriteLine("Scegli la carta da lanciare 1 o 2 o 3?");
                        cartaSceltaG1 = int.Parse(Console.ReadLine()) - 1;

                    } while (partita.Giocatore1.CarteGiocatore[cartaSceltaG1] == null);

                    cartaG1 = partita.Giocatore1.SceltaManoGiocatore(cartaSceltaG1);
                }
                Console.Clear();

                if (partita.Mazzo.Carte[partita.Mazzo.Carte.Length - 1] == null && partita.Mazzo.Carte[partita.Mazzo.Carte.Length - 2] == null)
                {
                    vincitore = partita.VincitoreMano(cartaG1, cartaG2);
                    Console.WriteLine($"ha vinto il giocatore {vincitore}");
                }
                else
                {
                    vincitore = partita.VincitoreMano(cartaG1, cartaG2);
                    Console.WriteLine($"ha vinto il giocatore{vincitore}");
                    partita.PescaCarta(vincitore);
                }

                Console.ReadKey();
                Console.Clear();

            } while (partita.Giocatore1.CarteFinite() == false && partita.Giocatore2.CarteFinite() == false);


            Console.WriteLine($"-- {partita.EsitoPartita()}!! --");

        }
        
    }
}