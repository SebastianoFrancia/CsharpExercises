using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseMorra
{
    public class Match
    {
        public Player _player;
        public Player _pc;

        public Match()
        {
            _player = new Player();
            _pc = new Player();
        }

        Random rnd = new Random();
        public TypeAction PcRound ()
        {
            _pc.Action = (TypeAction)(rnd.Next((int)TypeAction.rock,(int)TypeAction.scissors+1));
            return _pc.Action;
        }

        

        public string Winner ()
        {
            string winner = "pc won";
            if(!_player.Action.Equals(_pc.Action))
            {
                if ((_player.Action == TypeAction.rock && _pc.Action == TypeAction.paper) ||
                    (_player.Action == TypeAction.paper && _pc.Action == TypeAction.scissors) ||
                    (_player.Action == TypeAction.scissors && _pc.Action == TypeAction.rock))
                    {
                        _pc.CounterWins += 1;
                    }
                else
                {
                    _player.CounterWins += 1;
                    winner = "you won";
                }
            }
            else
            {
                winner = "draw";
            }
            return winner;
        }
    }
}
