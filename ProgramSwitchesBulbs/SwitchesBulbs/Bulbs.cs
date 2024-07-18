using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BulbsClass
{
	public class Bulbs
	{
		//attributi
        private string _status;
        private int _maxNumClick;
		//propieta
        public string Status
        {
            get{return _status;}
            private set{_status = value;}
        }
		//costrutore
        public Bulbs(int maxNumClick)
        {
            _status = "off";
            _maxNumClick = maxNumClick;
        }

        public void Click(string status)
        {
            if(status == "on" && Status == "off") 
            {
                Status = status;
            }else{
                if(status == "off" && Status == "on")
                {
                    Status = status;
                }else{
                    throw new ArgumentException("the value of status is invalid");
                }
            }
            if(_maxNumClick == 0)
            {
                Status = "broken";
            }
            _maxNumClick -= 1;             
        }


		//metodi
  }
}