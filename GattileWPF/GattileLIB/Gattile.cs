using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GattileLIB
{
    public class Gattile
    {
        private List<Gatto> _gatti;
        private List<Adottante> _adottanti;
        private List<Adozione> _adozioni;

        public List<Gatto> Gatti
        {
            get
            {
                return _gatti;
            }
        }

        public List<Adottante> Adottanti
        {
            get { return _adottanti; }
        }

        public List<Adozione> Adozioni
        { 
            get { return _adozioni; } 
        }

        public Gattile(List<Gatto> gatti, List<Adottante> adottanti, List<Adozione> adozioni) 
        {
            _gatti = gatti;
            _adottanti = adottanti;
            _adozioni = adozioni;
        }

        public void AggiungiGatto(Gatto gatto, ScriviFile sf)
        {
            if (_gatti.Contains(gatto)) throw new ArgumentException(message: "gatto gia presente");
            _gatti.Add(gatto);
            sf.ScriviNuovoGatto(gatto);
        }

        public void AggiungiAdottante(Adottante adotante, ScriviFile sf)
        {
            if (_adottanti.Contains(adotante)) throw new ArgumentException(message:"adottante gia presente");
            _adottanti.Add(adotante);
            sf.ScriviNuovoAdottante(adotante);
        }

        public void AggiungiAdozione(Adozione adozione, ScriviFile sf)
        {
            if (_adozioni.Contains(adozione)) throw new ArgumentException(message:"adozione gia eseguita");
            _adozioni.Add(adozione);
            sf.ScriviAdozioni(_adozioni);
        }

        public void AdozioneFallita(Adozione adozione, DateOnly termine, ScriviFile sf)
        {
            if (_gatti.Contains(adozione.Gatto))
            {
                _gatti[_gatti.IndexOf(adozione.Gatto)].AdozioneFallita(termine);
                _gatti.Add(adozione.Gatto);
                sf.ScriviGatti(_gatti);
                sf.ScriviAdozioni(_adozioni);
            }
        }

        public int NumGattiPresenti()
        {
            return _gatti.Count - _adozioni.Count;
        }
    }
}
