using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckItalianCards
{
    internal class Deck
    {
        private Card[] _cards;
        private int _counterCard;

        public Card[] Cards
        {
            get { return _cards; }
        }
        public int CountFirstCard
        { 
            get { return _counterCard; } 
            private set {
                if (value < 0 || value > 40) throw new ArgumentOutOfRangeException("the value of the Count is invalid");
                _counterCard = value; 
            } 
        }

        public Card DrawFirstCard
        {
            get
            {
                if(_counterCard >= 40) throw new Exception("the countreCard is invalid");
                
                Card temp = _cards[CountFirstCard];
                _cards[CountFirstCard] = null;
                CountFirstCard++;
                return temp;

            }
        }
        public Card ViewFirstCard
        {
            get
            {
                if(_counterCard >= 40) throw new Exception("the countreCard is invalid");
                Card card = _cards[CountFirstCard];
                return card;
            }
        }

        public bool Empty
        {
            get
            {
                if(_cards[_cards.Length -1]==null ) return true;
                return false;
            }
        }
        public Deck() 
        {
            _counterCard = 0;
            _cards = GenerateDeck();
        }

        private Card[] GenerateDeck()
        {
            Card[] cards = new Card[40];
            for (int i = 0; i < (int)TypeSuit.Coppe;i++)
            {
                for (int j = 1; j < (int)TypeValue.king;j++)
                {
                    cards[i * 10 + j] = new Card((TypeSuit)i, j);
                }
            }
            return cards;
        }


        Random rnd = new Random();
        public void ShuffleCards()
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                int randomPosition = rnd.Next(_cards.Length);
                Card tmp = _cards[randomPosition];
                _cards[randomPosition] = _cards[i];
                _cards[i] = tmp;
            }
        }

        public void Shift()
        {
            Card temp = _cards[0];
            for (int i = 0; i < _cards.Length - 1; i++)
            {
                _cards[i] = _cards[i + 1];
            }
            _cards[_cards.Length -1] = temp;
        }


        public override string ToString()
        {
            string result = "---- List of Cards ----";
            for(int i=0; i < _cards.Length; i++)
            {
                result += $"{i + 1}. suit {_cards[i].Suit} value {_cards[i].Value} \n";
            }
            return result;
        }

    }
}
