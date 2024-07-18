using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimoProgettoStringhe
{
    internal class StringManagement
    {
        private string _string;
        private char _char;
        private string _substring;

        public string String
        {
            get { return _string; }
            private set { 
                if(value == null) throw new ArgumentNullException("the string is empty");
                _string = value;
            }
        }

        public char Char
        {
            get { return _char; }
            private set{
                if (value == null) throw new ArgumentNullException("the char is empty");
                _char = value;
            }
        }

        public string Substring
        {
            get { return _substring; }
            private set{
                if(value == null) throw new ArgumentNullException("the Comparison String is empty");
                _substring = value;
            }
        }
            
            
        public StringManagement(string string1, char char1,string comparisonString) 
        {
            String = string1;
            Char = char1;
            Substring = comparisonString;
        }

        public int Lenght
        {
            get
            {
                return String.Length;
            }
        }

        public int VoclasNumber
        {
            get
            {
                int count = 0;
                for(int i = 0; i < String.Length; i++)
                {
                    if (String[i] == 'A' || String[i] == 'E' || String[i] == 'I' || String[i] == 'O' || String[i] == 'U'
                        || String[i] == 'a' || String[i] == 'e' || String[i] == 'i' || String[i] == 'o' || String[i] == 'u')
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public int UppercaseLetersNumber
        {
            get
            {
                string temp = String.ToUpper();
                int count = 0;
                for(int i = 0;i < String.Length;i++)
                {
                    if (String[i] == temp[i])
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public int CharNumber
        {
            get
            {
                int count = 0;
                for(int i=0; i < String.Length; i++)
                {
                    if (String[i] == Char)
                    {
                        count ++;
                    }
                }
                return count;
            }
        }

        public bool TherSubstring
        {
            get
            {
                int count;

                if(Substring.Length <= String.Length)
                {
                    for (int i = 0; i < String.Length; i++)
                    {
                        count = 0;
                        for (int j = 0; j < Substring.Length; j++)
                        {
                            if (String[i] == Substring[j])
                            {
                                count++;
                            }
                        }

                        if (count == Substring.Length)
                        {
                            return true;
                        }

                    }
                }
                
                return false;

            }
        }

    }
}
