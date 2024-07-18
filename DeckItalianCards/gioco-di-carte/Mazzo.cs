using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gioco_di_carte
{
    public class Mazzo
    {
        private Carta[] _carte;
        private int _indice;

        public Carta[] Carte
        {
            get
            {
                return _carte;
            }
        }

        public int Indice
        {
            get { return _indice; }
        }
        public Mazzo() { 

            _carte = new Carta[40];
            InizializzaMazzo();
            _indice = 0;
        }

        /// <summary>
        /// genera il mazzo iniziale (quello ordinato)
        /// </summary>
        private void InizializzaMazzo()
        {
            //ciclo per ogni seme
            for(int i=0; i<4;i++)
            {
                for(int j=1; j<=10;j++)
                {
                    //prima creo tutte le carte di seme 0(BASTONI) dal 1 al 10, poi tutte quelle di seme1(SPADE) etc
                    _carte[i * 10 + j-1] = new Carta((Semi)i,j);    
                }
            }
        }

        public Carta EstraiPrimaCarta
        {
            get
            {
                if(_indice >= 40)
                {
                    throw new Exception("l'indice non è accettabile");
                }
                Carta carta = _carte[_indice];
                _carte[_indice] = null;
                _indice++;
                return carta;
            }
        }

        public Carta VediPrimaCarta
        {
            get
            {
                if (_indice >= 40)
                {
                    throw new Exception("l'indice non è accettabile");
                }
                Carta carta = _carte[_indice];
                return carta;
            }
        }

        public override string ToString()
        {
            string mazzo ="";
            foreach(Carta carta in _carte)
            {
                mazzo += carta.ToString();
            }
            return mazzo;
        }

        public void MescolaMazzo()
        {
            Random random = new Random();
            //inserisco una tripla mescolata
            //for (int j = 0; j < 3; j++)
            //{
                //scambio ogni carta del mazzo con una posizione random
                for (int i = 0; i < _carte.Length; i++)
                {
                    int posizioneRandom = random.Next(_carte.Length);
                    //scambio la carta alla posizione i con la carta alla posizione posizioneRandom
                    Carta tmp = _carte[posizioneRandom];
                    _carte[posizioneRandom] = _carte[i];
                    _carte[i] = tmp;
                }
            //}
        }

        

        public void Shift()
        {
            Carta primaCarta= VediPrimaCarta;
            for (int i =_indice+1; i < _carte.Length; i++)
            {
                _carte[i-1]= _carte[i];

            }
            _carte[_carte.Length-1]= primaCarta;
        }
    }
}
