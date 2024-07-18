using Microsoft.VisualBasic.FileIO;
using System.Net.Mail;

namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmailsStatistics emailStatistics = new EmailsStatistics();
            List<string> wrongEails = new List<string>();
            try
            {
                using (TextFieldParser parser = new TextFieldParser("EmailInput.csv"))
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
                                emailStatistics.Add(new EmailAddress(field));
                            }
                            catch (Exception e)
                            {
                                wrongEails.Add(field);
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Email.txt")))
            {
                foreach (EmailAddress email in emailStatistics.Email)
                    outputFile.WriteLine(email.ToString());
            }


            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WorngEmail.txt")))
            {
                foreach (string strin in wrongEails)
                    outputFile.WriteLine(strin);
            }


            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "emailStatitcs.txt")))
            {
                foreach (string strin in emailStatistics.toStringList())
                    outputFile.WriteLine(strin);
            }
        }
    }
}