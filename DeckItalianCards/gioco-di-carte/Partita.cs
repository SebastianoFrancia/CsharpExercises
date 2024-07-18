using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gioco_di_carte
{
    public class Partita
    {
        private Mazzo _mazzo;
        private Giocatore _giocatore1;
        private Giocatore _giocatore2;
        private Semi _briscola;

        public Mazzo Mazzo
        {
            get { return _mazzo; }
        }

        public Giocatore Giocatore2
        {
            get { return _giocatore2; }
        }

        public Giocatore Giocatore1
        {
            get { return _giocatore1; }
        }

        public Semi Briscola
        {
            get { return _briscola; }
        }



        public Partita(string giocatore1, string giocatore2)
        {
            _mazzo = new Mazzo();
            _mazzo.MescolaMazzo();
            _giocatore1 = new Giocatore(giocatore1);
            _giocatore2 = new Giocatore(giocatore2);
            InizializzaPartita();

       
        }

        public Carta[] DistribiusciCarte()
        {
            Carta []tempMano= new Carta[3];
            
            for (int i = 0; i < 3; i++)
            {
                tempMano[i] = Mazzo.EstraiPrimaCarta;
            }
            return tempMano;

        }

        private void InizializzaPartita()
        {
            Giocatore1.CarteGiocatore = DistribiusciCarte();
            Giocatore2.CarteGiocatore = DistribiusciCarte();
            _briscola = _mazzo.VediPrimaCarta.Seme;
            _mazzo.Shift();
        }

        public string VincitoreMano(Carta carta1, Carta carta2)
        {
            string giocatoreVincente;

            if (carta1.Seme == carta2.Seme)
            {
                if (carta1.Valore >  carta2.Valore)
                {
                    giocatoreVincente = Giocatore1.Nome;

                }else
                {
                    giocatoreVincente=Giocatore2.Nome;
                }

            }else if (carta2.Seme == _briscola)
            {
                giocatoreVincente=Giocatore2.Nome;
            }
            else 
            {
                giocatoreVincente = Giocatore1.Nome;
            }
            

            if(giocatoreVincente == Giocatore1.Nome) 
            {
                _giocatore1.AggiornaPunteggio(carta1);
                _giocatore1.AggiornaPunteggio(carta2);
            }
            else
            {
                _giocatore2.AggiornaPunteggio(carta1);
                _giocatore2.AggiornaPunteggio(carta2);
            }

            return giocatoreVincente;
        }

        public void PescaCarta(string giocatoreVincente)
        {
            if(giocatoreVincente == Giocatore1.Nome)
            {
                _giocatore1.InserisciCarta(_mazzo.EstraiPrimaCarta);
                _giocatore2.InserisciCarta(_mazzo.EstraiPrimaCarta);
            }else
            {
                _giocatore2.InserisciCarta(_mazzo.EstraiPrimaCarta);
                _giocatore1.InserisciCarta(_mazzo.EstraiPrimaCarta);
            }
        }

        public string EsitoPartita()
        {
            string esito;
            if (_giocatore1.PunteggioGiocatore > _giocatore2.PunteggioGiocatore)
            {
                esito = $"Ha vinto {Giocatore1.Nome}";

            }else if(_giocatore2.PunteggioGiocatore> _giocatore1.PunteggioGiocatore)
            {
                esito = $"Ha vinto {Giocatore2.Nome}";

            }
            else
            {
                esito = $"Pareggio";
            }
            return esito;
        }
    }
}
