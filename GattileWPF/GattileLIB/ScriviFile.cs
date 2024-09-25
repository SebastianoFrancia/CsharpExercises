using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GattileLIB
{
    public class ScriviFile
    {
        private string _pathGatti;
        private string _pathAdottanti;
        private string _pathAdozioni;

        public ScriviFile(string pathGatti, string pathAdottanti, string pathAdozioni)
        {
            _pathGatti = pathGatti;
            _pathAdottanti = pathAdottanti;
            _pathAdozioni = pathAdozioni;

        }

        public void ScriviGatti(List<Gatto> gatti)
        {
            using (StreamWriter sw = new StreamWriter(_pathGatti))
            {
                for (int i = 0; i < gatti.Count; i++)
                {
                    sw.WriteLine(gatti[i].ToString());
                }
            }
        }

        public void ScriviAdozioni(List<Adozione> adozioni)
        {
            using (StreamWriter sw = new StreamWriter( _pathAdozioni))
            {
                for (int i = 0; i < adozioni.Count; i++)
                {
                    sw.WriteLine(adozioni[i].ToString());
                }
            }
        }
        public void ScriviNuovoAdottante(Adottante adottante)
        {
            using (StreamWriter sw = new StreamWriter(_pathAdottanti, true))
            {
                sw.WriteLine(adottante.ToString());
            }
        }

        public void ScriviNuovoGatto(Gatto gatto)
        {
            using (StreamWriter sw = new StreamWriter(_pathGatti, true))
            {
                sw.WriteLine(gatto.ToString());
            }
        }
    }
}
