using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSpaces
{
    public class Restaurant
    {
        enum DayType
        {
            cole = -1,
            future_day = -2
        }
        private double[] _dailyTakings;

        public Restaurant() 
        {
            _dailyTakings = new double[366];
            Array.Fill(_dailyTakings, (int)DayType.future_day);
        }

        private void checkDay(int dayNumber)
        {
            if (dayNumber < 0 || dayNumber > 365) throw new ArgumentOutOfRangeException("day isen't corect");
        }

        public void SetDailyTakings(int dayNumber, int recepit)
        {
            if(recepit < 0) throw new ArgumentOutOfRangeException("recepit isen't corect");

            try
            {
                checkDay(dayNumber);
                _dailyTakings[dayNumber] = recepit;
            }catch (Exception) 
            {
                throw;
            }
        }

        public void ResetDailyTakings(int dayNumber)
        {
            try
            {
                checkDay(dayNumber);
                _dailyTakings[dayNumber] = (int)DayType.future_day;
            }catch(Exception)
            {
                throw;
            }
        }

        public void setCloseDay(int dayNumber)
        {
            try
            {
                checkDay(dayNumber);
                _dailyTakings[dayNumber] = (int)DayType.cole;
            }catch( Exception)
            {
                throw;
            }
        }

        public double CalculateAverageTakings()
        {
            double total = 0.0;
            int openDay = 0;

            foreach(double takings in _dailyTakings)
            {
                if(takings >= 0) 
                {
                    total += takings;
                    openDay++;
                }
            }
            return total/openDay;
        }

        public int CalcualteDayMinimumTakings()
        {
            double minimalTakings = double.PositiveInfinity;
            int dayMinimumTakings = -1;
            for (int i = 0; i <  _dailyTakings.Length; i++)
            {
                if (_dailyTakings[i] >= 0 && minimalTakings >= _dailyTakings[i])
                {
                    minimalTakings = _dailyTakings[i];
                    dayMinimumTakings = i;
                }
            }
            return dayMinimumTakings;

        }

        public int CalcualteDayMaximumTakings()
        {
            double maximumTakings = double.NegativeInfinity;
            int dayMaximumkings = -1;
            for (int i = 0; i < _dailyTakings.Length; i++)
            {
                if (maximumTakings <= _dailyTakings[i])
                {
                    maximumTakings = _dailyTakings[i];
                    dayMaximumkings = i;
                }
            }
            return dayMaximumkings;

        }

        public int calculateOpeningDaysTakingsBelowValue(double value)
        {
            if(value < 0) throw new ArgumentOutOfRangeException("value");
            int temp = 0;
            for(int i = 0; i < _dailyTakings.Length;i++)
            {
                if (_dailyTakings[i] > 0 && _dailyTakings[i] <= value) temp++;
                
            }
            return temp;
        }

        public int calculateOpeningDaysTakingsgreaterValue(double value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException("value");
            int temp = 0;
            for (int i = 0; i < _dailyTakings.Length; i++)
            {
                if (_dailyTakings[i] > 0 && _dailyTakings[i] >= value) temp++;
                
            }
            return temp;
        }

        public int calculateOpenDay()
        {
            int temp = 0;
            for(int i = 0; i < _dailyTakings.Length; ++i)
            {
                if (_dailyTakings[i] > 0) temp++;
               
            }
            return temp;
        }

        public int calculateCloseDay()
        {
            int temp = 0;
            for(int i = 0; i < _dailyTakings.Length; ++i)
            {
                if (_dailyTakings[i] == -1) temp++;
                
            }
            return temp;
        }
    }
}
