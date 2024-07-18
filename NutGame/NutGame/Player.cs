using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutGame
{
    public class Player
    {
        //ogni giocatore deve avere un nome ed un punteggio
        private String _name;
        private int _points;

        public int Points
        {
            get { return _points; }
            private set { 
                if(value < 0) throw new ArgumentOutOfRangeException("i punti non possono essere negativi");
                _points = value; 
            }
        }

        public string Name
        {
            get { return _name; }
            private set { 
                if(value == null) throw new ArgumentNullException("il nome non può essere nullo");
                _name = value; 
            }
        }

        //costruttore 
        public Player(string nome) 
        {
            Name = nome;
            Points = 0;
        }

        //metodo privato per aggiornare ilpunteggio
        //il metodo controlal che il valore che gli arriva sia accettabile
        private void AddPoints(int points)
        {
            if (points <= 0) throw new ArgumentOutOfRangeException("non è possibile aggiungere un valore di punti minore o uguale a zero");
            Points += points;
        }

        //lancio 2 dadi, aggiorno il punteggio e restituisco il valore del lancio
        public int Roll()
        {
            //creo un dado a 6 facce
            Nut nut = new Nut();
            //faccio due lanci e sommo i punteggi
            int points = nut.Roll();
            points += nut.Roll();
            //aggiorno i punti del giocatore
            AddPoints(points);

            return points;
        }
    }
}
