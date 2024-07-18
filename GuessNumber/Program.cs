
namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Match match;
            Console.WriteLine("Guess a pc-generated number, enter the maximum number that the pc can generate,"
            + "leave blank for default parameters with maximum number 2147483647 and 10 attempts");
            string input = Console.ReadLine();          
            if(input == "")
            {
                match = new Match();
            }else
            {
                int maxNumber = int.Parse(input);
                Console.WriteLine("enter the number of attempts, leave blank for default parameters 10 attempts");
                input = Console.ReadLine();
                if(input == "")
                {
                    match = new Match(maxNumber);
                }else
                {
                    match = new Match(maxNumber, int.Parse(input));
                }
            }
            
            
            TypeOutcomes matchResults = TypeOutcomes.unguessed;
            int value;
            do
            {
                try
                {
                    Console.WriteLine("───────────────────────────── \n" +
                    $"attempt:{match.Tries} \n" + $"try a number:");
                    bool result = int.TryParse(Console.ReadLine(), out value);
                                        
                    if(result)
                    {
                        matchResults = match.attempt(value);
                        Console.WriteLine($"--{matchResults}!--");
                    }else
                    {
                        throw new ArgumentException("you did not enter a possible number");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            } while (matchResults != TypeOutcomes.guess);
        }
    }
}