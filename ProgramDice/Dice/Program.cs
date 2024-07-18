namespace DiceClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("creo un dado con 30 facce");
            Dice DiceOne = new Dice();
            Dice DiceTow = new Dice();
            int amounts;
            do
            {
                int dadoUnoEstratto = DiceOne.Throw();
                int dadoDueEstratto = DiceTow.Throw();
                amounts = dadoUnoEstratto + dadoDueEstratto;
                Console.WriteLine(amounts);
            } while (amounts != 11);

        }
    }
}