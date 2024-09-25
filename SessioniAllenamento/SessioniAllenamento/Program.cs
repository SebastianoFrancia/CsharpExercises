using System;
using SessioniAllenamentoLIB;

namespace SessioniAllenamentoCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Atleta atletaUno;
            Atleta atletaDue;
            List<int[]> tempiAtletaUno = new List<int[]>();
            List<int[]> tempiAtletaDue = new List<int[]>();

            Console.WriteLine($"programma per gestire i tempi di sessioni di allenamento di due atleti\n" +
                "─────────────────────────────────────────────────────────────────────");
            try
            {
                bool continua = false;
                int sessioni = 1;

                do
                {
                    Console.WriteLine($"Inserisci il tempo della sessione {sessioni} del Primo atleta");
                    int ore;
                    int minuti;
                    int secondi;

                    Console.Write("Ore: ");
                    ore = int.Parse(Console.ReadLine());
                    
                    Console.Write("Minuti: ");
                    minuti = int.Parse(Console.ReadLine());

                    Console.Write("Secondi: ");
                    secondi = int.Parse(Console.ReadLine());
                    tempiAtletaUno.Add(new int[] { ore, minuti, secondi });

                    Console.Write("inserire [Y] per continuare ad inserire i dati di un altra sessione del Secondo atleta \n[X] per continuare con l'altro atleta \n: ");
                    string input = Console.ReadLine();
                    if (input == "Y") continua = true;
                    else if (input == "X") continua = false;
                    sessioni++;
                } while (continua);

                atletaUno = new Atleta(tempiAtletaUno);

                Console.WriteLine("─────────────────────────────────────────────────────────────────────");
                sessioni = 1;

                do
                {
                    
                    Console.WriteLine($"Inserisci il tempo della sessione {sessioni} del Secondo atleta");
                    int ore;
                    int minuti;
                    int secondi;

                    Console.Write("Ore: ");
                    ore = int.Parse(Console.ReadLine());

                    Console.Write("Minuti: ");
                    minuti = int.Parse(Console.ReadLine());

                    Console.Write("Secondi: ");
                    secondi = int.Parse(Console.ReadLine());
                    tempiAtletaDue.Add(new int[] { ore, minuti, secondi });

                    Console.Write("inserire [Y] per continuare ad inserire i dati di un altra sessione del Secondo atleta \n[X] per continuare con l'altro atleta \n: ");
                    string input = Console.ReadLine();
                    if (input == "Y") continua = true;
                    else if(input == "X") continua = false;
                    sessioni++;

                } while (continua);

                atletaDue = new Atleta(tempiAtletaDue);

                Console.WriteLine("─────────────────────────────────────────────────────────────────────");
                if (atletaUno.MiglioreAllenamentoIntensivo != null && atletaDue.MiglioreAllenamentoIntensivo != null)
                {
                    if (atletaUno.MiglioreAllenamentoIntensivo > atletaDue.MiglioreAllenamentoIntensivo)
                    {
                        Console.WriteLine("il Primo atleta ha il tempo migliore negli allenamenti intensivi");
                    }
                    else
                    {
                        Console.WriteLine("il Secondo atleta ha il tempo migliore negli allenamenti tensivi");
                    }
                }
                if (atletaUno.MiglioreAllenamentoStandard != null && atletaDue.MiglioreAllenamentoStandard != null)
                {
                    if (atletaUno.MiglioreAllenamentoStandard > atletaDue.MiglioreAllenamentoStandard)
                    {
                        Console.WriteLine("il Primo atleta ha il tempo migliore negli allenamenti tensivi");
                    }
                    else
                    {
                        Console.WriteLine("il Secondo atleta ha il tempo migliore negli allenamenti tensivi");
                    }
                }

                if(atletaUno.StessiTempiAllenamenti(atletaDue))
                {
                    Console.WriteLine("gli atleti hanno gli stessi tempi di allenamento");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("─────────────────────────────────────────────────────────────────────");





        }
    }
}