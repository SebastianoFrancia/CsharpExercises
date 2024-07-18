
namespace MorraCinese
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Inserisci il tu nome:");
            string nome = Console.ReadLine();

            try {
                Console.WriteLine("inserisci il numero di partite che vuoi fare");
                Statistiche statistiche = new Statistiche(Convert.ToInt32(Console.ReadLine()));
            
                Console.Clear();

                Partita[] partita1 = new Partita[statistiche.NumeroPartite];
                for (int i = 0; i < partita1.Length; i++)
                {
                    partita1[i] = new Partita();
                    Console.WriteLine("┌────────────────────────────────────────────────────────────┐\n" +
                                     $"  Partita {statistiche.NumeroPartiteGiocate(partita1)}:\n" + 
                                     $"  Round totali: {statistiche.NumeroRoundGiocati(partita1)}\n");
                    do
                    {
                        Console.WriteLine($"  Round: {partita1[i].NumeroRound}\n" +
                                           "Inserire 0 per sasso 1 per carta 2 per forbice");
                        
                        CasiRound esito = partita1[i].Round(int.Parse(Console.ReadLine()));
                        
                        Console.WriteLine($"  Bot: {partita1[i].Bot.Scelta} \n");

                        if(esito==CasiRound.utente)
                        {
                            Console.WriteLine($"  ---hai vinto {nome}!---");
                        }else
                        {
                            if(esito==CasiRound.bot)
                            {
                                Console.WriteLine("  ---ha vinto il PC!---");
                            }else
                            {
                                Console.WriteLine("  ---Pareggio!---");
                            }
                        }
                        
                        
                        Console.WriteLine($"\n ┌─RoundPoint:──────────────┐  \n" +
                                            $" │{nome}:{partita1[i].Player.RoundViti}                    │ \n" +
                                            $" │PC:{partita1[i].Bot.RoundViti}                      │ \n" +
                                             " └──────────────────────────┘ \n");
                        statistiche.NumeroRoundGiocati(partita1);
                        partita1[i].NumeroRound++;

                    } while (partita1[i].Player.RoundViti < 3 && partita1[i].Bot.RoundViti < 3);

                    if (partita1[i].Player.RoundViti == 3)
                    {
                        Console.WriteLine($"          Hai vinto la partita {nome}! ");
                        statistiche.AggiungiNumeroPartiteVinte(TipologiaGiocatore.Giocatore);
                        partita1[i].VincitorePartita = partita1[i].Player;
                    }
                    else
                    {
                        Console.WriteLine("          Ha vinto il PC la partita! ");
                        statistiche.AggiungiNumeroPartiteVinte(TipologiaGiocatore.Bot);
                        partita1[i].VincitorePartita = partita1[i].Bot;
                    }
                    Console.WriteLine("└────────────────────────────────────────────────────────────┘ \n");

                    Console.ReadKey();
                    Console.Clear();
                }
                
                Console.WriteLine( "\n ┌─Partite───────────────────────────────┐ \n" +
                                    $" │ Hai vinto {statistiche.NumeroPartiteVinte(TipologiaGiocatore.Giocatore)} partite                   │\n"  + 
                                    $" │ il PC ha vinto {statistiche.NumeroPartiteVinte(TipologiaGiocatore.Bot)} partite              │\n" +
                                     " └───────────────────────────────────────┘\n" );
                Console.ReadKey();
                Console.Clear();
                
                int opzione;
                do
                {
                    Console.WriteLine("┌─Statistiche────────────────────────────────────────────────┐\n" +
                                  " Inserire:\n" +
                                  " 1 per sapere chi ha vinto una partita \n" +
                                  " 2 per sapere quanti round ha richiesto una partita e i round medi di tutte le partite\n" +
                                  " 3 per avere le percentuali delle partite vinte dal PC e dal Giocatoren\n" +
                                  " 0 per uscire dalle statistiche");
                    opzione = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine(" ──────────────────────────────────────────────────────────────\n");

                    if(opzione == 1)
                    {
                        Console.WriteLine("inserire il numero della partita per sapere chi ha vinto \n(ricorda le partite iniziano da 0)");
                        Giocatore vincitore = statistiche.VincitorePartitaX(int.Parse(Console.ReadLine()), partita1);
                        
                        if(vincitore.TipoGiocatore == TipologiaGiocatore.Giocatore)
                        {
                            Console.WriteLine($"{nome} ha vinto la partita");
                        }else
                        {
                            Console.WriteLine($"il PC ha vinto la partita");
                        }
                    }else
                    {
                        if(opzione == 2)
                        {
                            statistiche.CalcolaNumeroTotaleRound(partita1);
                            
                            Console.WriteLine("inserire il numero della partita per sapere i suoi round");
                            Console.WriteLine($"sono stati impiegati {statistiche.NumeroRoundPartitaX(int.Parse(Console.ReadLine()), partita1)} round\n" +
                                $"e {statistiche.NumeroRoundMediPerPartita()} round medi per partita");

                        }else
                        {
                            if(opzione == 3)
                            {
                                Console.WriteLine($"il {statistiche.PercentualeVittorie(TipologiaGiocatore.Giocatore)}% delle partite le ha vinte {nome}"+
                                    $" e il restante {statistiche.PercentualeVittorie(TipologiaGiocatore.Bot)}% il Pc");
                                
                            }
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                }while(opzione != 0);

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}