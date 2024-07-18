using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio1
{
    public class Date
    {
        private int _day;
        private int _month;
        private int _year;

        public int Day
        {
            get { return _day; }
            private set
            {
                if(value<1) throw new ArgumentOutOfRangeException("value of day is invalid");
                if(Month==1 || Month==3 || Month==5 || Month==7 || Month==8 || Month==10 || Month==12 )
                {
                    if(value>31) throw new ArgumentOutOfRangeException("value of day is invalid");
                }
                if(Month==2)
                {
                    if(IsLeapYear())
                    {
                        if(value>29) throw new ArgumentOutOfRangeException("value of day is invalid");
                    }else{
                        if(value>28) throw new ArgumentOutOfRangeException("value of day is invalid");
                    }
                }
                if(Month==4 || Month==6 || Month==9 || Month==11)
                {
                    if(value>30) throw new ArgumentOutOfRangeException("value of day is invalid");
                }
                _day=value;
            }
        }
        public int Month
        {
            get { return _month; }
            private set
            {
                if(value<1 || value>12) throw new ArgumentOutOfRangeException("value of mounth is invalid");
                _month = value;
            }
        }
        public int Year
        {
            get { return _year; }
            private set
            {
                if(value<1) throw new ArgumentOutOfRangeException("value of year is invalid");
                _year = value;
            }
        }

        public Date(int day, int month, int year)
        {
            Month=month;
            Year=year;
            Day=day;
        }

        public Date(string date)
        {
            Month=stringToMounth(date);
            Year=StringToYear(date);
            Day=stringToDay(date);
        }
        private int stringToDay(string date)
        {
            string g1 = date[0].ToString();
            string g2 = date[1].ToString();
            string day = g1+g2;
            return int.Parse(day);
        }

        private int stringToMounth(string date)
        {
            string m1 = date[3].ToString();
            string m2 = date[4].ToString();
            string mounth = m1+m2;
            return int.Parse(mounth);
        }

        private int StringToYear(string date)
        {
            string year;
            string y1=date[6].ToString();
            string y2=date[7].ToString();
            if(date.Length==10)
            {
                string y3=date[8].ToString();
                string y4=date[9].ToString();
                year=y1+y2+y3+y4;
            }else
            {
                year="20"+y1+y2;
            }
            return int.Parse(year);
        }

        public bool IsLeapYear()
        {
            if(Year%100==0)
            {
                if(Year%400==0) return true;
            }else
            {
                if(Year%4==0) return true;
            }
            return false;
        }

        public string ToString()
        {
            return Day.ToString()+"/"+Month.ToString()+"/"+Year.ToString();
        }
    }
}