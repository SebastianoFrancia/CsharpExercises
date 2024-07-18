using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceClass
{
    public class Dice
    {
        private int _numFace;

        public int NumFace
        {
            get { return _numFace;}
            set
            {
                if (value < 4)
                {
                    throw new ArgumentOutOfRangeException("the number of faces is invalid");
                }
                _numFace = value;
            }
        }

        public Dice(int numFacce = 6) 
        {
            NumFace = numFacce;
        }

        public int Throw()
        {
            Random dado = new Random();
            return dado.Next(1, _numFace+1);
        }
    }   
}