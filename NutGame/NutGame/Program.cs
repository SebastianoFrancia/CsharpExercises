namespace NutGame
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Game game = new Game("giocatore 1", "giocatore 2");
            string res = game.Play();


            Console.WriteLine(res);
        }


    }
}