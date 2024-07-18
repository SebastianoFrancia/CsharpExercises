using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureEsercizio2
{
    public class Temperatura
    {
        private int _anno;
        private double _temperaturaMediaCelsius;

        public int Anno 
        { 
            get {  return _anno; }
            private set 
            {
                if (value < 0 && value > 3000) throw new ArgumentOutOfRangeException("anno non valido");
                _anno = value; 
            }
        }
        public double TemperaturaMedia
        { 
            get {  return _temperaturaMediaCelsius; }
            private set
            {
                if (value < -272.3 || value > 100) throw new ArgumentOutOfRangeException("temperatura media non valido");
                _temperaturaMediaCelsius = value;
            }
        }

        public Temperatura(int anno, double temperaturaMedia)
        {
            Anno = anno;
            TemperaturaMedia = temperaturaMedia;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Temperatura)) return false;
            Temperatura t = (Temperatura)obj;
            if (t.Anno == Anno && t.TemperaturaMedia == TemperaturaMedia) return true;
            return false;
        }
    }
}
