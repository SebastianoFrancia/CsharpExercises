using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorraCinese
{
    public enum TipologiaScelta
    {
        Sceltanonfatta = -1, Sasso, Carta, Forbice
    }

    public enum TipologiaGiocatore
    {
        Giocatore,
        Bot
    }
    public class Giocatore
    {
        private TipologiaScelta _scelta;
        private TipologiaGiocatore _tipologiaGiocatore;
        private int _roundVinti;

        public TipologiaGiocatore TipoGiocatore
        {
            get { return _tipologiaGiocatore; }
            set
            {
                if ((int)value > 1 || (int)value < 0)
                {
                    throw new ArgumentException("non puoi avere questo giocatore");
                }
                _tipologiaGiocatore = value;
            }
        }

        public TipologiaScelta Scelta
        {
            get { return _scelta; }
            set
            {
                if ((int)value > 2 || (int)value < 0)
                {
                    throw new ArgumentException("non puoi avere questo valore");
                }
                _scelta = value;
            }
        }

        public int RoundViti
        {
            get { return _roundVinti; }
            private set { _roundVinti = value; }
        }

        public Giocatore() 
        {
            _scelta=(TipologiaScelta)(-1);
            RoundViti=0;
        }


        Random random = new Random();
        public void SceltaRandom()
        { 
            Scelta = (TipologiaScelta)random.Next(0, 3);
        }

        public void AggiungiVittoria()
        {
            _roundVinti ++;
        }
    }
}
