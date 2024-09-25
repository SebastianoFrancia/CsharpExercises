using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GattileLIB
{
    public class Adottante
    {
        private string _nome;
        private string _cognome;
        private string _indirizzo;
        private int _telefono;

        public string Nome
        {
            get { return _nome; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException(message: "nome non acettabile");
                _nome = value;
            }
        }
        public string Cognome
        {
            get { return _cognome; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException(message:"cognome non acettabile");
                _cognome = value;
            }
        }

        public string Indirizzo
        {
            get { return _indirizzo; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException(message:"indirizzo non acettabile");
                _indirizzo = value;
            }
        }

        public int Telefono
        {
            get { return _telefono; }
            private set
            {
                if (value<0) throw new ArgumentException(message: "telefono non acettabile");
                _telefono = value;
            }
        }

        public Adottante(string nome, string cognome, string indirizzo, int telefono)
        {
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return $"{_nome}${_cognome}${_indirizzo}${_telefono}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Adottante)
            {
                Adottante adottante = (Adottante)obj;
                if (adottante.Nome == _nome && adottante.Cognome == _cognome)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
