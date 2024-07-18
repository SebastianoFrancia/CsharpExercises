using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeClass;

namespace AppointmentClass
{
    public class Appointment
    {
        private Time _timeStart;
        private Time _timeEnd;

        public Time TimeStart 
        {
            get { return _timeStart; }
        }
        public Time TimeEnd
        {
            get { return _timeStart; }
        }
        public Appointment(int houersStart, int minutesStar, int secondsStarts, 
            int houersEnd, int minutesEnd, int secondsEnd)
        {
            if (houersStart > houersEnd)
            {
                throw new ArgumentException("the time start or time end is invalid");
            }
            else
            {
                if (houersStart == houersEnd)
                {
                    if(minutesStar > minutesEnd)
                    {
                        throw new ArgumentException("the time start or time end is invalid");
                    }
                    else
                    {
                        if (minutesStar == minutesEnd)
                        {
                            if(secondsStarts > secondsEnd)
                            {
                                throw new ArgumentException("the time start or time end is invalid");
                            }
                        }
                    }
                }
            }
            _timeStart = new Time(houersStart, minutesStar, secondsStarts);
            _timeEnd = new Time(houersEnd, minutesEnd, secondsEnd);
        }

        public int CalculateTimeSeconds()
        {
            return (_timeEnd.Seconds - _timeStart.Seconds) + (((_timeEnd.Minutes - _timeStart.Minutes) + ((_timeEnd.Hours - _timeStart.Hours) * 60)) * 60);
        }

        public bool VerifyMoreLonger(Appointment comparer)
        {
            bool moreLonger = false;
            if (CalculateTimeSeconds() > comparer.CalculateTimeSeconds())
            {
                moreLonger = true;
            }
            return moreLonger;
        }

        public bool VerifyOvernyng(Appointment comparer)
        {
            bool moreOvernyng = false;
            if (TimeStart.Hours <= comparer.TimeEnd.Hours ||
                    TimeEnd.Hours >= comparer.TimeStart.Hours)
            {
                if (TimeStart.Minutes <= comparer.TimeEnd.Minutes ||
                TimeEnd.Minutes >= comparer.TimeStart.Minutes)
                {
                    if (TimeStart.Seconds <= comparer.TimeEnd.Seconds ||
                         TimeEnd.Seconds >= comparer.TimeStart.Seconds)
                    {
                        moreOvernyng = true;
                    }
                }
            }
            return moreOvernyng;
        }
    }
}
