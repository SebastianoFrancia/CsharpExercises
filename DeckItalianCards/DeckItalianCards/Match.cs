using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckItalianCards
{
    internal class Match
    {
        private Deck _deck;
        private Player _player1;
        private Player _player2;
        private TypeSuit _briscola;

        public Deck Deck
        {
            get { return _deck; }
        }

        public Player Player1
        {
            get { return _player1; }
        }

        public Player Player2
        {
            get { return _player2; }
        }

        public TypeSuit Briscola
        {
            get { return _briscola; }
        }
        public Match(string namePlayer1, string namePlayer2)
        {
            
            _deck = new Deck();
            _deck.ShuffleCards();
            _player1 = new Player(namePlayer1);
            _player2 = new Player(namePlayer2);
            startMatch();
        }

        public void startMatch()
        {
            Player1.Hand = DealCards();
            Player2.Hand = DealCards();
            Card briscola = _deck.ViewFirstCard;
            _briscola = briscola.Suit;
            _deck.Shift();
        }

        public Card[] DealCards()
        {
            Card[] tempHand= new Card[3];
            
            for (int i = 0; i < 3; i++)
            {
                tempHand[i] = _deck.DrawFirstCard;
            }
            return tempHand;
        }

        public string HandWinner(Card cardPlayer1, Card cardPlayer2)
        {
            string winnerPlayer;

            if (cardPlayer1.Suit == cardPlayer2.Suit)
            {
                if (cardPlayer1.Value >  cardPlayer2.Value)
                {
                    winnerPlayer = Player1.Name;

                }else
                {
                    winnerPlayer = Player2.Name;
                }

            }else if (cardPlayer2.Suit == _briscola)
            {
                winnerPlayer=Player2.Name;
            }
            else 
            {
                winnerPlayer = Player1.Name;
            }
            

            if(winnerPlayer == Player1.Name) 
            {
                _player1.UpdateScore(cardPlayer1);
                _player1.UpdateScore(cardPlayer2);
            }
            else
            {
                _player2.UpdateScore(cardPlayer2);
                _player2.UpdateScore(cardPlayer1);
            }

            return winnerPlayer;
        }

        public void DrawCard(string winnerPlayer)
        {
            if(winnerPlayer == Player1.Name)
            {
                _player1.AddCard(_deck.DrawFirstCard);
                _player2.AddCard(_deck.DrawFirstCard);
            }else
            {
                _player2.AddCard(_deck.DrawFirstCard);
                _player1.AddCard(_deck.DrawFirstCard);
            }
        }

        public bool IsMatchOver
        {
            get
            {
                if(Deck.Empty && Player2.EmptyHand && Player1.EmptyHand)return true;
                return false;
            }
        }

        public string MatchOutcome
        {
            get
            {
                string Outcome;
                if (Player1.Score > Player2.Score)
                {
                    Outcome = $"Ha vinto {Player1.Name}";

                }else if(Player2.Score > Player1.Score)
                {
                    Outcome = $"Ha vinto {Player2.Name}";

                }
                else
                {
                    Outcome = $"Pareggio";
                }
                return Outcome;
            }
        }
    }
}
