using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiadinaStend
{
    public class WriteFile
    {
        private string _path;
        public WriteFile(string path)
        {
            _path = path;
        }

        public void WriteOrder(Order order)
        {
            using (StreamWriter sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(order.ToPrint());
            }
        }
    }
}
