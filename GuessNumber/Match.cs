using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public enum TypeOutcomes
    {
        guess,
        numberAlreadyInserted,
        unguessed,
    }
    public class Match
    {
        private int _maxTries;
        private int _solution;
        private int[] _triesNumbers;
        private int _tries;
        private int _maxNumber;
        
        public int MaxTries
        { 
            get { return _maxTries; } 
            private set {
                if (value <= 0 && value >= _maxNumber) throw new ArgumentOutOfRangeException("value is not acceptable");
                _maxTries = value; 
            }
        }

        public int Tries
        {
            get { return _tries; }
        }
        
        public int MaxNumber
        {
            get{ return _maxNumber; }
            private set{
                if(value <= 1) throw new ArgumentException("the maximum number cannot be less than 0");
                _maxNumber = value;
            }
        }
        public Match(int maxNumber= int.MaxValue, int maxTries= 10)
        {
            _tries = 0;
            MaxTries = maxTries;
            _triesNumbers = new int[maxTries];
            for(int i=0; i<_triesNumbers.Length; i++)
            {
                _triesNumbers[i] = -1;
            }
            MaxNumber = maxNumber;
            _solution = GenerateNumber(maxNumber);
        }

        Random _random = new Random();
        public int GenerateNumber(int max)
        {
            if(max <= 0)throw new ArgumentOutOfRangeException("the max number cannot be less than or equal to 0");
            return _random.Next(0,max);
        }

        public TypeOutcomes attempt(int tryNum)
        {
            if(tryNum <= 0 || tryNum > _maxNumber ) throw new ArgumentOutOfRangeException("the num is not a possible number");
            if (_tries >= _triesNumbers.Length )
            {
                ReinizializeTriesNumbers();
            }


            TypeOutcomes attempt;
            if (tryNum == _solution)
            { 
                attempt = TypeOutcomes.guess;

            }else
            {
                if (NumberAlreadyInserted(tryNum) == true)
                {
                    attempt = TypeOutcomes.numberAlreadyInserted;
                } else
                {
                    attempt = TypeOutcomes.unguessed;
                }
            }
            _triesNumbers[_tries] = tryNum;
            _tries++;

            return attempt;
        }

        public void ReinizializeTriesNumbers()
        {
            if(_tries % 2 == 0)
            {
                _tries = (_tries / 2);
            }else
            {
                _tries = (_tries / 2) + 1;
            }

            int[] temp = new int[_triesNumbers.Length + _tries];

            for(int i=0; i<_triesNumbers.Length; i++)
            {
                temp[i]= _triesNumbers[i];
            }
            _triesNumbers = temp;
        }

        private bool NumberAlreadyInserted(int num)
        {
            bool returned = false; 
            for(int i=0; i< _triesNumbers.Length; i++)
            {
                if (_triesNumbers[i] == num )
                {
                    returned = true;
                    break;
                }
            }
            return returned;
        }

    }
}
