using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public class Date
    {
        /// <summary>
        /// contain a DateTime with valid data from a string
        /// </summary>
        private DateTime _date;

        public DateTime GetDate
        { 
            get { return _date; } 
        }
        public Date(string date)
        {
            if(date.Contains("-") || date.Contains("/"))
            {
                string[] dateSplit = date.Split('-', '/');
                _date = new DateTime(StringToYear(dateSplit[2]), int.Parse(dateSplit[1]), int.Parse(dateSplit[0]));
            }else
            {
                throw new ArgumentException("the string date does not contain a acetable data");
            }
        }

        private int StringToYear(string year)
        {
            int y = int.Parse(year);
            if ((y < 1900 && y > 99) || y > 2500) throw new ArgumentOutOfRangeException("year value is invalid");
            if (y < 100)
            {
                y += 1900;
            }
            return y;
        }

        public string ToString()
        {
            if (GetDate.Day < 10) return "0" + GetDate.Day.ToString() + "/" + GetDate.Month.ToString() + "/" + GetDate.Year.ToString();
            if (GetDate.Month < 10) return GetDate.Day.ToString() + "/0" + GetDate.Month.ToString() + "/" + GetDate.Year.ToString();
            if (GetDate.Day < 10 && GetDate.Month < 10) return "0" + GetDate.Day.ToString() + "/0" + GetDate.Month.ToString() + "/" + GetDate.Year.ToString();
            return GetDate.Day.ToString() + "/" + GetDate.Month.ToString() + "/" + GetDate.Year.ToString();
        }
    }
}
