using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseMorra
{
    public enum TypeAction
    {
        rock,
        paper,
        scissors
    }

    public class Player
    {
        

        private TypeAction _action;
        private int _counterWins;

        public int CounterWins
        {
            get { return _counterWins; }
            set 
            {
                if(value <= 0 && value >= 3) throw new ArgumentOutOfRangeException("the counter ser can't be different of 1 or 0 ");
                _counterWins = value; 
            }
        }
        public TypeAction Action
        {
            get { return _action; }
            set {
                if(!(value is TypeAction) || value > (TypeAction)2) throw new ArgumentOutOfRangeException("type isn't acceptability");
                _action = value; 
            }
        }
        public Player() 
        {
            _counterWins = 0;
        }

    

        public override bool Equals(object? obj)
        {
            try
            {
                
                if (!(obj is Player) && obj == null) throw new ArgumentException("the object is not a Player type");
                Player p = (Player)obj;
                if (p.Action == Action)
                {
                    return true;
                }
                return false;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
