using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD
{
    internal class Track
    {
        private string _title;
        private int _time;

        public string Title
        {
            get { return _title; }
            private set 
            {
                if (value == null) throw new ArgumentException("the title is void"); 
                _title = value; 
            }
        }

        public int Time
        {
            get { return _time; }
            private set
            {
                if (value < 0) throw new ArgumentException("the time is invalid");
                _time = value;
            }
        }

        public Track(string title, int minutes, int seconds)
        {
            Title = title;
            Time = minutes*60 + seconds;
        }

        public override string ToString()
        {
            int minute = Time / 60;
            int second = Time%60;
            return $"{Title} - {minute}minute {second}sec";
        }
    }
}
