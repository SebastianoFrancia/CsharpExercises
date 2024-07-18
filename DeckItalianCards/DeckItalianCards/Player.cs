using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckItalianCards
{
    internal class Player
    {
        private string _name;
        private Card[] _hand;
        private int _score;
        public string Name { 
            get { return _name; }
            private set
            {
                if(value == null) throw new ArgumentException("the name is null");
            }
        }
        public int Score
        { 
            get { return _score; }
            private set { 
                if( value < 1 || value > 120) throw new ArgumentOutOfRangeException("the score can't be negative");
                _score = value; }
        }

        public Card[] Hand
        {
            get { return _hand; }
            set {
                if (value.Length != 3) throw new ArgumentException("the value of the hand is invalid ");
                _hand = value;
            }
        }

        public Player(string name ) 
        {
            _name = name;
            Hand = new Card[3];
            _score = 0;
        }

        public Card PlayerHandChoice(int playerChoice)
        {
            if (playerChoice < 0 || playerChoice > 2) throw new ArgumentException("il numero della carta non è accettabile ");
            if(Hand[playerChoice] == null) throw new ArgumentException("la carta non esiste");
            
            Card choiceCard= Hand[playerChoice];
            Hand[playerChoice] = null;
            return choiceCard;
        }

        public void AddCard(Card newCard)
        {
            for(int i = 0;i < Hand.Length;i++)
            {
                if (Hand[i] == null)
                {
                    Hand[i] = newCard;
                    break;
                }
            }
        }

        public bool FinishedCards()
        {
            bool finishedCards = false;
            if (Hand[0] == null && Hand[1] == null && Hand[2] == null)
            {
                finishedCards = true;
            }
            return finishedCards;
        }

        public void UpdateScore(Card card)
        {
            Score += CalculatesScore(card);
        }

        public int CalculatesScore(Card card)
        {
            int cardPoint = 0;
            
                if (card.IsFigure() == true)
                {
                    if(card.Value == TypeValue.jack)
                    {
                        cardPoint =  2;

                    }else if(card.Value == TypeValue.horse)
                    {
                        cardPoint = 3;
                    }
                    else if (card.Value == TypeValue.king)
                    {
                        cardPoint = 4;
                    }
                }else if (card.Value == (TypeValue)1)
                {
                    cardPoint = 11;

                }else if (card.Value == (TypeValue)3)
                {
                    cardPoint = 10;
                }
                else
                {
                    cardPoint = 0; 
                }
            
            return cardPoint;
        }

        public bool EmptyHand
        {
            get
            {
                if(Hand[0] == null && Hand[1] == null && Hand[2] == null) return true;
                return false;
            }
        }

    }
}
