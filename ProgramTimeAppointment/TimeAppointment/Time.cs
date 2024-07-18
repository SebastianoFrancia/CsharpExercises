using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClass
{
    public class Time
    {
        private int _hours;
        private int _minutes;
        private int _seconds;

        public int Hours
        {
            get { return _hours; }
            set 
            { 
                if (value < 0 || value >= 24) throw new ArgumentOutOfRangeException("the value is not valid");
                _hours = value; 
            }
        }

        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (value < 0 || value >= 60) throw new ArgumentOutOfRangeException("the value is not valid");
                _minutes = value;
            }
        }
        public int Seconds
        {
            get { return _seconds; }
            set 
            {
                if (value < 0 || value >= 60) throw new ArgumentOutOfRangeException("the value is not valid");
                _seconds = value;
            }
        }

        public Time (int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public bool CheckIfMorning()
        {
            bool checkMornig = false;

            if (Hours >= 6 && Hours < 15) 
            {
                checkMornig = true;
            }
            return checkMornig;
        }
    }
}
