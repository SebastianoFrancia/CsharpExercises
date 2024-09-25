using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GattileLIB
{
    public enum Razza
    {
        Sconosciuta,
        Siamese,
        Persiano,
        ColorpointShorthair,
        Soriano
    }

    public enum Sesso
    {
        Maschio,
        Femmina
    }
    public class Gatto
    {
        private string _id;
        private string _nome;
        private Razza _razza;
        private Sesso _sesso;
        private DateOnly _arrivo;
        private DateOnly? _uscita;
        private DateOnly? _nascita;
        private string _descrizione;

        public string Nome
        {  get { return _nome; } 
           private set 
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException(message: "nome non acettabile");
                _nome = value;
            }
        }

        public Razza Razza
        {
            get { return _razza; }
            private set
            {
                _razza = value;
            }
        }

        public Sesso Sesso
        {
            get { return _sesso; }
            private set
            {
                _sesso = value;
            }
        }

        public DateOnly Arrivo
        {
            get { return _arrivo; }
            private set
            {
                if (value == null) throw new ArgumentException(message: "data arrivo nulla");
                _arrivo = value;
            }
        }

        public DateOnly? Uscita
        {
            get { return _uscita; }
            private set
            {
                if (value < _arrivo) throw new ArgumentException(message: "data di arrivo o di uscita errata");
                _uscita = value;
            }
        }

        public DateOnly? Nascita
        {
            get { return _nascita; }
            private set
            {
                if (value > _arrivo) throw new ArgumentException(message:"data di nascita errata");
                _nascita = value;
            }
        }

        public string Descrizione
        {
            get { return _descrizione; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException(message: "Descrizione non acetabile");
                _descrizione = value;
            }
        }

        public string Id
        { 
            get { return _id; } 
        }

        public Gatto(string nome, Razza razza, Sesso sesso, DateOnly arrivo, DateOnly? uscita, DateOnly? nascita, string descrizione )
        {
            Nome = nome;
            Razza = razza;
            Sesso = sesso;
            Arrivo = arrivo;
            Uscita = uscita;
            Nascita = nascita;
            Descrizione = descrizione;
            _id = GeneraId();
        }

        public Gatto(string id, string nome, Razza razza, Sesso sesso, DateOnly arrivo, DateOnly? uscita, DateOnly? nascita, string descrizione)
        {
            Nome = nome;
            Razza = razza;
            Sesso = sesso;
            Arrivo = arrivo;
            Uscita = uscita;
            Nascita = nascita;
            Descrizione = descrizione;
            _id = id;
        }

        public void AdozioneFallita(DateOnly termine)
        {
            _descrizione += $"adozione fallita: inizio {_uscita} termine {termine}";
            _uscita = null;
        }
        private string GeneraId()
        {
            string id = "";
            Random rnd = new Random();
            
            int cifra;
            for (int i = 0; i < 5; i++)
            {
                cifra = rnd.Next(0, 9);
                id += cifra;
            }

            char letteraMese = _arrivo.Month.ToString()[0];
            id += letteraMese;
            
            int anno = _arrivo.Year;
            id += anno;

            char[] lettere = new char[21] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i','l','m','n','o','p','q','r','s','t','u','v','z' };
            for (int i = 0;i < 3;i++)
            {
                id += lettere[rnd.Next(0, 21)];
            }

            return id;
        }

        public override string ToString()
        {
            return $"{_id}${_nome}${_razza}${_sesso}${_arrivo}${_uscita}${_nascita}${_descrizione}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Gatto)
            {
                Gatto gatto = (Gatto)obj;
                if (gatto.Id == _id && gatto.Nome == _nome && gatto.Razza == _razza && gatto.Sesso == _sesso)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
