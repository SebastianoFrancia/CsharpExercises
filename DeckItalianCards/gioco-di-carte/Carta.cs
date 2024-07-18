using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gioco_di_carte
{
    public enum Semi
    {
        BASTONI,
        SPADE,
        DENARI,
        COPPE
    }
    public class Carta
    {
        private Semi _seme;
        private int _valore;

        public Semi Seme
        {
            get { return _seme; }
            private set { 
                if((int)value<0 || (int)value > 3) throw new ArgumentException("seme non accettabile");
                _seme = value; 
            }
        }

        public int Valore
        {
            get { return _valore; }
            private set {
                if (value < 1 || value > 10) throw new ArgumentOutOfRangeException("valore non accettabile");
                _valore = value; 
            }
        }

        public Carta(Semi seme, int valore)
        {
            Seme = seme;
            Valore = valore;
        }

        public bool IsFigura()
        {
            if(Valore>7) return true;
            return false;
        }

        public bool IsFante()
        {
            if (Valore ==8) return true;
            return false;
        }

        public bool IsCavallo()
        {
            if (Valore == 9) return true;
            return false;
        }

        public bool IsRe()
        {
            if (Valore == 10) return true;
            return false;
        }

        public override string ToString()
        {
            return $"{Valore} {Seme}\n";
        }

    }
}
