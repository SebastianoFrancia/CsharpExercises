using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureEsercizio2
{
    public class Comune
    {
        private string _nome;
        private List<Temperatura> _temperature;

        public string Nome { get { return _nome; } }

        public Comune(string name, List<Temperatura> temperature)
        {
            _nome = name;
            _temperature = temperature;
        }
        public Comune(string name)
        {
            _nome = name;
            _temperature = new List<Temperatura>();
        }

        public void AaggiungiTemperatura(Temperatura nuovaTemperatura)
        {
            _temperature.Add(nuovaTemperatura);
        }

        /// <summary>
        /// restituisce la temperatura massima del comune
        /// </summary>
        /// <returns></returns>
        public double? TemperaturaMax()
        {
            //se ci sono delle temperature
            if (_temperature.Count > 0)
            {
                //cerco il massimo valore tra le temperature e lo restituisco
                double tempMax = _temperature[0].TemperaturaMedia;
                foreach (Temperatura temperatura in _temperature)
                {
                    if (temperatura.TemperaturaMedia > tempMax)
                    {
                        tempMax = temperatura.TemperaturaMedia;
                    }
                }
                return tempMax;
            }
            return null;
        }

        /// <summary>
        /// restituisce la temperatura media dato l'anno
        /// </summary>
        /// <param name="anno"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public double? TemperaturaInAnnoX(int anno) 
        {
            if (anno < 0 || anno > 3000) throw new ArgumentOutOfRangeException("anno non valido");
            foreach (Temperatura t in _temperature)
            {
                if (anno == t.Anno)
                {
                    return t.TemperaturaMedia;
                }
            }
            return null;
        }

        /// <summary>
        /// verifica se la temperatura anno di un anno estata regisrtata nel comune 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool VerificaPresenzaTemperaturaX(Temperatura t)
        {
            foreach (Temperatura temperature in _temperature)
            {
                if (temperature.Equals(t))
                {
                    return true;
                }
            }
            return false;

        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
