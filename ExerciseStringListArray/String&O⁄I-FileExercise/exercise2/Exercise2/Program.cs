using Microsoft.VisualBasic.FileIO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Date> dates = new List<Date>();

            try
            {
                using (TextFieldParser parser = new TextFieldParser("DateInput.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        //per ogni riga
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            //per ogni campo dlimitato da ","
                            try
                            {
                                dates.Add(new Date(field));
                            }catch (Exception ex)
                            {
                                Console.WriteLine($"invalid date: {field}");
                            }
                        }
                    }
                }
            }catch (Exception e)
            {
                try
                {
                    using (StreamReader sr = new StreamReader("DateInput.txt"))
                    {
                        string line;
                        int CountLine = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            CountLine++;
                            try
                            {
                                dates.Add(new Date(line));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"invalid date: {line}  line: {CountLine}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(ex.Message + "\n" + e.Message);
                }
            }

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "DateOutput.txt")))
            {
                foreach (Date date in dates)
                    outputFile.WriteLine(date.ToString());
            }
        }
    }
}