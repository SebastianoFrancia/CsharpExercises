using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MorraCinese
{
    public class Statistiche
    {
        

        private int _numeroPartite;
        private int _numeroTotaleRound;
        private int _numeroPartiteVinteGiocatore;
        private int _numeroPartiteVintePC;


        public int NumeroPartite
        {
            get { return _numeroPartite; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("il numero di partite non è accettabile");
                }
                _numeroPartite = value;
            }
        }

        public int NumeroTotaleRound
        {
            get { return _numeroTotaleRound; }
            set
            {
                if (value < 3 * NumeroPartite)
                {
                    throw new ArgumentOutOfRangeException("il numero di round non è accettabile");
                }
                _numeroTotaleRound = value;
            }
        }

        public int NumeroPartiteVinteGiocatore
        {
            get { return _numeroPartiteVinteGiocatore; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("il numero di partite vinte del giocatore non è accettabile");
                }
                _numeroPartiteVinteGiocatore = value;
            }
        }

        public int NumeroPartiteVintePc
        {
            get { return _numeroPartiteVintePC; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("il numero di partite vinte del giocatore non è accettabile");
                }
                _numeroPartiteVintePC = value;
            }
        }
        
        public Statistiche(int N)
        {
            NumeroPartite = N;
        }
        

        public void AggiungiNumeroPartiteVinte(TipologiaGiocatore tipo)
        {
            if (tipo == TipologiaGiocatore.Giocatore)
            {
                _numeroPartiteVinteGiocatore++;
            }
            else
            {
                if (tipo == TipologiaGiocatore.Bot)
                {
                    _numeroPartiteVintePC++;
                }
                else
                {
                    throw new Exception("la tipologia non è accettabile");
                }
            }
        }

        public int NumeroPartiteVinte(TipologiaGiocatore tipo)
        {
            if (tipo == TipologiaGiocatore.Giocatore)
            {
                return _numeroPartiteVinteGiocatore;
            }
            else
            {
                if (tipo == TipologiaGiocatore.Bot)
                {
                    return _numeroPartiteVintePC;
                }
                else
                {
                    throw new Exception("la tipologia non è accettabile");
                }
            }
        }

        
        public int NumeroPartiteGiocate(Partita[] partita1)
        {
            int numeroPartiteGiocate = -1;
            for (int i = 0; i < partita1.Length; i++)
            {
                if (partita1[i] != null)
                {
                    numeroPartiteGiocate++;
                }
            }

            return numeroPartiteGiocate;
        }

        public int NumeroRoundGiocati(Partita[] partita)
        {
            int numeroRoundGiocati = 0;
            for (int i = 0; i < partita.Length; i++)
            {
                if(partita[i] != null && partita[i].NumeroRound != null)
                {
                    numeroRoundGiocati += partita[i].NumeroRound;
                }                 
            }
            return numeroRoundGiocati;
        }

        public void CalcolaNumeroTotaleRound(Partita[] partita)
        {
            int numeroTotaleRound = 0;
            for (int i = 0; i < partita.Length; i++)
            {
                if(partita[i] != null && partita[i].NumeroRound != null)
                {
                    numeroTotaleRound += partita[i].NumeroRound;
                }else
                {
                    throw new ArgumentException($"non è posibile calcolare i round totali se la paritta {i} non è inizalizata");
                }
            }
            _numeroTotaleRound = numeroTotaleRound;
        }
        public double NumeroRoundMediPerPartita()
        {
            return (double)NumeroTotaleRound / (double)NumeroPartite;
        }

        public double PercentualeVittorie(TipologiaGiocatore tipo)
        {
            if (tipo == TipologiaGiocatore.Giocatore)
            {
                return Convert.ToDouble(NumeroPartiteVinte(TipologiaGiocatore.Giocatore)) * 100 / NumeroPartite;
            }
            else
            {
                if (tipo == TipologiaGiocatore.Bot)
                {
                    return Convert.ToDouble(NumeroPartiteVinte(TipologiaGiocatore.Bot)) * 100 / NumeroPartite;
                }
                else
                {
                    throw new Exception("la tipologia non è accettabile");
                }
            }
        }
             

        public Giocatore VincitorePartitaX(int numero, Partita[] partita1)
        {
            if (partita1 != null && (numero < 0 || numero > partita1.Length))
            {
                throw new ArgumentException("i parametri non sono accettabili");
            }
        
            return partita1[numero].VincitorePartita;
        }

        public int NumeroRoundPartitaX(int numero, Partita[] partita1)
        {
            if (partita1 != null && (numero < 0 || numero > partita1.Length))
            {
                throw new ArgumentException("i parametri non sono accettabili");
            }

            return partita1[numero].NumeroRound;
        }
    }
}
