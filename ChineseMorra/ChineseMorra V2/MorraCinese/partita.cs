using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MorraCinese
{
    public enum CasiRound
    {
        pareggio,
        utente,
        bot
    }
    public class Partita
    {
        
        private Giocatore _bot;
        private Giocatore _Player;
        private Giocatore _vincitore;
        private int _numeroRound;

        
        public Giocatore Bot
        {
            get { return _bot; }
        }
        public Giocatore Player
        {
            get { return _Player; }
        }

        public Giocatore VincitorePartita
        {
            get { return _vincitore; }
            set
            {
                _vincitore = value;
            }                      
        }

        public int NumeroRound
        {
            get { return _numeroRound; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("il numero di round non è accettabile");
                }
                _numeroRound = value;
            }
        }

        public Partita()
        {
            _bot = new Giocatore();
            _bot.TipoGiocatore = TipologiaGiocatore.Bot;

            _Player = new Giocatore();
            _Player.TipoGiocatore = TipologiaGiocatore.Giocatore;
        }
        
        public CasiRound Round(int sceltautente)
        {
            _bot.SceltaRandom();
            _Player.Scelta=(TipologiaScelta)sceltautente;
            CasiRound esito = ControllaVincitoreRound();
            if (esito==CasiRound.bot)
            {
                _bot.AggiungiVittoria();
            }
            if (esito == CasiRound.utente)
            {
                _Player.AggiungiVittoria();
            }

            return esito;
        }
        
        private CasiRound ControllaVincitoreRound ()
        {
            if (_Player.Scelta != _bot.Scelta)
            {
                if ((_Player.Scelta==TipologiaScelta.Sasso && _bot.Scelta==TipologiaScelta.Carta) ||
                (_Player.Scelta == TipologiaScelta.Forbice && _bot.Scelta == TipologiaScelta.Sasso) ||
                (_Player.Scelta == TipologiaScelta.Carta && _bot.Scelta == TipologiaScelta.Forbice))
                {
                    return CasiRound.bot;
                }
                else
                {
                    return CasiRound.utente;
                }
            
            }
            else
            {
                return CasiRound.pareggio;
            }
        }
    }
}
