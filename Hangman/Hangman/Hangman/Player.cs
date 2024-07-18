using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Player
    { 
        private int _lives;
        private static int max_lives = 11;

        public int Lives
        { 
            get { return _lives; } 
        }
        public Player() 
        {
            _lives = max_lives;
        }

        public bool TakeLife()
        {
            if (_lives > 1)
            {
                _lives--;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
