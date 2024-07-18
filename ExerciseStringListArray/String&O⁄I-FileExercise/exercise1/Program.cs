namespace Esercizio1;
class Program
{
    static void Main(string[] args)
    {
        List<Date> dates = new List<Date>();
        try
        {
            using (StreamReader sr = new StreamReader("DateInput.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    dates.Add(new Date(line));
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        string[] stringDates = new string[dates.Count];
        for(int i=0; i<dates.Count; i++)
        {
            stringDates[i]=dates[i].ToString();
        }
        
        string docPath =Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "DateOutput.txt")))
        {
            foreach (string strin in stringDates)
                outputFile.WriteLine(strin);
        }



                    
    }
}
