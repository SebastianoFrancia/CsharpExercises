using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gioco_di_carte
{
    public class Giocatore
    {
        private string _nome;
        private Carta[] _carteGiocatore;

        private int _punteggioGiocatore;

        public int PunteggioGiocatore
        {
            get { return _punteggioGiocatore;}
            private set
            {
                if (value < 0 || value > 120) throw new ArgumentException("il punteggio non è accettabile");
                _punteggioGiocatore = value;
            }
        }
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("il nome non è accettabile");
                }
                _nome = value;
            }
        }

       public Carta[] CarteGiocatore
       {
            get { return _carteGiocatore; }
            set
            {
                if(_carteGiocatore.Length !=3 ) 
                {
                    throw new ArgumentException("le carte date al giocatore non sono corrette"); 
                }
                _carteGiocatore = value;
            }
       }

        public Giocatore (string nome)
        {
            Nome= nome;
            _punteggioGiocatore=0;
            _carteGiocatore = new Carta[3];
        }

        public bool CarteFinite()
        {
            bool cartefinite = false;
            if (_carteGiocatore[0] == null && _carteGiocatore[1] == null && _carteGiocatore[2] == null)
            {
                cartefinite = true;
            }
            return cartefinite;
        }

        public Carta SceltaManoGiocatore(int sceltaGiocatore)
        {
            if (sceltaGiocatore < 0 || sceltaGiocatore > 2)
            {
                throw new ArgumentException("il numero della carta non è accettabile ");
            }
            else if(CarteGiocatore[sceltaGiocatore] == null)
            {
                throw new ArgumentException("la carta non esiste");
            }
            else
            {
                Carta cartascelta= CarteGiocatore[sceltaGiocatore];
                CarteGiocatore[sceltaGiocatore] = null;
                return cartascelta;
            }
        }

        public void InserisciCarta(Carta cartaNuova)
        {
            for(int i = 0;i < _carteGiocatore.Length;i++)
            {
                if (_carteGiocatore[i] == null)
                {
                    _carteGiocatore[i] = cartaNuova;
                    break;
                }
            }
        }

        public void AggiornaPunteggio(Carta cartaNuova)
        {
            _punteggioGiocatore += ConteggioPuntiGiocatore(cartaNuova);
        }

        public int ConteggioPuntiGiocatore(Carta carta)
        {
            int punteggio = 0;
            
                if (carta.IsFigura() == true)
                {
                    if(carta.IsFante() == true)
                    {
                        punteggio =  2;

                    }else if(carta.IsCavallo() == true)
                    {
                        punteggio = 3;
                    }
                    else if (carta.IsRe() == true)
                    {
                        punteggio = 4;
                    }
                }else if (carta.Valore == 1)
                {
                    punteggio = 11;

                }else if (carta.Valore == 3)
                {
                    punteggio = 10;
                }
                else
                {
                    punteggio = 0; 
                }
            
            return punteggio;
        }
    }
}
