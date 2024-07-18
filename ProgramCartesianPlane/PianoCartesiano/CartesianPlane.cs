using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoCartesiano
{
    public class cartesianPlane
    {
        private int _windowsWidht;
        private int _windowsHeight;

        public int WindowsWidht
        {
            get { return _windowsWidht; }
        }

        public int WindowsHeight
        {
            get { return _windowsHeight; }
        }

        public int OrigX
        {
            get { return _windowsWidht/2; }
        }

        public int OrigY
        {
            get { return _windowsHeight/2; }
        }

        public cartesianPlane(int windowsWidht, int windowsHeight)
        {
            _windowsWidht = windowsWidht;
            _windowsHeight = windowsHeight;

        }      
    }
}
