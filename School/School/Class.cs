using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Class
    {
        private char _section;
        private int _year;
        private int _numStudents;

        public char Section
        {
            get{ return _section; }
        }
        public int Year
        {
            get { return _year; }
            set 
            {
                if (value < 1 || value > 5) throw new ArgumentException("class gose from 1 to 5");
                _year = value; 
            }
        }
        public int NumStudents
        {
            get { return _numStudents; }
            set 
            {
                if (_numStudents < 10 || _numStudents > 35) throw new ArgumentException("the class must have at 10 students and not over 35");
                _numStudents = value; 
            }
        }
        public Class(char section, int year)
        {
            _section = section;
            _year = year;
        }
    }
}
