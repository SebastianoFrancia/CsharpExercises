using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbsClass;

namespace SwitchesClass
{
	public class Switches
	{
        private bool _status;
        private Bulbs _bulbsOfSwitche;

        public bool Status
        {
            get{return _status;}
            set
            {
                _status = value;    
                SwitchesOperation();
            }
        }

        public Switches(int maxNumClick=3000 )
        {
            Status = false;
            _bulbsOfSwitche = new Bulbs(maxNumClick);
        }
        
        public void SwitchesOperation()
        {
            if(Status == false)
            {
               _bulbsOfSwitche.Click("off"); 
            }
            else
            {
                _bulbsOfSwitche.Click("on");
            }

        }
  }
}