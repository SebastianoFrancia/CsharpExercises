using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessioniAllenamentoLIB
{
    public class Sessione
    {
        private int _ore;
        private int _minuti;
        private int _secondi;

        public int Ore
        {
            get { return _ore; }
            private set
            {
                if (value < 0) throw new ArgumentException(message: "numero di ore errato");
                _ore = value;
            }
        }

        public int Minuti
        {
            get { return _minuti; }
            private set
            {
                if (value < 0 || value >= 60) throw new ArgumentException(message: "numero di minuti errato");
                _minuti = value;
            }
        }

        public int Secondi
        {
            get { return _secondi; }
            private set
            {
                if (value < 0 || value >= 60) throw new ArgumentException(message: "numero di secondi errato");
                _secondi = value;
            }
        }

        public double TempoMinuti
        {
            get
            {
                return _minuti + _ore * 60 + _secondi / 60;
            }
        }

        public bool IsIntensivo
        {
            get
            {
                if (_ore >= 4)
                {
                    return true;
                }
                return false;
            }
        }

        public Sessione(int ore, int minuti, int secondi)
        {
            Ore = ore;
            Minuti = minuti;
            Secondi = secondi;
        }
    }
}
