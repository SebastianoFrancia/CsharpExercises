using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GattileLIB
{
    class STAT
    {
        private List<Gatto> _gatti;
        private List<Adottante> _adottanti;
        public STAT(string pathDatiGatti, string pathDatiAdottanti) 
        {
            LeggiFile leggiFile = new LeggiFile(pathDatiGatti, pathDatiAdottanti);
            _gatti = leggiFile.LeggiDatiGatti();
            _adottanti = leggiFile.LeggiDatiAdottanti();
            Check(_gatti);
        }
        public STAT(List<Gatto> gatti, List<Adottante> adottanti)
        {
            _gatti = gatti; 
            _adottanti = adottanti;
            Check(_gatti);
        }

        private void Check(List<Gatto> gatti)
        {
            LeggiFile leggiFile = new LeggiFile(@"..\..\..\..\GattileWPF\DatiAdozioni.txt");
            List<Adozione> adozioni = leggiFile.LeggiDatiAdozioni(gatti);
            for (int i = 0; i < adozioni.Count; i++)
            {
                if (!gatti.Contains(adozioni[i].Gatto)) throw new Exception("gatto adozioni non trovato");
            }
        }

        public int MiglioreMese()
        {
            LeggiFile leggiFile = new LeggiFile(@"..\..\..\..\GattileWPF\DatiAdozioni.txt");
            List<Adozione> adozioni = leggiFile.LeggiDatiAdozioni(_gatti);

            int[] mesiAdozioni = new int[12];
            for (int i=0; i < adozioni.Count;i++)
            {
                int mese = adozioni[i].DataAdozione.Month-1;
                mesiAdozioni[mese] += 1;
            }

            int migloreMese=0;
            for (int i=1; i<12; i++)
            {
                if (mesiAdozioni[i] > mesiAdozioni[i+1])
                {
                    migloreMese=i;
                }
                else
                {
                    migloreMese = i + 1;
                }
            }
            return migloreMese;
        }

        public int AdozioniFallite()
        {
            LeggiFile leggiFile = new LeggiFile(@"..\..\..\..\GattileWPF\DatiAdozioni.txt");
            List<Adozione> adozioni = leggiFile.LeggiDatiAdozioni(_gatti);

            int numAdozioniFallite =0;
            for (int i=0;i<adozioni.Count;i++)
            {
                if (_gatti.Contains(adozioni[i].Gatto)) numAdozioniFallite++;
            }
            return numAdozioniFallite;
        }
    }
}
