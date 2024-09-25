using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessioniAllenamentoLIB
{
    public class Atleta
    {
        private Sessione _miglioreAllenamentoIntensivo;
        private Sessione _miglioreAllenamentoStandard;
        private List<Sessione> _allenamenti;

        public double? MiglioreAllenamentoIntensivo
        {
            get
            {
                if (_miglioreAllenamentoIntensivo != null)
                {
                    return _miglioreAllenamentoIntensivo.Minuti + _miglioreAllenamentoIntensivo.Ore * 60 + _miglioreAllenamentoIntensivo.Secondi / 60;
                }
                return null;
            }

        }
        public double? MiglioreAllenamentoStandard
        {
            get {
                if (_miglioreAllenamentoStandard != null)
                {
                    return _miglioreAllenamentoStandard.Minuti + _miglioreAllenamentoStandard.Ore * 60 + _miglioreAllenamentoStandard.Secondi / 60; 
                }
                return null;
            }
        }

        public List<Sessione> Allenamenti
        {
            get { return _allenamenti; }
        }

        public Atleta(List<int[]> tempoAllenamenti)
        {
            List<Sessione> allenamenti = new List<Sessione>();
            for ( int i = 0; i < tempoAllenamenti.Count;i++)
            {
                allenamenti.Add(new Sessione(tempoAllenamenti[i][0], tempoAllenamenti[i][1], tempoAllenamenti[i][2]));
            }

            List<Sessione> allenamentiStandard = new List<Sessione>();
            List<Sessione> allenamentiIntensivi = new List<Sessione>();
            for (int i = 0; i < allenamenti.Count; i++)
            {
                if (allenamenti[i].IsIntensivo)
                {
                    allenamentiIntensivi.Add(allenamenti[i]);
                }
                else
                {
                    allenamentiStandard.Add(allenamenti[i]);
                }
            }
            if (allenamentiIntensivi.Count > 0) _miglioreAllenamentoIntensivo = MiglioreSessione(allenamentiIntensivi);
            else _miglioreAllenamentoIntensivo = null;
            if (allenamentiStandard.Count > 0) _miglioreAllenamentoStandard = MiglioreSessione(allenamentiStandard);
            else _miglioreAllenamentoStandard = null;

            _allenamenti = allenamenti;

        }

        public bool StessiTempiAllenamenti( Atleta atleta)
        {
            bool uguali = true;
            if (_allenamenti.Count == atleta.Allenamenti.Count)
            {
                for (int i = 0; i < _allenamenti.Count; ++i)
                {
                    if (Allenamenti[i].TempoMinuti != atleta.Allenamenti[i].TempoMinuti)
                    {
                        uguali = false; break;
                    }
                }
            }else return false;
            return uguali;
        }

        private Sessione MiglioreSessione(List<Sessione> allenamenti)
        {
            Sessione miglioreAllenamento = allenamenti[0];
            for (int i = 0; i < allenamenti.Count-1; i++)
            {
                if (allenamenti[i].TempoMinuti < allenamenti[i + 1].TempoMinuti)
                {
                    miglioreAllenamento = allenamenti[i + 1];
                }
            }
            return miglioreAllenamento;
        }

    }
}
