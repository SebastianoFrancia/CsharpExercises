using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureEsercizio2
{
    public class ISTAT
    {
        private List<Comune> _dati ;

        public List<Comune> Comuni 
        { 
            get { return _dati; } 
        }

        public void ImpostaDatiDaFile(string percorsoFile)
        {
            _dati = new List<Comune>();

            try{
                using (StreamReader sr = new StreamReader(percorsoFile))
                {
                    //CultureInfo.CurrentCulture = new CultureInfo("en-US");
                    
                    string primaLinea = sr.ReadLine();
                    string[] anni = primaLinea.Split(';'); 
                    
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] elementiLinea = line.Split(";");
                        Comune comune = new Comune(elementiLinea[0]);

                        for(int i = 1; i < elementiLinea.Length; i++)
                        {
                            int anno = int.Parse(anni[i]);
                            if(double.TryParse(elementiLinea[i], out double temperatura))
                            {
                                comune.AaggiungiTemperatura(new Temperatura(anno, temperatura));
                            }
                        }
                        _dati.Add(comune);
                        
                    }
                }
            }
            catch (Exception ex) { }
        }

        public List<string> ListaNomiComuniConTemperaturaInAnno(Temperatura t)
        {
            List<string> values= new List<string>();
            foreach(Comune comune in _dati)
            {
                if(comune.VerificaPresenzaTemperaturaX(t) == true)
                {
                    values.Add(comune.Nome);
                }
            }
            return values;

        }
        
        public double? CercaTemperaturaMassiamComune(string nomeComune)
        {
            foreach(Comune comune in _dati)
            {
                if(comune.Nome == nomeComune )
                {
                    return comune.TemperaturaMax();
                }
            }
            return null;
        }

        public double? TemperatureaMaggioreAnno(int anno)
        {
            double? MaxTemperaturaAnno= double.MinValue;
            foreach (Comune comune in _dati)
            {
                double? temp = comune.TemperaturaInAnnoX(anno);
                if( temp!=null && temp > MaxTemperaturaAnno )
                {
                    MaxTemperaturaAnno = temp;
                }
            }
            if(MaxTemperaturaAnno == double.MinValue)
            {
                return null;
            }
            return MaxTemperaturaAnno;
        }

        public List<string> Comune_iTemperaturaMassimaAnno(int anno)
        {
            double? temperaturaMaxInAnno = TemperatureaMaggioreAnno(anno);
            List<string> comune_i = new List<string>();
            if(temperaturaMaxInAnno != null)
            {
                foreach (Comune comune in _dati)
                {
                    if(comune.TemperaturaInAnnoX(anno) == temperaturaMaxInAnno)
                    {
                        comune_i.Add(comune.Nome);
                    }
                }
                return comune_i;
            }
            throw new Exception("i dati sono nulli");
            
        }

        public double? TemperatureaMinoreAnno(int anno)
        {
            double? MinTemperaturaAnno = double.MaxValue;
            foreach (Comune comune in _dati)
            {
                double? temp = comune.TemperaturaInAnnoX(anno);
                if (temp != null && temp < MinTemperaturaAnno)
                {
                    MinTemperaturaAnno = temp;
                }
            }
            if (MinTemperaturaAnno == double.MaxValue)
            {
                return null;
            }
            return MinTemperaturaAnno;
        }
        public List<string> Comune_iTemperaturaMinimaAnno(int anno)
        {
            double? temperaturaMinInAnno = TemperatureaMinoreAnno(anno);
            List<string> comune_i = new List<string>();
            if (temperaturaMinInAnno != null)
            {
                foreach (Comune comune in _dati)
                {
                    if (comune.TemperaturaInAnnoX(anno) == temperaturaMinInAnno)
                    {
                        comune_i.Add(comune.Nome);
                    }
                }
                return comune_i;
            }
            throw new Exception("i dati sono nulli");

        }

        public double TemperaturaMediaAnno(int anno) 
        {
            double somma = 0;
            int count = 0;
            double? temperaturaMaggiore = TemperatureaMaggioreAnno(anno);
            double? temperaturaMinore = TemperatureaMinoreAnno(anno);
            if (temperaturaMaggiore == null && temperaturaMinore == null) throw new Exception("i dati sono nulli");
            return ((double)temperaturaMaggiore+(double)temperaturaMinore) / 2;
        }

    }
}
