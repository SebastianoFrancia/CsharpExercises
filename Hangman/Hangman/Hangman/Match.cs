using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hangman
{
    public static class Path
    {
        private static Uri _source = new Uri("Source", UriKind.Relative);
        public static Uri Source
        {
            get { return _source; }
        }
    }

    public enum MatchStatus
    {
        livesEnded,
        charGuessed,
        charNotGuessed,
        wordNotGuessed,
        alreadyUsed,
        Win
    }
    public class Match
    {
        private string _word;
        private List<char> _wordGuess;
        private Player _player;
        private List<char> _wrongCharacters;

        public String Word
        {
            get { return _word; }
        }

        public String WordGuess
        {
            get { return new String(_wordGuess.ToArray()); }
        }
        public int livesPlayer
        {
            get { return _player.Lives; }
        }


        public Match(string[] words)
        {
            _player = new Player();
            _word = ExtractWord(words);
            _wordGuess = InitialiseWordGuess();
            _wrongCharacters = new List<char>();

        }

        private string ExtractWord(string[] words)
        {
            Random rnd = new Random();
            string word = words[rnd.Next(0, words.Length)];

            return word.ToLower();
        }

        private List<char> InitialiseWordGuess()
        {
            List<char> wordGuess = new List<char>();
            for (int i = 0; i < _word.Length; i++)
            {
                if (_word[i] == 'a' || _word[i] == 'e' || _word[i] == 'i' || _word[i] == 'o' || _word[i] == 'u')
                {
                    wordGuess.Add('+');
                }
                else
                {
                    wordGuess.Add('-');
                }
            }
            return wordGuess;
        }

        private bool ThersCharacter(char ch)
        {
            bool guessed = false;

            for (int i = 0; i < _word.Length; i++)
            {
                if (ch == _word[i])
                {
                    _wordGuess[i] = ch;
                    guessed = true;
                }
            }
            return guessed;
        }

        private bool IsAalreadyUsedWrongCharacters(char character)
        {
            for (int i = 0; i < _wrongCharacters.Count; i++)
            {
                if (_wrongCharacters[i] == character)
                {
                    return true;
                }
            }
            _wrongCharacters.Add(character);
            return false;
        }
        public MatchStatus TurnGuessChar(char character)
        {            
            if (Word == WordGuess) return MatchStatus.Win;

            if (ThersCharacter(character)) 
            {
                if (Word == WordGuess) return MatchStatus.Win;
                return MatchStatus.charGuessed;
            }else
            {
                if(IsAalreadyUsedWrongCharacters(character))
                {
                    return MatchStatus.alreadyUsed;
                }else if (_player.TakeLife())
                {
                    return MatchStatus.charNotGuessed;
                }else
                {
                    return MatchStatus.livesEnded;
                }
            }
        }

        public MatchStatus TurnGuessWord(string word)
        {
            if(word == Word)
            {
                return MatchStatus.Win;
            }else
            {
                return MatchStatus.wordNotGuessed;
            }
        }

    }
}
