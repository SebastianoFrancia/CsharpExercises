using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PiadinaStend
{
    public class ReadFile
    {
        private string _percorso;
        public ReadFile(string percorso)
        {
            _percorso = percorso;
        }

        public Menu InizializzaMenu()
        {
            Menu menu = new Menu();
            using (StreamReader sr = new StreamReader(_percorso))
            {

                string line;
                Product newProduct;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] elementiLinea = line.Split(",");

                    int id = int.Parse(elementiLinea[0]);
                    string nome = elementiLinea[1];
                    string descrizione = elementiLinea[2];
                    double prezzo = double.Parse(elementiLinea[3]);

                    menu.AddProduct(new Product(id, nome, descrizione, prezzo));

                }
                return menu;
            }
        }
        public int? LastOrderId()
        {
            using (StreamReader sr = new StreamReader(_percorso))
            {
                string lastLine = sr.ReadToEnd();
                if (lastLine != null && lastLine != string.Empty)
                {
                    string[] elements = lastLine.Split(';');
                    string[] idElements = elements[elements.Length - 5].Split(':');
                    //id = int.Parse(elements[elements.Length - 5]);
                    int id = int.Parse(idElements[1]);

                    return id;
                }
            }
            return null;
        }
        public DateTime? LastDateTimeOrder()
        {
            DateTime lastDateTime = new DateTime();
            using (StreamReader sr = new StreamReader(_percorso))
            {
                string lastLine = sr.ReadToEnd();
                if (lastLine != null && lastLine != string.Empty)
                {
                    string[] elements = lastLine.Split(';');

                    string[] dateTime = elements[elements.Length-4].Split(' ');

                    string[] date = dateTime[0].Split('/');
                    string[] time = dateTime[1].Split(':');

                    int year = int.Parse(date[2]);
                    int month = int.Parse(date[1]);
                    int day = int.Parse(date[0]);
                    int hour = int.Parse(time[0]);
                    int minutes = int.Parse(time[1]);
                    int seconds = int.Parse(time[2]);

                    lastDateTime= new DateTime(year, month, day, hour, minutes, seconds);
                    return lastDateTime;
                }
            }
            return null;

        }
    }
}
