using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GattileLIB
{
    public class Adozione
    {
        private Gatto _gatto;
        private Adottante _adottante;
        private DateOnly _dataAdozione;

        public Gatto Gatto
        {
            get { return _gatto; }
        }

        public Adottante Adottante
        {
            get { return _adottante; }
        }

        public DateOnly DataAdozione
        { 
            get { return _dataAdozione; } 
        }

        public Adozione(Gatto gatto, Adottante adottante)
        {
            _gatto = gatto;
            _adottante = adottante;
            _dataAdozione = DateOnly.FromDateTime(DateTime.Now);
        }

        public Adozione(Gatto gatto, DateOnly date, Adottante adottante)
        {
            _gatto = gatto;
            _adottante = adottante;
            _dataAdozione = date;
        }

        public override string ToString()
        {
            return $"{_gatto.Id}${_dataAdozione}${_adottante.ToString()}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Adozione)
            {
                Adozione adozione = (Adozione) obj;
                if(adozione._gatto.Equals(_gatto) && adozione._dataAdozione == _dataAdozione)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
