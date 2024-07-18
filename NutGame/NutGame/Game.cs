using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using NutGame;

namespace NutGame
{
    /*COMMENTO PROF: nomina il file con il nome della classe (si chiamava Class.cs)
     * come vi ho detto in classe: 
     * - utilizza la classe Nut per la gestioen del dado
     * - utilizza rinmina quando cambi nome a qualsiasi elemento (avevi rinominato il namespace in modo errato)
     */
    public class Game
    {
        /*simulare un gioco dei dadi tra due giocatori.
        Di ogni giocatore interessa il NOME ed il PUNTEGGIO totalizzato nei vari lanci.
        I giocatori lanciano 2 dadi ad ogni turno ed il loro punteggio aumenta del punteggio totalizzato nel lancio.
        Se il punteggio del lancio è 11 il giocatore ha il diritto di effettuare un nuovo lancio.
        La partita termina quando uno dei giocatori supera il punteggio di 100 o dopo 15 lanci
        Vince il giocatore con il punteggio più alto*/
        //gli attributi del gioco sono i 2 giocatori se vogliamo generalizzare possiamo mettere come caratteristiche anche il punteggio ed il numero di lanci
        //il gioco gestisce poi la partita ed i round


        private Player _player1;
        private Player _player2;
        private int _maxRound;
        private int _maxPoints;
       

        //costruttore inizializza i due giocatori
        public Game(string name1, string name2, int maxRound=15, int maxPoints=100)
        {
            //prima di inizializzare il Game mi assicuro che i dati siano accettabili 
            if (maxRound <= 0) throw new ArgumentOutOfRangeException("i round devono essere almeno 1");
            if(maxPoints <= 0) throw new ArgumentOutOfRangeException("i round devono essere almeno 1");
            _player1 = new Player(name1);
            _player2 = new Player(name2);
            
            _maxRound = maxRound;
            _maxPoints = maxPoints;
        }

        //ogni turno è composto dal lancio dei dadi del giocatore
        private void Round()
        {
            int points;
            //lancia il primo giocatore (e continua alanciare finchè fa 11)
            do {
                points = _player1.Roll();
            }while (points == 11);

            //lancia il secondo giocatore (e continua alanciare finchè fa 11)
            do
            {
                points = _player2.Roll();
            } while (points == 11);

        }

        public String Play() 
        {
            string res = "Inizio Partita\n";
            int round = 1;
            do
            {
                res += $"Round {round}\n";
                Round();
                res += $"{_player1.Name}: {_player1.Points}\n";
                res += $"{_player2.Name}: {_player2.Points}\n";
                round++;
            }while (round <= 15 && _player1.Points<=100 && _player2.Points<=100);

            if(_player1.Points>_player2.Points)
            {
                res += $"VINCE {_player1.Name}";
            }
            else
            {
                if(_player1.Points<_player2.Points)
                {
                    res += $"VINCE {_player2.Name}";
                }
                else
                {
                    res += $"il gioco termina in pareggio";
                }
            }
            return res;
        }
      
    
    }
}